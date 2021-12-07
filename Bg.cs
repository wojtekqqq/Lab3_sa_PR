using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Lab3_sa
{
    class Bg
    {

        public void Run(IFunction function, List<IPrzedzialy> przedzialy)
        {
            var backgroundWorker1 = new BackgroundWorker();
            List<object> arguments1 = new()
            {
                function,
                przedzialy
            };

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += DoWork;
            backgroundWorker1.ProgressChanged += ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += WorkCompleted;   
            backgroundWorker1.RunWorkerAsync(arguments1);
            Console.WriteLine("Naciśnij c aby zakończyć");
            while (backgroundWorker1.IsBusy)
            {
                if (Console.ReadKey(true).KeyChar == 'c')
                {
                    backgroundWorker1.CancelAsync();
                }
            }
        }


        private void DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> argslist = e.Argument as List<object>;
            if (argslist != null)
            {
                IFunction funkcja = (IFunction)argslist[0];
                argslist.RemoveAt(0);
                List<IPrzedzialy> p = (List<IPrzedzialy>)argslist[0];
                string podsumowanie = null;
                var worker = sender as BackgroundWorker;
                foreach (var item in p)
                {                                
                    decimal rangeTo = item.RangeTo();
                    decimal rangeFrom = item.RangeFrom();
                    decimal powierzchnia = 0;
                    decimal krok = (rangeTo - rangeFrom) / 100;


                    for (int i = 1; i < 100; i++)
                    {
                        if (worker is { CancellationPending: false })
                        {
                            powierzchnia += funkcja.GetY(rangeFrom + i * krok);
                            Thread.Sleep(10);
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
                    podsumowanie += "Przybliżona wartość całki metodą trapezów dla przedziału: " + item.Name + " wynosi " + powierzchnia + Environment.NewLine;
                
                }
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
