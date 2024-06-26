﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualer
{
    internal class SortEnghineBubble : iSortEngine
    {
        private bool _sorted = false;
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void DoWork(int[] TheArray_In, Graphics g_In, int MaxVal_In)
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;

            while (!_sorted) 
            {
                for (int i = 0; i < TheArray.Count() - 1; i++) 
                {
                    if (TheArray[i] > TheArray[i + 1]) 
                    {
                        Swap(i, i + 1);
                    }

                }
                _sorted = IsSorted();
            }
        }

        private void Swap(int i, int p)
        {
          int temp = TheArray[i];
            TheArray[i] = TheArray[p];
            TheArray[p] = temp;

           g.FillRectangle(BlackBrush, i, 0, 1, MaxVal);
           g.FillRectangle(BlackBrush, p, 0, 1, MaxVal);


            g.FillRectangle(BlackBrush, i, MaxVal - TheArray[i], 1, MaxVal);
            g.FillRectangle(WhiteBrush, p, MaxVal - TheArray[p], 1, MaxVal);

        }

        private bool IsSorted()
        {
            for (int i = 0; i < TheArray.Count() - 1; i++)
            {
                if (TheArray[i] > TheArray[i + 1]) return false;
            }
            return true;
        }
    }
}
