using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarGame
{

    interface Position
    {
        // Property signatures:
        int col
        {
            get;
            set;
        }

        int row
        {
            get;
            set;
        }

        // Property signatures:
        int col_d
        {
            get;
            set;
        }

        int row_d
        {
            get;
            set;
        }
    }

    class Cell : Position
    {
        public int myNum;
        int _col, _col_d, _row, _row_d;

        public Cell(int chiffreP)
        {
            myNum = chiffreP;
        }

        public int col
        {
            get
            {
                return _col;
            }

            set
            {
                _col = value;
            }
        }

        public int row
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
            }
        }

        public int col_d
        {
            get
            {
                return _col_d;
            }

            set
            {
                _col_d = value;
            }
        }

        public int row_d
        {
            get
            {
                return _row_d;
            }

            set
            {
                _row_d = value;
            }
        }

        public int getDistance()
        {
            return Math.Abs(_row_d - _row) + Math.Abs(_col_d - _col);
        }

    }
}
