﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    class PlacesV : IComparable
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public PlacesV()
        {
            Name = "";
        }
        public PlacesV(string name)
        {
            Name = name;
        }

        public int CompareTo(object obj)
        {
            if (obj.ToString() == this.ToString()) return 0;
            if (obj.ToString().Length > this.ToString().Length) return 1;
            return -1;
        }

        public override string ToString()
        {
            return name;
        }
    }
    class Region : PlacesV //Кол-во мужчин во всех регионах
    {
        int numberMans = 0;
        int numberCities = 0;
        public int NumberCities
        {
            get { return numberCities; }
            set { numberCities = value; }
        }
        public int NumberMans
        {
            get { return numberMans; }
            set
            {
                if (value < 0) Console.WriteLine("Мужчин не может быть меньше 0");
                else numberMans = value;
            }
        }
        public Region() : base()
        {

        }
        public Region(string name) : base(name)
        {

        }
        public Region(string name, int mans) : base(name)
        {
            NumberMans = mans;
        }
        public Region(string name, int mans, int cit) : base(name)
        {
            NumberMans = mans;
            numberCities = cit;
        }
        public override string ToString()
        {
            return Name + " Область";
        }
    }

    class City : PlacesV // кол-во горожан во всех регионах 
    {
        int citizens = 0;
        public int Citizens
        {
            get { return citizens; }
            set
            {
                if (value < 0) Console.WriteLine("Горожан не может быть меньше 0");
                else citizens = value;
            }
        }
        public City() : base()
        {

        }
        public City(string name) : base(name)
        {
        }
        public City(string name, int Countcitizens) : base(name)
        {
            Citizens = Countcitizens;
        }
        public override string ToString()
        {
            return "Город " + Name;
        }
    }

    class Megapolis : PlacesV
    {
        private int countFabriks;
        public int CounFabriks
        {
            get { return countFabriks; }
            set { countFabriks = value; }
        }
        public Megapolis() : base()
        {

        }
        public Megapolis(string name) : base(name)
        {
        }
        public Megapolis(string name, int t) : base(name)
        {
            countFabriks = t;
        }
        public override string ToString()
        {
            return "Мегаполис " + Name;
        }
    }

    class Adres : PlacesV
    {
        int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public Adres() : base()
        {

        }
        public Adres(string name) : base(name)
        {

        }
        public Adres(string name, int index1) : base(name)
        {
            index = index1;
        }
        public PlacesV BasePlace
        {
            get { return new PlacesV("Неизвестный город"); }
        }
        public override string ToString()
        {
            return "Адрес: " + Name;
        }
    }
}
