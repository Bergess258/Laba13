using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    class DictionaryCommon<TKey,TValue> : IDictionary<TKey, TValue>, IDisposable, ICloneable, IEnumerator,IEnumerable
    {
        public class Point : IComparable
        {
            public int HashCode = -1;
            public int Next = -1;
            public TValue Value;
            public TKey Key;
            public Point()
            {

            }
            public Point(TKey key,TValue value)
            {
                Value = value;
                Key = key;
            }

            public Point Clone()
            {
                TKey temp = Key;
                TValue tempval = Value;
                return new Point(temp, tempval);
            }

            public int CompareTo(object x)
            {
                if (x.ToString() == this.ToString()) return 0;
                if (x.ToString().Length > this.ToString().Length) return 1;
                return -1;
            }

            public override string ToString()
            {
                return Key.ToString() + "   " + Value.ToString();
            }
        }
        private int count = 0;
        private int position = -1;
        private int SizeMass = 100;
        private int[] buckets = new int[100];
        private Point[] entries = new Point[100];
        public DictionaryCommon()
        {
            CreateMasses(out buckets, out entries);
        }
        public DictionaryCommon(int c)
        {
            SizeMass = c;
            CreateMasses(out buckets, out entries);
        }
        public Point this[int key]
        {
            get
            {
                if(key>-1&&key<count)
                return entries[key];
                else
                    throw new RangeArrayException(" Индекс не попадает в диапазон");
            }
        }
        public TValue this[TKey key]
        {
            get
            {
                int place = buckets[GetHash(key)];
                Point temp = entries[place];
                if (temp.HashCode != -1)
                {
                    do
                    {
                        if (temp.Key.ToString() == key.ToString()) return temp.Value;
                        else
                        {
                            if (temp.Next == -1)
                            {
                                throw new Exception("Такого элемента нет");
                            }
                            temp = entries[temp.Next];
                        }
                    } while (true);
                }
                throw new Exception("Такого элемента нет");
            }
            set
            {
                int hash = GetHash(key);
                int place = buckets[GetHash(key)];
                entries[place]= new Point() { HashCode = hash, Key = key, Value = value, Next = entries[place].Next };
            }
        }
        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly { get { return false; } }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get
            {
                TKey[] Temp = new TKey[count];
                for (int i = 0; i < count; i++)
                {
                    Temp[i] = entries[i].Key;
                }
                return Temp;
            }
        }
        public void Show()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(entries[i].ToString());
            }
        }
        public void Sort()
        {
            ClearBuckets();
            Array.Sort(entries);
            for (int i = 0; i < count; i++)
            {
                int hash = entries[i].HashCode;
                if (buckets[hash] == -1) buckets[hash] = i;
                else
                {
                    Point temp = entries[buckets[hash]];
                    do
                    {
                        if (temp.Next == -1) { temp.Next = i; break; }
                        temp = entries[temp.Next];
                    } while (true);
                }

            }
        }
        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get
            {
                TValue[] Temp = new TValue[count];
                for (int i = 0; i < count; i++)
                {
                    Temp[i] = entries[i].Value;
                }
                return Temp;
            }
        }
        public void Add(TKey key, TValue value)
        {
            int hash = GetHash(key);
            int place = buckets[hash];
            string ForKey = key.ToString(), ForValue = value.ToString();
            if (place != -1)
            {
                Point temp = entries[place];
                int pla = place;
                do
                {
                    if (temp.Key.ToString() ==  ForKey&& temp.Value.ToString() == ForValue) break;
                    else
                    {
                        if (temp.Next == -1)
                        {
                            entries[pla].Next = count;
                            entries[count++] = new Point() { HashCode = hash, Key = key, Value = value };
                            break;
                        }
                        pla = temp.Next;
                        temp = entries[temp.Next];
                    }
                } while (true);
            }
            else
            {
                entries[count] = new Point() { HashCode = hash, Key = key, Value = value };
                buckets[hash] = count++;
            }
            CheckForSize();
        }

        private void CheckForSize()
        {
            if (count / (double)SizeMass > 0.7)
            {
                SizeMass += 200;
                int[] te;
                Point[] Temp;
                CreateMasses(out te, out Temp);
                for (int i = 0; i < count; i++)
                {
                    int hash = GetHash(entries[i].Key);
                    entries[i].HashCode = hash;
                    Temp[i] = entries[i];
                    Temp[i].Next = -1;
                    if (te[hash] != -1)
                    {
                        Point point = Temp[te[hash]];
                        do
                        {
                            if (point.Next == -1)
                            {
                                point.Next = i;
                                break;
                            }
                            point = Temp[point.Next];
                        } while (true);
                    }
                    else
                    te[hash] = i;
                }
                entries = Temp;
                buckets = te;
            }
            //else
            //if (SizeMass - 100 != 0)
            //    if ((count / (double)(SizeMass - 100)) < 0.1)
            //    {
            //        Console.WriteLine("OMYGOD");
            //        SizeMass -= 100;
            //        int[] te;
            //        Point[] Temp;
            //        CreateMasses(out te, out Temp);
            //        for (int i = 0; i < count; i++)
            //        {
            //            Temp[i] = entries[i];
            //            te[GetHash(entries[i].Key)] = i;
            //        }
            //        entries = Temp;
            //        buckets = te;
            //    }
        }
        private void CreateMasses(out int[] te, out Point[] Temp)
        {
            te = new int[SizeMass];
            Temp = new Point[SizeMass];
            for (int i = 0; i < SizeMass; i++)
            {
                te[i] = -1;
            }
            for (int i = 0; i < SizeMass; i++)
            {
                Temp[i] = new Point();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            count = 0;
            SizeMass = 100;
            buckets = new int[100];
            entries = new Point[100];
            ClearBuckets();
            ClearEntries();
        }

        private void ClearEntries()
        {
            for (int i = 0; i < SizeMass; i++)
            {
                entries[i] = new Point();
            }
        }
        private void ClearBuckets()
        {
            for (int i = 0; i < SizeMass; i++)
            {
                buckets[i] = -1;
            }
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int hash = GetHash(item.Key);
            int place = buckets[hash];
            if (place == -1) return false;
            Point temp = entries[place];
            Point Temp = new Point(item.Key, item.Value);
            do
            {
                if (temp.ToString() == Temp.ToString()) return true;
                if (temp.Next == -1) return false;
                temp = entries[temp.Next];
            } while (true);
        }
        public bool ContainsKey(TKey key)
        {
            int hash = GetHash(key);
            int place = buckets[hash];
            if (place == -1) return false;
            Point temp = entries[place];
            do
            {
                if (temp.Key.ToString() == key.ToString()) return true;
                if (temp.Next == -1) return false;
                temp = entries[temp.Next];
            } while (true);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        bool IEnumerator.MoveNext()
        {
            if (position++ < count) return true;
            return false;
        }
        object IEnumerator.Current
        {
            get { return entries[position]; }
        }
        void IEnumerator.Reset()
        {
            position = -1;
        }
        public int GetHash(object adres)
        {
            int hashcode = 0;
            double a = 0.6180339887;
            foreach (char s in adres.ToString()) hashcode += s;
            var p = Math.Truncate(hashcode * a);
            var t = (hashcode * a - p)*SizeMass ;
            return (int)t % SizeMass;
        }
        public bool Remove(TKey key)
        {
            int hash = GetHash(key);
            int place = buckets[hash];
            Point Temp = entries[place];
            do
            {
                if (Temp.Key.ToString() == key.ToString())
                {
                    for (int i = place + 1; i < count; i++)
                    {
                        entries[i - 1] = entries[i];
                        buckets[entries[i].HashCode]--;
                    }
                    return true;
                }
                if (Temp.Next == -1) return false;
                else Temp = entries[Temp.Next];
            } while (true);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Clear();
        }
        public object Clone()
        {
            Point[] Temp = new Point[SizeMass];
            int[] f = new int[SizeMass];
            for (int i = 0; i < SizeMass; i++)
            {
                Temp[i] = entries[i];
                f[i] = buckets[i];
            }
            return new DictionaryCommon<TKey, TValue>
            {
                count = this.count,
                buckets = f,
                entries = Temp,
                SizeMass = this.SizeMass
            };
        }
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
