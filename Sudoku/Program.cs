using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Program
    {
        //check of sudoku klopt

        //rij check voor nummer

        //kolom check voor nummer

        //3x3 grid check -> waar die blokken starten

        static void Main(string[] args)
        {
            /* input inlezen
             * als 2darray of lijkt iets anders slimmers?
             * We moeten random 1 van de 9 3x3 blokken uitkiezen -> hardcode index van die 3x3 boxen?
             * een lokale max definieren en doorheen itereren?
             * check of swap mogelijk is met die lokale max, anders verhoog je die lokale max
             * random walk met random uitgekozen blok
             */
            Final run = new Final();
            
        }

     
    }
    
    public class Final
    {
        public static List<string> GridL;
        public static Dictionary<int, bool> Locatie;
        public static Dictionary<int, Tuple<int, int>> Dict;
        public static string[] values;

        string gridNumber;

       

        public void PossibleValues(int[,] startGrid)
        {
            List<Tuple<int, int>> variableCells = new List<Tuple<int, int>>();
            List<List<int>> valuesCells = new List<List<int>>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (startGrid[i, j] == 0)
                    {
                        variableCells.Add(new Tuple<int, int>(i, j));
                        valuesCells.Add(Enumerable.Range(1, 9).ToList());
                    }
                }
            }
            Locatie = new Dictionary<int, bool>(); //Voor statisch plekken (swapbaar of niet swapbaar)
                                                     // (plek, true als swapbaar)

        }

        public int[,] ReadInput()
        {
            string[] values = Console.ReadLine().Split();

            int[,] grid = new int[9, 9]; //indexering is van 0,0 tm 8,8

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    grid[x, y] = int.Parse(values[x * 9 + y]);
                }

            }
            return grid;
        }

        /* static void ILS()
 {
     GridL = values.ToList();
     Locatie = new Dictionary<int, bool>(); //Voor statisch plekken (swapbaar of niet swapbaar)
                                            // (plek, true als swapbaar)
     int loc = 0;
     int u = 0;

     foreach (string str in GridL)
     {
         if (Int32.Parse(str) == 0)
         {
             Locatie.Add(loc, true);

         }

         else { Locatie.Add(loc, false); }
         loc += 1;
     }

     Dict = new Dictionary<int, Tuple<int, int>>(); // 0 - 80 --> (x,y) | Voor rijen en kolommen
     int t = -1;


     for (int n = 0; n < 9; n++)
     {
         for (int m = 0; m < 9; m++)
         {
             t += 1;
             Tuple<int, int> tup = new Tuple<int, int>(m, n);
             Dict.Add(t, tup);

             if (u == 81)
             {
                 u = 0;
             }
             u += 1;

         }



     }

     List<int> myValues = new List<int>() { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
     foreach (int i in myValues)
     {
         List<string> Block = Blok(GridL, i); //Maakt lijst van waardes blok
         List<int> l = NullenVervangen(Block); //Vervangt 0 voor cijfers 1-9 in lijst
         List<int> ll = Cijfer(i); //Maakt lijst van locaties blok
         int k = 0;
         foreach (int jklj in ll) //Teken getallen i.p.v. nullen
         {
             GridL[jklj] = l[k].ToString();
             {
                 int j = Dict[jklj].Item1;
                 int i = Dict[jklj].Item2;
             }
             k += 1;
         }
     }
     int LOCALMAXIMA = 0;
     int S = 10; //random stappen

     //begin algoritme
     int i = 0;
     while (true)
     {
         i += 1;
         int j = RandomBlok();
         if (LOCALMAXIMA < 5) //swappen tot lokale maxima
         {
             if (SwapList(j, Locatie, GridL, Dict) == 0) //geen optimale swap gevonden
             { LOCALMAXIMA += 1; };
         }

         else
         {
             if (Functions.CalcAll(Dict, GridL) == 0)
             {

                 break;

             }

             else
             {
                 for (int s = 0; s < S; s++)
                 {
                     j = RandomBlok();
                     RandomWalkSwap(j, Locatie, GridL, Dict);
                 }
                 LOCALMAXIMA = 0;
             }
         }

     }
 }*/

        List<int> Cijfer(int a) //geeft alle locaties van de waarden van een blok van 3x3
        {
            List<int> Cijfer = new List<int>();

            Cijfer.Add(a);
            Cijfer.Add(a + 1);
            Cijfer.Add(a + 2);
            Cijfer.Add(a + 9);
            Cijfer.Add(a + 10);
            Cijfer.Add(a + 11);
            Cijfer.Add(a + 18);
            Cijfer.Add(a + 19);
            Cijfer.Add(a + 20);

            return Cijfer;

        }

        List<string> Blok(List<string> volledigeGrid, int a) //geeft alle waarden van een blok van 3x3
        {
            List<string> BlokLijst = new List<string>();

            BlokLijst.Add(volledigeGrid[a]);
            BlokLijst.Add(volledigeGrid[a + 1]);
            BlokLijst.Add(volledigeGrid[a + 2]);
            BlokLijst.Add(volledigeGrid[a + 9]);
            BlokLijst.Add(volledigeGrid[a + 10]);
            BlokLijst.Add(volledigeGrid[a + 11]);
            BlokLijst.Add(volledigeGrid[a + 18]);
            BlokLijst.Add(volledigeGrid[a + 19]);
            BlokLijst.Add(volledigeGrid[a + 20]);

            return BlokLijst;

        }
        Random r = new Random();
        int RandomBlok() //zorgt dat één van de negen random blokken gekozen wordt
        {

            List<int> myValues = new List<int>() { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
            int index = r.Next(myValues.Count);
            return myValues[index];
        }


        List<int> Random() //genereert lijst van random getallen van 1-9 
        {
            List<int> randomList = new List<int>();
            List<int> uniqueItemsList = new List<int>();
            while (uniqueItemsList.Count < 9)
            {
                randomList.Add(r.Next(1, 10));
                uniqueItemsList = randomList.Distinct().ToList();
            }
            return uniqueItemsList;
        }





        List<int> NullenVervangen(List<string> strList)//vervangt alle legen vakjes (0'en) voor getallen van 1-9 z.d.d. elk vakje binnen een blok van 3x3 een uniek getal bevat
        {
            List<int> intLijst = new List<int>();
            List<int> randomLijst = Random();
            int z = 0;
            foreach (string s in strList)
            {
                intLijst.Add(int.Parse(s));
                if (intLijst[z] != 0)
                {
                    randomLijst.Remove(intLijst[z]);

                }
                z += 1;
            }
            for (int i = 0; i < strList.Count; i++)
            {
                if (intLijst[i] != 0)
                {
                    randomLijst.Remove(intLijst[i]);

                }

                if (intLijst[i] == 0)
                {
                    int index = r.Next(randomLijst.Count - 1);
                    intLijst[i] = randomLijst[index];
                    randomLijst.Remove(intLijst[i]);
                }

            }
            return intLijst;




        }

        List<Tuple<int, int>> MogelijkeSwaps(List<int> Lijst)//geeft alle mogelijke swaps
        {
            List<Tuple<int, int>> swapLijst = new List<Tuple<int, int>>();
            for (int i = 0; i < Lijst.Count; i++)
            {

                for (int j = 1; j < Lijst.Count; j++)
                {
                    if (Lijst[i] == Lijst[j]) { }
                    else
                    {
                        Tuple<int, int> Tup = new Tuple<int, int>(Int32.Parse(Lijst[i].ToString()), Int32.Parse(Lijst[j].ToString()));
                        swapLijst.Add(Tup);
                    }
                }
            }
            return swapLijst;


        }
        static void Swap(List<string> lijstSwap, int idx1, int idx2) //voert swap uit
        {
            string temp = lijstSwap[idx1];
            lijstSwap[idx1] = lijstSwap[idx2];
            lijstSwap[idx2] = temp;
        }

        int SwapList(int X, Dictionary<int, bool> locaties, List<string> GridL, Dictionary<int, Tuple<int, int>> Dict) //geeft aan of er een optimale swap is die de evaluatiewaarde verbeterd
        {
            List<int> LocatieBlok = Cijfer(X);
            List<int> Lijst2 = new List<int>();
            foreach (int x in LocatieBlok)
            {
                if (locaties[x] == true)
                {

                    Lijst2.Add(x);
                }
            }

            List<Tuple<int, int>> Swaps = MogelijkeSwaps(Lijst2);

            int Waarde = int.MaxValue;
            Tuple<int, int> besteSwap = null;

            foreach (Tuple<int, int> tup in Swaps)
            {
                int evWaardeVoorSwap = Functions.Waarde(tup.Item1, Dict, GridL) + Functions.Waarde(tup.Item2, Dict, GridL); //Waarde voor swap
                Swap(GridL, tup.Item1, tup.Item2);
                int evWaardeNaSwap = Functions.Waarde(tup.Item1, Dict, GridL) + Functions.Waarde(tup.Item2, Dict, GridL); //Waarde na swap


                if (evWaardeNaSwap < evWaardeVoorSwap && evWaardeNaSwap < Waarde)
                {
                    Waarde = evWaardeNaSwap;
                    besteSwap = tup;
                }
                Swap(GridL, tup.Item1, tup.Item2);

            }


            if (besteSwap != null) { Swap(GridL, besteSwap.Item1, besteSwap.Item2); return 1; } //Als er een optimale wissel is --> dan wissel + return 1
            else { return 0; } //Geen optimale wissel --> return 0

        }
        int RandomWalkSwap(int X, Dictionary<int, bool> Locatie, List<string> GridL, Dictionary<int, Tuple<int, int>> Dict) //voert random walk uit
        {
            List<int> locatieBlok = Cijfer(X);
            List<int> Lijst2 = new List<int>();
            foreach (int x in locatieBlok)
            {
                if (Locatie[x] == true)
                {

                    Lijst2.Add(x);
                }
            }
            List<Tuple<int, int>> swapLijst = MogelijkeSwaps(Lijst2);

            int evWaardeNu = int.MaxValue;
            Tuple<int, int> besteSwap = null;
            foreach (Tuple<int, int> tup in swapLijst)
            {
                int WaardeVoorSwap = Functions.Waarde(tup.Item1, Dict, GridL) + Functions.Waarde(tup.Item2, Dict, GridL);
                Swap(GridL, tup.Item1, tup.Item2);
                int WaardeNaSwap = Functions.Waarde(tup.Item1, Dict, GridL) + Functions.Waarde(tup.Item2, Dict, GridL);
                if (WaardeNaSwap < evWaardeNu)
                {
                    evWaardeNu = WaardeNaSwap;
                    besteSwap = tup;
                }
                Swap(GridL, tup.Item1, tup.Item2);

            }
            if (besteSwap != null) { Swap(GridL, besteSwap.Item1, besteSwap.Item2); return 1; }
            else { return 0; }

        }

    
    }


    class Functions
    {

        public static int CalcAll(Dictionary<int, Tuple<int, int>> D, List<string> GridL)
        { //geeft evaluatiewaarde voor complete grid 
            int all = 0;
            for (int i = 0; i < 81; i++)
            {
                all += Waarde(i, D, GridL);

            }

            return all;
        }

        public static int Waarde(int x, Dictionary<int, Tuple<int, int>> D, List<string> GridL)
        { //geeft evaluatiewaarde voor rijen en kolommen
            int L = D[x].Item1;
            int R = D[x].Item2;

            int MeestHorizontalePositie = R * 9;
            int MeestVerticalePositie = L;
            int Waardes = 0;
            List<string> Check = new List<string>();
            List<string> Check2 = new List<string>();
            Check.Add(GridL[MeestHorizontalePositie]);
            Check2.Add(GridL[MeestVerticalePositie]);
            for (int w = 1; w < 9; w++)
            {
                if (Check.Contains(GridL[MeestHorizontalePositie + w]))
                {
                    Waardes += 1;
                }
                else { Check.Add(GridL[MeestHorizontalePositie + w]); }


                if (Check2.Contains(GridL[MeestVerticalePositie + (w * 9)]))
                {
                    Waardes += 1;
                }
                else { Check2.Add(GridL[MeestVerticalePositie + (w * 9)]); }



            }
            return Waardes;


        }





    }

}
