using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarGame
{
    class StateNode
    {
        public int[] numbers;

        public int parent;
        public int h;  // goal heuristics
        public int g;  // path cost
        public int checkSum;
        public Boolean isXpanded;

        public StateNode()
        {
            InitializeComponent();
        }

        public StateNode(int[] initParamP)
        {
            InitializeComponent();
            setStateParam(initParamP);
            string result = null;
            for (int i = 0; i < 8; i++)
            {
                result += numbers[i].ToString() + ",";
            }
            result += numbers[8].ToString();
           // Console.WriteLine("New node with numbers: " + result);
            calcHeuristics();
            //Console.WriteLine("New node heuristic : " + h);
        }

        void InitializeComponent()
        {
            isXpanded = false;
            numbers = new int[9] {0, 1, 2, 3, 4, 5, 6, 7, 8};
        }

        public void setStateParam(int[] paramP)
        {
            if (paramP.Length > 8)
            {
                for (int i = 0; i < 9; i++)
                {
                    numbers[i] = paramP[i];
                }
            }
        }

        public void calcHeuristics()
        {
            int heuristic = 0;
            int chs = 0;
            for (int i = 0; i < 9; i++)
            {
                heuristic += Math.Abs(numbers[i] / 3 - i / 3) * numbers[i];
                heuristic += Math.Abs(numbers[i] % 3 - i % 3) * numbers[i];
                chs += numbers[i] + chs * 10;
            }
            h = heuristic*100; // 
            checkSum = chs;
        }

    }
}
