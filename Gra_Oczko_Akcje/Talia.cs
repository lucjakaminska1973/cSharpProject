<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net;
using System.Runtime.CompilerServices;

namespace Oczko
{


    public class Talia : Karty
    {
      
        public static byte IleKart
        {
            get
            {
                return IleKart;
            }

            set
            {
                if (value == 52 || value == 24)
                {
                    IleKart = value;
                }
                else
                {
                    throw new ArgumentException("Możesz wybrać 52 lub 24");
                }

            }
        }
        
        public Karty[] wybrana_Talia;
    

        public Talia(byte IleKart)
        {
            wybrana_Talia = new Karty[IleKart];
        }

        public Karty[] GetTalia { get { return wybrana_Talia; } }


        public void Talia_Kreator()
        {
            foreach (Kolor k in Enum.GetValues(typeof(Kolor)))
            {
                int i = 0;
                foreach (Numer n in Enum.GetValues(typeof(Numer)))
                {
                    var karty = new Karty { Kolorek = k, Numerek = n };
                    wybrana_Talia[i] = karty;
                    i++;
                }
                if (IleKart == 52)
                {
                    foreach (DodatkoweNumery nd in Enum.GetValues(typeof(DodatkoweNumery)))
                    {
                        var karty = new Karty { Kolorek = k, DodatkoweNumerki = nd };
                        wybrana_Talia[i] = karty;
                        i++;
                    }

                }

            }

        }
    
    }

}


=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net;
using System.Runtime.CompilerServices;

namespace Gra_Oczko_Akcje
{
    public  class Karty
    {
        public enum Kolor
        {
            Kier, Karo, Pik, Trefl

        }
        public enum Numer
        {
            As = 1,
            Joker,
            Dama,
            Król,
            Dziewiątka = 9,
            Dziesiątka,
        }
        public enum DodatkoweNumery
        {
            dwójka = 2, trójka, czwórka, piątka,
            szóstka, siódemka, ósemka
        }
        public Karty kolorek { get; set; }
        public Karty numerek { get; set; }


    }

    public class Talia : Karty
    {

        public int ileKart { get; set; }
        public int IleKart(int v)
        {
            if (v == 24 || v == 52)
            {
                return ileKart = v;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    
    
        public Karty[] nowaTalia { get; private set; }
        //public Karty[] taliaWGrze { get { return nowaTalia; } }
       // private Karty[] wydane = new int[24,2];

        public Karty[] NowaTalia()
        {
            Karty[] nowaTalia = new Karty[ileKart];
            int i = 0;
            
            foreach (Karty k in Enum.GetValues(typeof(Kolor)) )
            {
                foreach (Karty n in Enum.GetValues(typeof(Numer)) )
                {
                        nowaTalia[i] = new Karty{ kolorek = k, numerek = n };
                    i++;
                }
                if (ileKart == 52)
                {
                        foreach (Karty nd in Enum.GetValues(typeof(DodatkoweNumery)))
                        {
                             nowaTalia[i] = new Karty { kolorek = k, numerek = nd };
                        i++;
                        }
                    
                }
                for (int j =0; j<i; j++ )
                {
                    Console.WriteLine(nowaTalia[j]);
                }
            
            }
            return nowaTalia;

        
        }

        
        public Talia GetKarta()
        {
            Random indexKarty = new Random();
            List<int> indexyWydane = new List<int>();
            for (int i = 0; i<ileKart; i++)
            {
                int index = indexKarty.Next(ileKart / 4);
                if(indexyWydane.Contains(index))
                {
                    --i;
                    continue;
                }
                else
                {
                    indexyWydane.Add(index);
                    return (Talia)nowaTalia[index];
                     
                }

            }
            

            return taliaWGrze
        }
        

        

        public interface IGraOczko
        {
            Wydanie_Karty();
        }
    }

    }

}
>>>>>>> 72374afe0538c0aad4a581ba5e43794a8e0735ad
