using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Lab2_sa
{
    class Bgw
    {

        public void Run(IFunction function, decimal rangeFrom, decimal rangeTo, string name)

        {

            var backgroundWorker1 = new BackgroundWorker();
            List<object> arguments1 = new()
            {
                function,
                rangeFrom,
                rangeTo,
                name
            };


            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += DoWork;
            backgroundWorker1.ProgressChanged += ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += WorkCompleted;
            backgroundWorker1.RunWorkerAsync(arguments1);
            Console.WriteLine("Naciśnij c aby zakończyć");
            if (Console.ReadKey(true).KeyChar == 'c')
            {
                backgroundWorker1.CancelAsync();
            }

        }
        

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> argslist = e.Argument as List<object>;

            if (argslist != null)
            {
                IFunction funkcja = (IFunction)argslist[0];

                decimal rangeTo = (decimal)argslist[2];
                decimal rangeFrom = (decimal)argslist[1];
                string name = (string)argslist[3];

                string podsumowanie = null;
                var worker = sender as BackgroundWorker;




                decimal powierzchnia = 0;

                decimal krok = ((decimal)rangeTo - (decimal)rangeFrom) / 100;


                for (int i = 1; i < 100; i++)
                {
                    if (worker != null && !worker.CancellationPending)
                    {
                        powierzchnia += funkcja.GetY((decimal)rangeFrom + i * krok);
                        Thread.Sleep(100);
                        if (i % 10 == 0)
                        {
                            worker.ReportProgress(i * 1);
                        }

                    }
                    else
                    {
                        if (worker != null) worker.CancelAsync();
                    }
                }
                powierzchnia = (powierzchnia + (funkcja.GetY(rangeFrom) + funkcja.GetY(rangeTo)) / 2) * krok;
                podsumowanie += "Przybliżona wartość całki metodą trapezów dla przedziału: " + name + " wynosi " + powierzchnia + Environment.NewLine;
                /*                Console.WriteLine("Przybliżona wartość całki metodą trapezów :" + powierzchnia);*/

            
                e.Result = podsumowanie;
            }
        }
        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"Postęp {e.ProgressPercentage}%");
        }
        void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Zadanie zakończone");
            Console.WriteLine($"{e.Result}");
            Console.WriteLine("");
        }
    }
}

