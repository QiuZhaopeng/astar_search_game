using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarGame
{
    class GameCtrl
    {
        public Cell[] cellList;
        public int[] listStart = new int[9] { 0, 2, 1, 5, 3, 4, 6, 8, 7 };
        public int[] listTarget = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; 
        public int emptyX, emptyY;  // the empty cell row and col

        public GameCtrl()
        {
            initCells();
        }

        public void initCells()
        {
            cellList = new Cell[8];
            int cellId = 0;
            for (int i = 0; i < 3; i++)   // row
            {
                for (int j = 0; j < 3; j++)  // col
                {
                    int index = i * 3 + j;
                    int chiffre = listStart[index];
                    if (chiffre == 0)
                    {
                        emptyX = i;
                        emptyY = j;
                        Console.WriteLine("Init Empty cell is at: " + emptyX.ToString() + ", " + emptyY.ToString());
                    }
                    else
                    {
                        cellId = chiffre - 1;
                        cellList[cellId] = new Cell(chiffre);  // the index-th cell has the Chiffre of start list
                        cellList[cellId].row = i;
                        cellList[cellId].col = j;
                        cellList[cellId].row_d = chiffre / 3;
                        cellList[cellId].col_d = chiffre % 3;                        
                    }
                    
                }
            }
        }
    }

}
