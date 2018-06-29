using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reducer
{
    public class ReducerFunctions : IReducerFunctions
    {
       

        public void Reduce(Dictionary<ProductionCompany, double> MapResultDictionary, string fileId)
        {
            Console.WriteLine("Reducing started");
            var subDictionary = MapResultDictionary.GroupBy(val => val.Key.id).ToDictionary(k => k.Key, v => v.ToDictionary(k1 => k1.Key, v1 => v1.Value)); // dictionary medju kljuc-id, vrednost- svi koji pripadaju tom id-iju

            Dictionary<ProductionCompany, double> Reduced = new Dictionary<ProductionCompany, double>();//krajnji koji cemo popuniti

        
            foreach (var item in subDictionary) //nakon reduce
            {
                double sum = 0;
                ProductionCompany pc = new ProductionCompany();
                foreach (var value in item.Value)
                {
                    sum += value.Value;
                    pc = value.Key;
                }
                Reduced.Add(pc, sum);
            }

            Console.WriteLine("===Reduced==="); //ispis konacnog
            foreach (var item in Reduced)
            {
                Console.WriteLine(item.Key.name + " : " + item.Value);
            }

            
            if (fileId != null)// Upis u txt fajlove
            {
                using (StreamWriter sw = new StreamWriter("reduced-" + fileId + ".txt"))
                {
                    foreach (var item in Reduced)
                    {
                        sw.WriteLine(item.Key.id + ";" + item.Key.name + ";" + item.Value);
                    }
                }
            }
        }

        public void ReduceAll()
        {
            Dictionary<ProductionCompany, double> FinalReduceDictionary = new Dictionary<ProductionCompany, double>();
            Dictionary<ProductionCompany, double> AllTxtDictionary = new Dictionary<ProductionCompany, double>();

            // Iscitaj sve txt fajlove popuni dictionary
            int[] fileIds = new int[] { 5002, 5003 };
            for (int i = 0; i < fileIds.Length; i++)
            {
                using (StreamReader sr = new StreamReader("reduced-" + fileIds[i] + ".txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitter = line.Split(';');
                        ProductionCompany pc = new ProductionCompany();
                        pc.id = Int32.Parse(splitter[0]);
                        pc.name = splitter[1];
                        double value = Double.Parse(splitter[2]);

                        AllTxtDictionary.Add(pc, value);
                    }
                }
            }

            // Uradi reduce
            FinalReduceDictionary = FinalReduce(AllTxtDictionary);

            PrintReduced(FinalReduceDictionary);


            //upisati sve vredosti u txt fajl

          
                using (StreamWriter sw = new StreamWriter("Svereduce.txt"))
                {
                    foreach (var item in FinalReduceDictionary)
                    {
                        sw.WriteLine(item.Key.id + ";" + item.Key.name + ";" + item.Value);
                    }
                }

            ReduceByCompany();
        }


        public Dictionary<ProductionCompany, double> FinalReduce(Dictionary<ProductionCompany, double> AllTxtDictionary)
        {
            var subTxtDictionary = AllTxtDictionary.GroupBy(val => val.Key.id).ToDictionary(k => k.Key, v => v.ToDictionary(k1 => k1.Key, v1 => v1.Value));

            Dictionary<ProductionCompany, double> Reduced = new Dictionary<ProductionCompany, double>();
            
            foreach (var item in subTxtDictionary)
            {
                double sum = 0;
                ProductionCompany pc = new ProductionCompany();
                foreach (var value in item.Value)
                {
                    sum += value.Value;
                    pc = value.Key;
                }
                Reduced.Add(pc, sum);
            }

            return Reduced;
        }

        public void PrintReduced(Dictionary<ProductionCompany, double> ReducedDictionary) //ispisujem u konzoli konacni reducovani txt bez kopija
        {
            Console.WriteLine("---------PRINTING REDUCED-----------");
            foreach (var item in ReducedDictionary)
            {
                Console.WriteLine(item.Key.name + " : " + item.Value);
            }
        }

        public void ReduceByCompany()
        {
            Dictionary<ProductionCompany, double> LoadedData = new Dictionary<ProductionCompany, double>();
            // Load txt
            using (StreamReader sr = new StreamReader("Svereduce.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitter = line.Split(';');
                    ProductionCompany pc = new ProductionCompany();
                    pc.id = Int32.Parse(splitter[0]);
                    pc.name = splitter[1].Split(' ')[0];
                    double value = Double.Parse(splitter[2]);

                    LoadedData.Add(pc, value);
                }
            }
            // Reduce
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=== Reducing by company ===");
            Console.WriteLine();
            Console.WriteLine();
            var valuePairs = LoadedData.GroupBy(val => val.Key.name).ToDictionary(k => k.Key, v => v.ToDictionary(k1 => k1.Key, v1 => v1.Value));

            Dictionary<ProductionCompany, double> Reduced = new Dictionary<ProductionCompany, double>();

            foreach (var item in valuePairs)
            {
                double sum = 0;
                ProductionCompany pc = new ProductionCompany();
                foreach (var value in item.Value)
                {
                    sum += value.Value;
                    pc = value.Key;
                }
                Reduced.Add(pc, sum);
            }

            Console.WriteLine("===Reduced===");
            foreach (var item in Reduced)
            {
                Console.WriteLine(item.Key.name + " : " + item.Value);
            }

            // Upis finalnog reduca u txt fajl
            using (StreamWriter sw = new StreamWriter("finalReduce.txt"))
            {
                foreach (var item in Reduced)
                {
                    sw.WriteLine(item.Key.id + ";" + item.Key.name + ";" + item.Value);
                }
            }
        }
    }
}
