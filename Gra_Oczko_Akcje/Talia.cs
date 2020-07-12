using System;
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


