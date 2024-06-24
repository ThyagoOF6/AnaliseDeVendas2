using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Entities;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            Console.Write("Entre o caminho do arquivo: ");
            string path = Console.ReadLine();

            try
            {
                List<Sale> list = new List<Sale>();

                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        list.Add(new Sale(
                            int.Parse(fields[0]),
                            int.Parse(fields[1]),
                            fields[2],
                            int.Parse(fields[3]),
                            double.Parse(fields[4])
                        ));
                    }
                }

                HashSet<string> sellers = new HashSet<string>();

                foreach (var sale in list)
                {
                    sellers.Add(sale.Seller);
                }

                Console.WriteLine();
                Console.WriteLine("Total de Vendas por Vendedor ");

                Dictionary<string, double> salesBySeller = new Dictionary<string, double>();

                foreach (var seller in sellers)
                {
                    double totalPerSeller = list
                        .Where(s => s.Seller == seller)
                        .Sum(s => s.Total ?? 0);
                    salesBySeller[seller] = totalPerSeller;
                }

                foreach (var entry in salesBySeller)
                {
                    Console.WriteLine($"{entry.Key} - R$ {entry.Value:F2}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}