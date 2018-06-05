﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    class TestCollection
    {
        System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
        List<PlacesV> Lis = new List<PlacesV>();
        List<string> Lis1 = new List<string>();
        DictionaryCommon<PlacesV, PlacesV> Dic = new DictionaryCommon<PlacesV, PlacesV>();
        DictionaryCommon<string, PlacesV> Dic1 = new DictionaryCommon<string, PlacesV>();
        DictionaryCommon<PlacesV, PlacesV>.Point First = new DictionaryCommon<PlacesV, PlacesV>.Point();
        DictionaryCommon<PlacesV, PlacesV>.Point Mid = new DictionaryCommon<PlacesV, PlacesV>.Point();
        DictionaryCommon<PlacesV, PlacesV>.Point End = new DictionaryCommon<PlacesV, PlacesV>.Point();
        DictionaryCommon<PlacesV, PlacesV>.Point No = new DictionaryCommon<PlacesV, PlacesV>.Point(new PlacesV() { Name = "щшчпрряы" }, new PlacesV() { Name = "фщржщрфу" });
        
        public TestCollection(DictionaryCommon<PlacesV, PlacesV> tempColl)
        {
            int Num = 0;
            foreach (DictionaryCommon<PlacesV, PlacesV>.Point temp in tempColl.Get())
            {
                DictionaryCommon<PlacesV, PlacesV>.Point t = temp;
                if (++Num == 1) First = t;
                if (Num == Dic.Count / 2) Mid = t;
                if (Num == Dic.Count) End = t;
                Dic = tempColl;
                Dic1.Add(t.Key.ToString(), t.Value);
                Lis.Add(t.Key);
                Lis1.Add(t.Key.ToString());
            }
            Search(Lis, Lis1, Dic, Dic1, swatch, First);
            Search(Lis, Lis1, Dic, Dic1, swatch, Mid);
            Search(Lis, Lis1, Dic, Dic1, swatch, End);
            Search(Lis, Lis1, Dic, Dic1, swatch, No);
        }
        private static void Search(List<PlacesV> Lis, List<string> Lis1, DictionaryCommon<PlacesV, PlacesV> Dic, DictionaryCommon<string, PlacesV> Dic1, System.Diagnostics.Stopwatch swatch, DictionaryCommon<PlacesV, PlacesV>.Point First)
        {
            Console.WriteLine();
            Console.WriteLine("Словарь");
            swatch.Start();
            Console.WriteLine(Dic.Contains(new KeyValuePair<PlacesV, PlacesV>(First.Key, First.Value)));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            swatch.Reset();
            Console.WriteLine("Словарь со строкой");
            swatch.Start();
            Console.WriteLine(Dic1.Contains(new KeyValuePair<string, PlacesV>(First.Key.ToString(), First.Value)));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            swatch.Reset();
            Console.WriteLine("Лист");
            swatch.Start();
            Console.WriteLine(Lis.Contains(First.Key));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            swatch.Reset();
            Console.WriteLine("Лист со строкой");
            swatch.Start();
            Console.WriteLine(Lis1.Contains(First.Key));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
        }
    }
    
}
