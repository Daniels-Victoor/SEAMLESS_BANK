using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanksCore.Utilities
{
    public class Print_Table
    {

        
        private readonly string[] Titles;
        private readonly List<int> lengths;
        private readonly List<string[]> Rows = new List<string[]>();

        //create a constructor that takes any length of an array of strings
        public Print_Table(params string[] titles)
        {

            Titles = titles;

            lengths = titles.Select(t => t.Length).ToList();
        }

        public void AddRow(params object[] row)
        {
            if (row.Length != Titles.Length)
            {
                //error checking to make sure the header elements number is equal to the number of elements been inputed
                throw new Exception($"Added row length [{row.Length}] is not equal to title" +
                    $" row length [{Titles.Length}]");
            }
            //takes an array input from Addrow,loop through converts each element to a string
            //and then converts to an array and push to rows list

            Rows.Add(row.Select(o => o.ToString()).ToArray());


            for (int i = 0; i < Titles.Length; i++)
            {

                if (Rows.Last()[i].Length > lengths[i])
                {
                    //check the length of the last element entered in Rows and adjust the size of the table 
                    lengths[i] = Rows.Last()[i].Length;
                }
            };

        }

        public void Print()
        {
            //prints the top of the table
            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");

            //prints every other lines with the tittles of the table
            string line = "";
            for (int i = 0; i < Titles.Length; i++)
            {
                line += "| " + Titles[i].PadRight(lengths[i]) + ' ';
            }
            Console.WriteLine(line + "|");

            //prints the bottom of the table header
            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");


            //prints the table rows

            foreach (var row in Rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    line += "| " + row[i].PadRight(lengths[i]) + ' ';
                }
                Console.WriteLine(line + "|");
            }

            //prints the bottom of the table
            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");
        }
    }
}
