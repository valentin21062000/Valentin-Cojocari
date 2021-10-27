using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Tema_curs_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = @"C:\Users\valen\source\repos\Tema curs 5\Tema curs 5\In.txt";
            var outputFilePath = @"C:\Users\valen\source\repos\Tema curs 5\Tema curs 5\Out.txt";
            var orasele = ReadInputFile(inputFilePath);
            var watch = new Stopwatch();
            watch.Start();
            var route = new Greedy().SolveSimpler(orasele);
            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            WriteToFile(outputFilePath, route, elapsedTime);
        }

        private static void ShowAdjacentMatrix(List<Orase> orasele)
        {
            Console.Write("\t");
            for (int i = 0; i < orasele.Count; i++)
            {
                Console.Write(i + 1 + "\t");
            }
            Console.Write("\n");

            for (int i = 0; i < orasele.Count; i++)
            {
                Console.Write(i + 1 + ":\t");
                for (int j = 0; j < orasele.Count; j++)
                {
                    var distance = Math.Round(math.GetDistance(orasele[i], orasele[j]), 2);
                    Console.Write(distance + "\t");
                }
                Console.Write("\n");
            }

            Console.ReadLine();
        }

        public static void GenerateInputInstances(string filePath, int numberOfInstances)
        {
            File.WriteAllText(filePath, numberOfInstances.ToString() + "\n");
            var random = new Random();
            for (int i = 0; i < numberOfInstances; i++)
            {
                var x = random.Next(-100, 100);
                var y = random.Next(-100, 100);
                File.AppendAllText(filePath, x + "," + y + "\n");
            }
        }


        public static double GetTotalCost(List<Orase> orasele)
        { var totalCost = 0.0;
            for (int i = 0; i < orasele.Count - 1; i++)
            {
                totalCost += math.GetDistance(orasele[i], orasele[i + 1]);
            }
            return totalCost;
        }

        private static List<Orase> ReadInputFile(string filePath)
        {
            var orasele = new List<Orase>();
            var lines = File.ReadAllLines(filePath);
            var numberOforasele = Convert.ToInt32(lines[0]);
            for (int i = 0; i < numberOforasele; i++)
            {
                var coordinates = lines[i + 1].Split(',');
                orasele.Add(new Orase()
                {
                    x = Convert.ToDouble(coordinates[0]),
                    y = Convert.ToDouble(coordinates[1]),
                    Numarul_de_orase = i + 1
                });
            }
            return orasele;
        }

        private static List<Orase> WriteToFile(string filePath, List<Orase> orasele, long elapsedTime)
        {
            var totalCost = GetTotalCost(orasele);
            File.WriteAllText(filePath, "Pret total= " + totalCost.ToString()+" lei.\n");
            for (int i = 0; i < orasele.Count; i++)
            {
                File.AppendAllText(filePath,"Orasul "+ orasele[i].Numarul_de_orase + " : " + orasele[i].x + " lei, " + orasele[i].y + "lei. \n");
            }
            return orasele;
        }
    }
}
