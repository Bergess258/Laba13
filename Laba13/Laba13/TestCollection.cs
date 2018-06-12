using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    class TestCollection
    {
        System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
        List<PlacesV> Lis = new List<PlacesV>(5000);
        List<string> Lis1 = new List<string>(5000);
        DictionaryCommon<PlacesV, PlacesV> Dic = new DictionaryCommon<PlacesV, PlacesV>(5000);
        DictionaryCommon<string, PlacesV> Dic1 = new DictionaryCommon<string, PlacesV>(5000);
        DictionaryCommon<PlacesV, PlacesV>.Point First = new DictionaryCommon<PlacesV, PlacesV>.Point();
        DictionaryCommon<PlacesV, PlacesV>.Point Mid = new DictionaryCommon<PlacesV, PlacesV>.Point();
        DictionaryCommon<PlacesV, PlacesV>.Point End = new DictionaryCommon<PlacesV, PlacesV>.Point();
        DictionaryCommon<PlacesV, PlacesV>.Point No = new DictionaryCommon<PlacesV, PlacesV>.Point(new PlacesV() { Name = "щшчпрряы" }, new PlacesV() { Name = "фщржщрфу" });
        
        public TestCollection(DictionaryCommon<PlacesV, PlacesV> tempColl)
        {
            Dic = tempColl;
            for(int i=0;i<tempColl.Count;i++)
            {
                DictionaryCommon<PlacesV, PlacesV>.Point t = tempColl[i];
                Dic1.Add(t.Key.ToString(), t.Value);
                Lis.Add(t.Key);
                Lis1.Add(t.Key.ToString());
            }
            First = Dic[0].Clone();
            Mid = Dic[Dic.Count/2].Clone();
            End = Dic[Dic.Count-1].Clone();
            Search(Lis, Lis1, Dic, Dic1, swatch, First);
            Search(Lis, Lis1, Dic, Dic1, swatch, Mid);
            Search(Lis, Lis1, Dic, Dic1, swatch, End);
            Search(Lis, Lis1, Dic, Dic1, swatch, No);
        }
        private static void Search(List<PlacesV> Lis, List<string> Lis1, DictionaryCommon<PlacesV, PlacesV> Dic, DictionaryCommon<string, PlacesV> Dic1, System.Diagnostics.Stopwatch swatch, DictionaryCommon<PlacesV, PlacesV>.Point First)
        {
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
            Console.WriteLine(Lis1.Contains(First.Key.ToString()));
            swatch.Stop();
            Console.WriteLine(swatch.Elapsed);
            Console.WriteLine();
        }
    }
    
}
