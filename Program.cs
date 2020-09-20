using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCellphoneList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prefix = { 50, 51, 52, 53, 54, 58 }; // all prefixes (050,051,052,053,054,058) except 055
            int[] prefix055 = { 22, 23, 24, 25, 26, 27, 28, 32, 33, 44, 55, 66, 67, 68, 70, 71, 72, 87, 88, 89, 91, 92, 93, 94, 95, 96, 97, 98, 99 }; // 055's sub-prefixes, as 055 is for all the MVNO
            List<string> final = new List<string>(); // a list to hold all results. Probably could've done something better, but it works so who cares

            // first, let's get all 055 numbers
            foreach (int p in prefix055)
            {
              int i = 0;
              string numberprefix = "055" + p;
              while (i < 100000)
              {
                    string numberholder = numberprefix + i.ToString().PadLeft(5, '0');
                    final.Add(numberholder);
                    i++;
               }
            }

            // then lets get all the rest
            for(int i = 0; i < 10000000; i++)
            {
                foreach (int p in prefix)
                {
                    string numberholder = "0" + p + i.ToString().PadLeft(7, '0');
                    final.Add(numberholder);
                }
            }

            // now lets write every number we got into a list
            TextWriter tw = new StreamWriter("SavedList.txt");
            foreach (string s in final)
                tw.WriteLine(s);

            tw.Close();

        }
    }
}
