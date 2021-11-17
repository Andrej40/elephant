using System;
using System.IO;

namespace LA1300_1_elephant
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.ForegroundColor = ConsoleColor.Blue;

                Title();

                int ModePick = PickMode();
                if (ModePick == 2)
                {
                    EngModeInterrogate();
                }
                if (ModePick == 1)
                {
                    DeModeInterrogate();
                }
        }

        
        static void Cooldown()
        {
                Console.Write(5);
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b");
                Console.Write(4);
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b");
                Console.Write(3);
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b");
                Console.Write(2);
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b");
                Console.Write(1);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
        }
            
        static void Rules()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Zuerst ein paar Regeln.");
            Console.WriteLine("1. Schreiben Sie alle Wörter klein");
            Console.WriteLine("2. Wenn Sie [skip] eingeben wird das aktuelle Wort übersprungen.");
            Console.WriteLine("3. Wenn Sie [stop] eingeben wird das Programm beendet.");
            Console.WriteLine("Das waren die Regeln, nun Wünschen wir Ihnen viel Spass beim Lernen.");
            Console.WriteLine("(Drücken Sie eine Taste um fortzufahren.)");
            Console.ReadKey();
            Console.Clear();
        }

            static void Title()
            {
                string Title = @"

   __                 _             _             
  / /  ___ _ __ _ __ (_)_ __   __ _| |_ ___  _ __ 
 / /  / _ \ '__| '_ \| | '_ \ / _` | __/ _ \| '__|
/ /__|  __/ |  | | | | | | | | (_| | || (_) | |   
\____/\___|_|  |_| |_|_|_| |_|\__,_|\__\___/|_|                                                                               
";
                Console.WriteLine(Title);
            }


            static int PickMode()
            {
                bool isContinue = false;
                int ModeTip = 0;
                Console.WriteLine("Wie wollen Sie lernen?");
                do
                {
                    Console.WriteLine("Wenn Sie mit Deutsch antworten wollen schreiben Sie [1].");
                    Console.WriteLine("Wenn Sie mit Englisch antworten wollen schreiben Sie [2].");
                    Console.Write("[1/2]: ");
                    try
                    {
                        ModeTip = Convert.ToInt32(Console.ReadLine());
                        if (ModeTip == 1 || ModeTip == 2)
                        {
                            isContinue = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ihr Eingabe ist ungültig.");
                        isContinue = false;
                    }
                } while (isContinue == false);

                return ModeTip;
            }

            
            static string UserInputFinder()
            {
                string UserInput = "";
                try
                {
                    Console.Write("Eingabe: ");
                    UserInput = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("*ungültige Eingabe*");
                }
                return UserInput;
            }


            
            static void DeModeInterrogate()
            {
                string DEpath = @"..\..\..\GerNew.csv";
                string ENGpath = @"..\..\..\EngNew.csv";

                string DEtext = File.ReadAllText(DEpath);
                string ENGtext = File.ReadAllText(ENGpath);

                string[] DEWords = DEtext.Split("\r\n");
                string[] ENGWords = ENGtext.Split("\r\n");

                int Place = 0;

                try
                {
                    Rules();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    do
                    {
                        Console.WriteLine("Was bedeutet [" + DEWords[Place] + "] auf Englisch ?");
                        string UserIn = UserInputFinder();
                        if (UserIn == ENGWords[Place])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Herzlichen Glückwunsch, Sie haben das Wort richtig.");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (UserIn == "skip")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Die richtige Lösung lautet " + ENGWords[Place]);
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (UserIn == "stop")
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Leider falsch");
                            Console.WriteLine("Die richtige Lösung lautet " + ENGWords[Place]);
                            Cooldown();
                            Place = Place - 1;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Place++;
                    } while (Place < DEWords.Length);
                }
                catch
                {

                }
            }
            
            static void EngModeInterrogate()
            {
                string DEpath = @"..\..\..\GerNew.csv";
                string ENGpath = @"..\..\..\EngNew.csv";

                string DEtext = File.ReadAllText(DEpath);
                string ENGtext = File.ReadAllText(ENGpath);

                string[] DEWords = DEtext.Split("\r\n");
                string[] ENGWords = ENGtext.Split("\r\n");

                int Place = 0;

                try
                {
                    Rules();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    do
                    {
                        Console.WriteLine("Was bedeutet [" + ENGWords[Place] + "] auf Deutsch ?");
                        string UserIn = UserInputFinder();
                        if (UserIn == DEWords[Place])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Herzlichen Glückwunsch, Sie haben das Wort richtig.");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (UserIn == "skip")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Die richtige Lösung lautet " + DEWords[Place]);
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (UserIn == "stop")
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Leider falsch");
                            Console.WriteLine("Die richtige Lösung lautet " + ENGWords[Place]);
                            Cooldown();
                            Place = Place - 1;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Place++;
                    } while (Place < ENGWords.Length);
                }
                catch
                {

                }

            }
        
    }
}
