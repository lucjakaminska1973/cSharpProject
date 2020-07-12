using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oczko
{
    public struct Punkty
    {
        public byte Total { get; set; }
    }

    public class Karty_W_Grze : Talia
    {
        public Karty_W_Grze(byte ileKart) : base( IleKart) 
        {
            DodacKarte = "T";
            indexyWydane = new List<byte>();
            suma = new Punkty();
            kartyGracza = GetTalia;
        }

        public static byte Punkty_Asa
        {
            get
            {
                return Punkty_Asa;
            }
            set
            {
                if (value==1 || value == 11)
                {
                    Punkty_Asa = value;
                }
                else
                {
                    throw new ArgumentException("Możesz wybrać 1 lub 11");
                }
            }

        }
        protected Punkty suma ;
        protected Karty[] kartyGracza;
        private byte index;
        private readonly List<byte> indexyWydane;
      
       
        private byte Index
        {
            get
            {
                return Index;
            }
            set
            {
                if (value > 0 && value < IleKart)
                {
                    Index = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public static string DodacKarte
        {
            private get { return DodacKarte; }

            set
            {
                if (value == "T" || value == "t" || value == "n" || value == "N")
                {
                    DodacKarte = value;
                }
                else
                {
                    throw new ArgumentException("spróbuj jeszcze raz ");
                }
            }
        }
        
        public string Zapytaj()
        {
            Console.WriteLine("Chcesz dobrać kartę?");
            DodacKarte = Console.ReadLine();
            return DodacKarte;
        }
        public void Wypisz_Punkty()
        {
            Console.WriteLine($"masz {suma} punktów");
        }
        

        public byte WylosujKarte()
        {
            Random indexKarty = new Random();
            index = (byte)indexKarty.Next(IleKart);

            return index;

        }
        public byte Za_ile_As()
        {
            Console.WriteLine("Masz Asa. Podaj ile chcesz dodać punktów ( 1 lub 11)");
            Punkty_Asa = byte.Parse(Console.ReadLine());
            return Punkty_Asa;
        }

        

        public byte Punkty_W_Grze()
        {
            //List<byte> indexyWydane = new List<byte>();
            while (DodacKarte == "T" || DodacKarte == "t")
            { 
            //    if (dodacKarte == "T" || dodacKarte == "t")
            //{
                
                do
                {
                  index = WylosujKarte();
                } while (indexyWydane.Contains(index));
                
                indexyWydane.Add(index);

                if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                    || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
                {
                    byte v = (byte)kartyGracza[index].Numerek;
                    Wypisz_Karte(kartyGracza[index], index);
                    if ( v== 1)
                    {
                       v= Za_ile_As();
                    }
                    suma.Total += v;
                    Wypisz_Punkty(suma);
                    //return suma.Total;
                }
                else
                {
                    Wypisz_Karte(kartyGracza[index], index);
                    suma.Total += (byte)kartyGracza[index].DodatkoweNumerki;
                    Wypisz_Punkty(suma);
                }
                Zapytaj();
            }
            if ( DodacKarte == "n" || DodacKarte == "N")
            {
                indexyWydane.Clear();
                return suma.Total;
            }
            else
            {
                throw new ArgumentException("powtórz co mam zrobić");
            }



        }
        public void Wypisz_Karte(Karty karty, byte index)
        {
            if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                    || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
            {


                Console.Write(karty.Numerek);
                Console.Write("  ");
                Console.WriteLine(karty.Kolorek);
            }
            else
            {
                Console.Write(karty.DodatkoweNumerki);
                Console.Write("  ");
                Console.WriteLine(karty.Kolorek);
            }
        }
        public void Wypisz_Punkty(Punkty punkty) => Console.WriteLine($"Masz teraz {suma.Total} punktów");




    }
}
