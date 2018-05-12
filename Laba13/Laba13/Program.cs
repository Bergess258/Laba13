using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<PlacesV> Lis = new List<PlacesV>();
            List<string> Lis1 = new List<string>();
            DictionaryCommon<PlacesV, PlacesV> Dic = new DictionaryCommon<PlacesV, PlacesV>();
            DictionaryCommon<string, PlacesV> Dic1 = new DictionaryCommon<string, PlacesV>();
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
            for(int i = 0; i < rand.Next(10, 20);i++)
            {
                Dic.Add(PlacesV.RandAdd(rand), PlacesV.RandAdd(rand));
            }
            Console.WriteLine("Словарь");
            Dic.Show();
            Console.WriteLine();
            Console.WriteLine("Словарь со строкой");
            DictionaryCommon<PlacesV, PlacesV>.Point First=new DictionaryCommon<PlacesV, PlacesV>.Point();
            DictionaryCommon<PlacesV, PlacesV>.Point Mid=new DictionaryCommon<PlacesV, PlacesV>.Point();
            DictionaryCommon<PlacesV, PlacesV>.Point End= new DictionaryCommon<PlacesV, PlacesV>.Point();
            KeyValuePair<PlacesV, PlacesV> No = new KeyValuePair<PlacesV, PlacesV>(new PlacesV() { Name = "щшчпрряы" }, new PlacesV() { Name = "фщржщрфу" });
            int Num = 0;
            foreach (DictionaryCommon<PlacesV, PlacesV>.Point temp in Dic.Get())
            {
                if (++Num == 1) First = temp;
                if (Num == Dic.Count / 2) Mid = temp;
                if (Num == Dic.Count) End = temp;
                Dic1.Add(temp.Key.ToString(), temp.Value);
                Lis.Add(temp.Key);
                Lis1.Add(temp.Key.ToString());
            }
            Dic1.Show();
            Console.WriteLine();
            Console.WriteLine("Лист");
            Lis.Show();
            Console.WriteLine();
            Console.WriteLine("Лист со строкой");
            Lis1.Show();
            swatch.Start();
            Console.WriteLine(Dic.Contains(new KeyValuePair<PlacesV, PlacesV>(First.Key, First.Value)));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            swatch.Start();
            Console.WriteLine(Dic1.Contains(new KeyValuePair<string, PlacesV>(First.Key.ToString(), First.Value)));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            swatch.Start();
            Console.WriteLine(Lis.Contains(First.Key));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            swatch.Start();
            Console.WriteLine(Lis1.Contains(First.Key));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            //swatch.Start();
            //Dic.Contains(new KeyValuePair<PlacesV, PlacesV>(Mid.Key, Mid.Value));
            //swatch.Stop();
            //Console.WriteLine(swatch.Elapsed);
        }
    }
}
