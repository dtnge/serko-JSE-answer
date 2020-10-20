using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Till
    {
        //Adding D to Dictonary
        private Dictionary<char, int> _items = new Dictionary<char, int>{
            {'A', 0},
            {'B', 0},
            {'C', 0},
            {'D', 0}
        };

        public double Total()
        {
            double total = 0;
            foreach (var item in _items)
            {
                switch (item.Key)
                {
                    case 'A': total += AddItemA(item.Value.ToString()); break;
                    case 'B': total += AddItemB(item.Value.ToString()); break;
                    case 'C': total = AddItemC(total, item); break;
                    case 'D': total = AddItemD(total, item); break;


                    default: Console.WriteLine("Item"); break;
                }
                // if (item.Key.Equals('A'))
                // {
                //     total += AddItemA(item.Value.ToString());
                // }
                // else if (item.Key.Equals('B'))
                // {
                //     total += AddItemB(item.Value.ToString());
                // }
                // else if (item.Key.Equals('C'))
                // {
                //     total = AddItemC(total, item);
                // }
                // else total = AddItemD(total, item);
            }
            return total;
        }

        static double AddItemD(double total, KeyValuePair<char, int> item)
        {
            if (item.Key.Equals('D'))
            {
                total += 15 * item.Value;
            }

            return total;
        }


        private static double AddItemC(double total, KeyValuePair<char, int> item)
        {
            if (item.Value > 6)
            {
                Console.WriteLine("Maximum of 6 items allowed");
            }
            else if (item.Key.Equals('C'))
            {
                total += 20 * item.Value;
            }

            return total;
        }


        public double AddItemA(string numberItems)
        {

            double items = Double.Parse(numberItems);

            if (items == 0) return 0;

            var cost = items * 50;
            var numberOfPairs = Math.Floor(items / 3);
            // Calculating discounts if items are 3,6,9
            var discount = numberOfPairs * 20;
            return (items >= 3) ? cost - discount : cost;
        }

        public double AddItemB(string numberItems)
        {
            double items = Double.Parse(numberItems);

            if (items == 0) return 0;

            var cost = items * 30;
            var numberOfPairs = Math.Floor(items / 2);

            // Calculating discounts if items are 2,4,6 kind
            var discount = numberOfPairs * 15;
            return (items >= 2) ? cost - discount : cost;
        }

        public void Scan(string items)
        {
            // regardless of option, changes lower cas to upper case
            items = items.ToUpper();
            foreach (var item in items)
            {
                // if (!items.Contains(items))
                // {
                //     // Error if the user makes a wrong selection
                //     Console.WriteLine(string.Format("Item {0} doesn't exist", item));
                //     continue;
                // }

                _items[item]++;
            }


        }
    }
}