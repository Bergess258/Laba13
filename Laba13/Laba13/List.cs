using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    class List<PlacesV> : IEnumerable<PlacesV>, ICloneable, ICollection<PlacesV>, IComparer<PlacesV>
    {
        private int count = 0;
        private PlacesV[] mas = new PlacesV[0];
        public List()
        {

        }
        public List(int cap)
        {
            mas = new PlacesV[cap];
        }
        public List(PlacesV[] mas)
        {
            this.mas = mas;
        }

        public PlacesV this[int index]
        {
            get { return mas[index]; }
            set { mas[index] = value; }
        }
        static void RandAdd(List<PlacesV> Main,int CountAdding)
        {
            do
            {
                Random rand = new Random();
                string Name = "";
                int c = rand.Next(4);
                if (c == 0)
                {
                    Region temp;
                    do
                    {
                        Name = RandomNameRegion(rand);
                        temp = new Region(Name, rand.Next(0, 10000000), rand.Next(0, 20));
                    } while (Main.Contains(temp));
                    Add(temp);
                }
                else
                if (c == 1)
                {
                    City temp;
                    do
                    {
                        Name = RandomCity(rand);
                        temp = new City(Name, rand.Next(0, 900000));
                    } while (Contains((PlacesV)temp));
                    Places.Add(temp);
                }
                else
                if (c == 2)
                {
                    Megapolis temp;
                    do
                    {
                        Name = RandomMegapolis(rand);
                        temp = new Megapolis(Name, rand.Next(0, 20));
                    } while (Contains(temp));
                    Places.Add(temp);
                }
                else
                {
                    Adres temp;
                    do
                    {
                        Name = RandomAdres(rand);
                        temp = new Adres(Name);
                    } while (Contains(temp));
                    Add(temp);
                }
            } while (CountAdding-- != 0);
        }
        public void Add(PlacesV item)
        {
            if (count == mas.Length)
            {
                PlacesV[] Temp = new PlacesV[mas.Length + 1];
                mas.CopyTo(Temp, 0);
                Temp[Temp.Length - 1] = item;
                mas = Temp;
            }
            else
                mas[count] = item;
            count++;
        }
        public void Clear()
        {
            mas = new PlacesV[0];
        }
        public void CopyTo(PlacesV[] array, int index)
        {
            if (index > 0 && index <= mas.Length)
            {
                PlacesV[] Temp = new PlacesV[mas.Length - index + 1];
                int c = 0;
                for (int i = index - 1; i < mas.Length; i++)
                    Temp[c++] = mas[i];
                array = Temp;
            }
            else
                throw new IndexOutOfRangeException();
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public int Count
        {
            get { return count; }
        }
        public bool Remove(PlacesV item)
        {
            if (mas.Contains(item))
            {
                PlacesV[] Temp = new PlacesV[mas.Length - 1];
                int c = 0, c1 = -1;
                foreach (PlacesV temp in mas)
                {
                    c1++;
                    if (!temp.Equals(item)) Temp[c++] = mas[c1];
                }
                count--;
                return true;
            }
            return false;
        }
        public void Show()
        {
            foreach (PlacesV temp in mas)
            {
                Console.WriteLine(temp.ToString());
            }
        }
        public bool Contains(PlacesV Search)
        {
            foreach (PlacesV temp in mas)
            {
                if (temp.ToString() == Search.ToString()) return true;
            }
            return false;
        }
        public IEnumerator<PlacesV> GetEnumerator()
        {
            return ((IEnumerable<PlacesV>)mas).GetEnumerator();//вапрыва
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<PlacesV>).GetEnumerator();
        }

        object ICloneable.Clone()
        {
            return this;
        }
        public void Sort()
        {
            Array.Sort(mas);
        }

        public int Compare(PlacesV x, PlacesV y)
        {
            if (x.ToString().Length == y.ToString().Length) return 0;
            if (x.ToString().Length > y.ToString().Length) return 1;
            return -1;
        }
    }
}
