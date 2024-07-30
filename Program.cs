using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using AutomobiliuNuoma.Core.Repositories;
using AutomobiliuNuoma.Core.Service;
using System;
using System.Collections.Generic;



namespace ManoPrograma
{
    public class PagrindineKlase
    {
        static void Main()
        {
            IAutonuomaService autonuomaService = SetupDependencies();
            while (true)
            {
                Console.WriteLine("1. Rodyti visus automobilius");
                Console.WriteLine("2. Rodyti visus klientus");
                Console.WriteLine("3. Formuoti nuomos uzsakyma");
                Console.WriteLine("4. Prideti nauja klienta");
                Console.WriteLine("5. Prideti nauja automobili");
                string pasirinkimas = Console.ReadLine();
                switch (pasirinkimas)
                {
                    case "1":
                        List<Automobilis> auto = autonuomaService.GautiVisusAutomobilius();
                        foreach (Automobilis a in auto)
                        {
                            Console.WriteLine(a);
                        }
                        break;
                    case "2":
                        List<Klientas> klientai = autonuomaService.GautiVisusKlientus();
                        foreach (Klientas a in klientai)
                        {
                            Console.WriteLine(a);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Nuomos uzsakymas: ");
                        foreach (Klientas k in autonuomaService.GautiVisusKlientus())
                        {
                            Console.WriteLine(k);
                        }

                        Console.WriteLine("Iveskite norimo kliento varda");
                        string vardas = Console.ReadLine();
                        Console.WriteLine("Iveskite norimo kliento pavarde");
                        string pavarde = Console.ReadLine();

                        foreach (Automobilis a in autonuomaService.GautiVisusAutomobilius())
                        {
                            Console.WriteLine(a);
                        }

                        Console.WriteLine("Pasirinkite automobili pagal Id sarase: ");
                        int autoId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Iveskite kiek dienu autommobilis yra isnuomojamas: ");
                        int dienos = int.Parse(Console.ReadLine());

                        autonuomaService.SukurtiNuoma(vardas, pavarde, autoId, DateTime.Now, dienos);

                        break;

                    case "4":
                        
                        Console.WriteLine("Irasykite kliento varda");
                        string klientoVardas = Console.ReadLine();
                        Console.WriteLine("Irasykite kliento pavarde");
                        string klientoPavarde = Console.ReadLine();
                        Console.WriteLine("Irasykite kliento gimimo data");
                        DateOnly KlientoGimimoData = DateOnly.Parse(Console.ReadLine());

                        autonuomaService.IrasytiKlientus(klientoVardas, klientoPavarde, KlientoGimimoData);

                        break;








                        //Console.WriteLine("Irasykite automobilio Id");
                        //int autoId = int.Parse(Console.ReadLine());
                        //Console.WriteLine("Irasykite automobilio Marke");
                        //string autoMarke = Console.ReadLine();
                        //Console.WriteLine("Irasykite automobilio Modeli");
                        //string autoModdelis = Console.ReadLine();
                        //Console.WriteLine("Irasykite automobilio nuomos kaina");
                        //double autoNuomosKaina = double.Parse(Console.ReadLine());
                        //Console.WriteLine("Ar automobilis yra elektromobilis ar varomas naftos kuru? ");

                        //if ()





                        //foreach (Klientas k in autonuomaService.GautiVisusKlientus())
                        //{
                        //    Console.WriteLine(k);
                        //}


                        //foreach (Automobilis a in autonuomaService.GautiVisusAutomobilius())
                        //{
                        //    Console.WriteLine(a);
                        //}

                        //Console.WriteLine("Pasirinkite automobili pagal Id sarase: ");
                        //int autoId = int.Parse(Console.ReadLine());

                        //Console.WriteLine("Iveskite kiek dienu autommobilis yra isnuomojamas: ");
                        //int dienos = int.Parse(Console.ReadLine());

                        //autonuomaService.SukurtiNuoma(vardas, pavarde, autoId, DateTime.Now, dienos);

                        //break;

                }
            }



        }
        public static IAutonuomaService SetupDependencies()
        {
            IKlientaiRepository klientaiRepository = new KlientaiFileRepository("Klientai.csv");
            IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiFileRepository("Automobiliai.csv");
            IKlientaiService klientaiService = new KlientaiService(klientaiRepository);
            IAutomobiliaiService automobiliaiService = new AutomobiliaiService(automobiliaiRepository);
            return new AutonuomosService(klientaiService, automobiliaiService);
        }


    }
}



    




