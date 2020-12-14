using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AstarGame
{

    class AStarSolve
    {
        public List<StateNode> listNode = new List<StateNode>();
        public List<int> frontier = new List<int>();  // node id on frontier
        public List<int> H_front = new List<int>();   // node heuristic on frontier
        public List<int> num_move = new List<int>();  // which number to move in each step in final solution
        public StateNode start, target;

        static int step = 1;

        public AStarSolve(int[] startList, int[] targetList)
        {
            if (startList.Length != 9 || targetList.Length != 9)
            { }
            else
            {
                start = new StateNode(startList);
                start.parent = -1; // no parent
                string result = null;
                for (int i = 0; i < 8; i++)
                {
                    result += start.numbers[i].ToString() + ",";
                }
                result += start.numbers[8].ToString();
                Console.WriteLine("Start node:  " + result);
                target = new StateNode(targetList);
                listNode.Add(start);
                int f = start.h;
                H_front.Add(f);
                frontier.Add(0); // the first node is on the frontier
                start.g = 0;                               
            }
        }

        public Boolean solve()
        {
            return explore_Tree(0);
        }

        public Boolean explore_Tree(int nodeIndexP)
        {            
            StateNode start = new StateNode(listNode[nodeIndexP].numbers);
            // ==== Printing numbers of this node ====
            string result = null;
            for (int i = 0; i < 8; i++)
            {
                result += listNode[nodeIndexP].numbers[i].ToString() + ",";
            }
            result += listNode[nodeIndexP].numbers[8].ToString();
            // Console.WriteLine("Start explore for node: " + nodeIndexP.ToString() + " =: " + result);
            // ========

            // Using the position of number 0, choose the possible neighbers
            int index = Array.IndexOf(start.numbers, 0);
            int[] tryNumbers = new int[9];
            
            int row = index / 3;  // Row of number 0
            int col = index % 3;  // Col of number 0
            StateNode tryNode;
            int chosenNode = nodeIndexP;
            int heuristic = 100;

            int tryRow, tryCol;

            tryRow = row - 1; tryCol = col;
            {                
                if (tryRow > -1)
                {
                    Array.Copy(start.numbers, tryNumbers, 9);
                    tryNumbers[index] = tryNumbers[3 * tryRow + tryCol];
                    tryNumbers[3 * tryRow + tryCol] = 0;
                    tryNode = new StateNode(tryNumbers);
                    tryNode.parent = nodeIndexP;
                    tryNode.g = listNode[nodeIndexP].g + step;
                    int chsId = listNode.FindIndex(f => f.checkSum == tryNode.checkSum);
                    if ((chsId >= 0))  // in the closed set
                    {
                        if (listNode[chsId].isXpanded)
                        {
                            // in closed set so ignore
                        }
                        else if ((listNode[chsId].h + listNode[chsId].g) <= (tryNode.h + tryNode.g)) // in open set, but higher g cost
                        {
                            // in closed set, but with higher g cost
                        }
                        else
                        {
                            listNode[chsId].g = tryNode.g;
                            listNode[chsId].parent = tryNode.parent;
                            int idFind = frontier.FindIndex(p => p == chsId);
                            H_front[idFind] = tryNode.h + tryNode.g;
                        }
                    }
                    else
                    {
                        listNode.Add(tryNode);
                        chosenNode = listNode.Count - 1;
                        frontier.Add(listNode.Count - 1);  // the new node is on the frontier
                        int a = tryNode.h + tryNode.g;
                        H_front.Add(a);
                        heuristic = tryNode.h + tryNode.g;
                    }   
                }
            }

            
            tryRow = row + 1; tryCol = col;
            {                
                if (tryRow < 3)
                {                   
                    Array.Copy(start.numbers, tryNumbers, 9);
                    tryNumbers[index] = tryNumbers[3 * tryRow + tryCol];
                    tryNumbers[3 * tryRow + tryCol] = 0;
                    tryNode = new StateNode(tryNumbers);
                    tryNode.parent = nodeIndexP;
                    tryNode.g = listNode[nodeIndexP].g + step;
                    int chsId = listNode.FindIndex(f => f.checkSum == tryNode.checkSum);
                    if ((chsId >= 0))  // in the closed set
                    {
                        if ( listNode[chsId].isXpanded)
                        { 
                            // in closed sed, so ignore
                        }
                        else if ((listNode[chsId].h + listNode[chsId].g) <= (tryNode.h + tryNode.g)) // in open set, but higher g cost
                        {
                            // in closed set, but with higher g cost
                        }
                        else
                        {
                            listNode[chsId].g = tryNode.g;
                            listNode[chsId].parent = tryNode.parent;
                            int idFind = frontier.FindIndex(p => p == chsId);
                            H_front[idFind] = tryNode.h + tryNode.g;
                        }
                    }
                    else 
                    {
                        listNode.Add(tryNode);
                        chosenNode = listNode.Count - 1;
                        frontier.Add(listNode.Count - 1);  // the new node is on the frontier
                        int a = tryNode.h + tryNode.g;
                        H_front.Add(a);
                        heuristic = tryNode.h + tryNode.g;
                    }   
                }
            }
            

            tryRow = row; tryCol = col - 1;
            {
               
                if (tryCol > -1)
                {                   
                    Array.Copy(start.numbers, tryNumbers, 9);
                    tryNumbers[index] = tryNumbers[3 * tryRow + tryCol];
                    tryNumbers[3 * tryRow + tryCol] = 0;
                    tryNode = new StateNode(tryNumbers);
                    tryNode.g = listNode[nodeIndexP].g + step;
                    tryNode.parent = nodeIndexP;
                    int chsId = listNode.FindIndex(f => f.checkSum == tryNode.checkSum);
                    if ((chsId >= 0))  // in the closed set
                    {
                        if (listNode[chsId].isXpanded)
                        {
                            // in closed sed, so ignore
                        }
                        else if ((listNode[chsId].h + listNode[chsId].g) <= (tryNode.h + tryNode.g)) // in open set, but higher g cost
                        {
                            // in closed set, but with higher g cost
                        }
                        else
                        {
                            listNode[chsId].g = tryNode.g;
                            listNode[chsId].parent = tryNode.parent;
                            int idFind = frontier.FindIndex(p => p == chsId);
                            H_front[idFind] = tryNode.h + tryNode.g;
                        }
                    }
                    else
                    {
                        listNode.Add(tryNode);
                        chosenNode = listNode.Count - 1;
                        frontier.Add(listNode.Count - 1);  // the new node is on the frontier
                        int a = tryNode.h + tryNode.g;
                        H_front.Add(a);
                        heuristic = tryNode.h + tryNode.g;
                    }                    
                }
            }


            tryRow = row; tryCol = col + 1;
            {
                
                if (tryCol < 3)
                {                    
                    Array.Copy(start.numbers, tryNumbers, 9);
                    tryNumbers[index] = tryNumbers[3 * tryRow + tryCol];
                    tryNumbers[3 * tryRow + tryCol] = 0;
                    tryNode = new StateNode(tryNumbers);
                    tryNode.parent = nodeIndexP;
                    tryNode.g = listNode[nodeIndexP].g + step;
                    int chsId = listNode.FindIndex(f => f.checkSum == tryNode.checkSum);
                    if ((chsId >= 0))  // in the closed set
                    {
                        if (listNode[chsId].isXpanded)
                        {
                            // in closed sed, so ignore
                        }
                        else if ((listNode[chsId].h + listNode[chsId].g) <= (tryNode.h + tryNode.g)) // in open set, but higher g cost
                        {
                            // in closed set, but with higher g cost
                        }
                        else
                        {
                            listNode[chsId].g = tryNode.g;
                            listNode[chsId].parent = tryNode.parent;
                            int idFind = frontier.FindIndex(p => p == chsId);
                            H_front[idFind] = tryNode.h + tryNode.g;
                        }
                    }
                    else
                    {
                        listNode.Add(tryNode);
                        chosenNode = listNode.Count - 1;
                        frontier.Add(listNode.Count - 1);  // the new node is on the frontier
                        int a = tryNode.h + tryNode.g;
                        H_front.Add(a);
                        heuristic = tryNode.h + tryNode.g;
                    }   
                }
            }

            listNode[nodeIndexP].isXpanded = true;

            int idxFind = frontier.FindIndex(p => p == nodeIndexP);
            frontier.RemoveAt(idxFind);
            H_front.RemoveAt(idxFind);

            {
                int Hmin = H_front.Min();
                var minimumValueIndex = H_front.IndexOf(H_front.Min());

                chosenNode = frontier[minimumValueIndex];
                if (listNode[chosenNode].h == 0)
                { return true; }
                else
                {
                    if (listNode.Count > 3000) 
                    { return false; }
                    else 
                    { return (true && explore_Tree(chosenNode)); }
                }
            }
        }

        public void printResult(ref List<int> output)
        {
            int curId = listNode.Count - 1;
            while (listNode[curId].parent >= 0)
            {
                int parentId = listNode[curId].parent;
                int index = Array.IndexOf(listNode[parentId].numbers, 0);
                output.Add(listNode[curId].numbers[index]);
                curId = parentId;
            }
        }
    }
}
