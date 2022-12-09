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


            


            

        }
        static void ReadInput()
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
        }
    }
}
