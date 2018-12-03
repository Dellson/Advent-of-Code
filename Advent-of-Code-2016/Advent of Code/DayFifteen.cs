using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DayFifteen
    {
        private Tuple<int, int>[] discs; //<ilość, obecna> (pozycja)
        private int time;
        private int startTime;
        private int ballPosition = 0;

        public DayFifteen(int time)
        {
            this.time = time;
            startTime = time;
            //  zadanie 1
            /*discs = new Tuple<int, int>[6] {    new Tuple<int, int>(13, 11),
                                                new Tuple<int, int>(5, 0),
                                                new Tuple<int, int>(17, 11),
                                                new Tuple<int, int>(3, 0),
                                                new Tuple<int, int>(7, 2),
                                                new Tuple<int, int>(19, 17)};*/

            //  zadanie 2
            discs = new Tuple<int, int>[7] {    new Tuple<int, int>(13, 11),
                                                new Tuple<int, int>(5, 0),
                                                new Tuple<int, int>(17, 11),
                                                new Tuple<int, int>(3, 0),
                                                new Tuple<int, int>(7, 2),
                                                new Tuple<int, int>(19, 17),
                                                new Tuple<int, int>(11, 0)};
        }

        public void puzzleOne()
        {
            Stopwatch sw = Stopwatch.StartNew();

            while (ballPosition < discs.Length)
            {
                //Console.Write("Disc 0: " + discs[0].Item2 + " Disc 1: " + discs[1].Item2 + " | time = " + time + "| ball = " + ballPosition + "\n");
                ballPosition += discs[ballPosition].Item2 != 0 ? -ballPosition : 1;

                for (int i = 0; i < discs.Length; ++i)
                {
                    discs[i] = new Tuple<int, int>(discs[i].Item1, (discs[i].Item2 + 1) % discs[i].Item1);
                }
                time++;
            }
            sw.Stop();
            Console.WriteLine("time: " + (time - discs.Length - 1) + " | computing time: " + sw.Elapsed);
            //time pokazuje w którym momencie piłka doleciała do końca;
            //rozpoczęła lot (discs.Length - 1) czasu wcześniej a (discs.Length) temu dosięgnęła pierwszego dysku 
        }
    }
}