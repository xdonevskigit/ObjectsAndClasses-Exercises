using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndrayAndBilliard
{
    class Program
    {
        static void Main(string[] args)
        {
            var productAmount = new Dictionary<string, double>();
            var buyers = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { '-', ',', ' ' }
                                , StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "end")
                {
                    WriteTheBillingInformation(productAmount, buyers);
                    return;
                }
                if (input.Length == 2)
                {
                    string product = input[0];
                    double amount = double.Parse(input[1]);
                    if (!productAmount.ContainsKey(product))
                    {
                        productAmount.Add(product, amount);
                    }
                    else 
                    {
                        productAmount[product] = amount;
                    }
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    string product = input[1];
                    double quantity = double.Parse(input[2]);
                    if (!productAmount.Any(x => x.Key == product))
                    {
                        continue;
                    }
                    if (!buyers.ContainsKey(name))
                    {
                        buyers.Add(name, new Dictionary<string, double>());
                        buyers[name].Add(product, quantity);
                    }
                    else if(!buyers[name].ContainsKey(product))
                    {
                        buyers[name].Add(product, quantity);
                    }
                    else
                    {
                        buyers[name][product] += quantity;
                    }

                }
            }
            
        }

        private static void WriteTheBillingInformation(Dictionary<string, double> productAmount
            , Dictionary<string, Dictionary<string, double>> buyers)
        {
            double totalSum = 0;
            foreach (var names in buyers.OrderBy(x => x.Key))
            {
                string product = "";
                double sum = 0;
                double currentSum = 0;
                Console.WriteLine(names.Key);
                foreach (var item in names.Value)
                {
                    
                    product = item.Key;
                    sum = sum + item.Value * productAmount[product];
                    currentSum = item.Value * productAmount[product];
                    totalSum = totalSum + currentSum;
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {sum:F2}");
            }
            Console.WriteLine($"Total bill: {totalSum:F2}");
        }
    }
}
