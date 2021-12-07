using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3_sa
{
    class Tpl : IPrzetwarzania
    {
        private string Work(object sender, CancellationToken token)
        {
            List<object> argslist = sender as List<object>;
            string podsumowanie = null;

            if (argslist != null)
            {
                IFunction funkcja = (IFunction)argslist[0];

                decimal rangeTo = (decimal)argslist[2];
                decimal rangeFrom = (decimal)argslist[1];
                string name = (string)argslist[3];

                

                decimal powierzchnia = 0;

                decimal krok = ((decimal)rangeTo - (decimal)rangeFrom) / 100;


                for (int i = 1; i <= 100; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    else
                    {
                        powierzchnia += funkcja.GetY((decimal)rangeFrom + i * krok);
                        Thread.Sleep(10);
                        if (i % 10 == 0)
                        {
                            Console.WriteLine($"Postęp {i}%");
                        }
                    }
                }
                
                powierzchnia = (powierzchnia + (funkcja.GetY(rangeFrom) + funkcja.GetY(rangeTo)) / 2) * krok;
                podsumowanie += "Przybliżona wartość całki metodą trapezów dla przedziału: " + name + " wynosi " + powierzchnia + Environment.NewLine;

                }
            return podsumowanie;
        }

/*        public void Run1()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task<string> task1 = new Task<string>(
                () => PrintNumbers(1000, token), token);
            task1.Start();
            Console.WriteLine("Naciśnij c aby zakończyć");
            if (Console.ReadKey(true).KeyChar == 'c')
            {
                tokenSource.Cancel();
            }

            if (!task1.IsCanceled)
            {
                Console.WriteLine(task1.Result);
            }

            Console.WriteLine("Koniec działania");
        }*/

        public string Name => "TPL";
        public int Id => 1;

        public void Run(IFunction function, decimal rangeFrom, decimal rangeTo, string name)
        {
            List<object> arguments1 = new()
            {
                function,
                rangeFrom,
                rangeTo,
                name
            };
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task<string> task1 = new Task<string>(
                () => Work(arguments1, token), token);
            task1.Start();
            Console.WriteLine("Naciśnij c aby zakończyć");
            Console.ReadKey();
            tokenSource.Cancel();

            if (!task1.IsCanceled)
            {
                Console.WriteLine(task1.Result);
            }
/*            {
                
            }

            if (Console.ReadKey(true).KeyChar == 'c')
            {
                Console.WriteLine(task1.Result);
                tokenSource.Cancel();
            }
            else
            {
                Console.WriteLine(task1.Result);
            }
            Console.WriteLine(task1.Result);*/
            /*            if (!task1.IsCompleted)
                        {
                            Console.ReadKey();
                            tokenSource.Cancel();
                        }
                        else
                        {
                            Console.WriteLine(task1.Result);
                        }*/


            /*  if (Console.ReadKey(true).KeyChar == 'c')
              {
                  tokenSource.Cancel();
              }
              else
              {

                  Console.WriteLine(task1.Result);
              }*/

            /*            if (!task1.IsCanceled)
                        {
                            Console.WriteLine(task1.Result);
                        }*/

            Console.WriteLine("Koniec działania");
        }
    }
}
