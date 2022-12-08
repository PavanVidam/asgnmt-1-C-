using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDAsgnmt1
{
    class Program
    {
        enum Sports
        {
            CubsBaseball = 200, BlackhawksHockey = 280, BearsFootball = 470
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Go();
            Console.ReadKey();
        }

        public void Go()
        {
            try
            {

                Console.OutputEncoding = Encoding.UTF8;
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-CA");

                var values = Enum.GetValues(typeof(Sports));

                int moneySpent = 0;
                int totalTickets = 0;


                int count = 0;
                string numT = string.Empty;

                foreach (var choice in values)
                {
                    bool result = true;

                    Console.Write("Walter bought tickets for {0}? (Y or N): ", choice);

                    do
                    {
                        switch (Console.ReadLine())
                        {

                            case "Y":
                                do
                                {
                                    try
                                    {

                                        Console.WriteLine("Walter bought tickets for {0} that costs {1}", choice, ((int)choice).ToString("c"));

                                        do
                                        {
                                            Console.Write("tickets Walter bought? (0-100): ");
                                            numT = Console.ReadLine();

                                        } while (!int.TryParse(numT, out count) || count < 0 || count > 100);

                                        string insert = Console.ReadLine();

                                        if (int.TryParse(insert, out int numTickets) && numTickets >= 0 && count > 0)
                                        {
                                            int totalPrice = (numTickets * ((int)choice));

                                            Console.WriteLine("Money spent for {0} is {1}", choice, (totalPrice * count).ToString("c"), choice);
                                            moneySpent += (totalPrice * count);
                                            totalTickets += numTickets;
                                            totalTickets += count;
                                            result = false;
                                        }

                                        else if (numTickets < 0)
                                        {
                                            Exception Ep = new Exception("selected sports ticket must be more than 0 !!");
                                            throw Ep;
                                        }

                                        else
                                        {
                                            Exception e = new Exception("please insert the valid value!!");
                                            throw e;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                } while (result);
                                break;

                            case "N":
                                result = false;
                                break;

                            default:
                                Console.WriteLine("please select Y or N");
                                break;


                        }
                    } while (result);
                }

                if (totalTickets > 0)
                {
                    Console.WriteLine("Walter spent {0}", moneySpent.ToString("c"));

                    Console.WriteLine("The average price for watching the sport is" + (((decimal)moneySpent) / totalTickets).ToString("c"));
                }
                else
                {
                    Console.WriteLine("Walter is not intrested!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
           
        }
    }
}
