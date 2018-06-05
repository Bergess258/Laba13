using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba13
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            DictionaryCommon<PlacesV, PlacesV> Dic = new DictionaryCommon<PlacesV, PlacesV>();
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(50);
                Dic.Add(PlacesV.RandAdd(rand), PlacesV.RandAdd(rand));
            }
            TestCollection Collections = new TestCollection(Dic);
            Console.Read();
        }
    }
}
