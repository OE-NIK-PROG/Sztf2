using System;
using System.Collections;
using System.Collections.Generic;

namespace zh_gyak
{
    public delegate void ArValtozasDelegate();

    public class Termek
    {
        private int ar;
        private string nev;
        
        public event ArValtozasDelegate ArValtozes;
        public int Ar { get { return ar; } set { ar = value; ArValtozasFigyelo(); } }
        public string Nev { get { return nev; } set { nev = value; ArValtozasFigyelo(); } }

        public void ArValtozasFigyelo() 
        {
            ArValtozes?.Invoke();
        }
        
        public void Felvetel()
        {
            Console.WriteLine("Termeket felvetelre kerult!");
        }

        public override string ToString()
        {
            return $"{Nev} >> {Ar}";
        }
    }
}
