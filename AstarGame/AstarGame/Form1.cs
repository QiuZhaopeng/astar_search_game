using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Threading;

namespace AstarGame
{
    public partial class Form1 : Form
    {
        GameCtrl myGC;
        int flag = 0;
        List<int> output;
        public Boolean  isSolved;
        public List<System.Windows.Forms.PictureBox> pbList = new List<System.Windows.Forms.PictureBox>(); 
        public Form1()
        {
            myGC = new GameCtrl();
            
            InitializeComponent();
            // List initialization
            pbList.Add(this.pictureBox1);  // Number 1
            pbList.Add(this.pictureBox2);  // Number 2
            pbList.Add(this.pictureBox3);  // Number 3  
            pbList.Add(this.pictureBox4);  // Number 4
            pbList.Add(this.pictureBox5);  // Number 5
            pbList.Add(this.pictureBox6);  // Number 6
            pbList.Add(this.pictureBox7);  // Number 7
            pbList.Add(this.pictureBox8);  // Number 8
            for (int i = 0; i < 8; i++)
            {
                if (myGC.cellList[i].myNum == 0)
                { }
                else
                {
                    int x = myGC.cellList[i].row;
                    int y = myGC.cellList[i].col;
                    this.tableLayoutPanel1.Controls.Remove(pbList[i]);
                    this.tableLayoutPanel1.Controls.Add(pbList[i], y, x);   // here, PbList[i] is synchronized with cellList[i]                    
                }
            }
            isSolved = false;

            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox8_Click(object sender, EventArgs e) // cell of number8
        {
            move(7);
        }
        private void pictureBox7_Click(object sender, EventArgs e) // cell of number7
        {
            move(6);
        }
        private void pictureBox6_Click(object sender, EventArgs e) // cell of number6
        {
            move(5);
        }
        private void pictureBox5_Click(object sender, EventArgs e) // cell of number5
        {
            move(4);
        }
        private void pictureBox4_Click(object sender, EventArgs e) // cell of number4
        {
            move(3);
        }

        private void pictureBox3_Click(object sender, EventArgs e) // cell of number1
        {
            move(2);
        }

        private void pictureBox2_Click(object sender, EventArgs e) // cell of number1
        {
            move(1);
        }

        private void pictureBox1_Click(object sender, EventArgs e) // cell of number1
        {
            move(0);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                if (flag == 1 && isSolved)
                {
                    foreach (int item in output)
                    {                        
                        if (item > 0) { move(item - 1); }
                        Thread.Sleep(750);
                    }
                }
                if (flag == 0)
                {
                    AStarSolve myAS;
                    myAS = new AStarSolve(myGC.listStart, myGC.listTarget);
                    isSolved = myAS.solve();
                    if (isSolved)
                    {
                        output = new List<int>();
                        myAS.printResult(ref output);
                        output.Reverse();
                        MessageBox.Show("Solved!!!");
                    }
                    else
                    { MessageBox.Show("Cannot be solved!!!"); }
                    flag++;
                }

            }
        }


        private void checkIfIWin()
        {
            int totalDistance = 0;
            foreach (Cell item in myGC.cellList)
            {
                totalDistance += item.getDistance();
            }
            if (totalDistance == 0)
            {
                MessageBox.Show("YOU WIN!!!!!");
            }
        }

        private void move(int cellId)
        {
            int i = cellId;
            int oldX = myGC.cellList[i].row; int oldY = myGC.cellList[i].col;
            if (((oldX - myGC.emptyX) * (oldX - myGC.emptyX) + (oldY - myGC.emptyY) * (oldY - myGC.emptyY)) == 1)
            {
                myGC.cellList[i].row = myGC.emptyX;
                myGC.cellList[i].col = myGC.emptyY;
                myGC.emptyX = oldX;
                myGC.emptyY = oldY;
                this.tableLayoutPanel1.Controls.Remove(pbList[i]);
                this.tableLayoutPanel1.Controls.Add(pbList[i], myGC.cellList[i].col, myGC.cellList[i].row);
                // Console.WriteLine(i.ToString()+"-th cell is at: " + myGC.emptyX.ToString() + ", " + myGC.emptyY.ToString());
                checkIfIWin();
                this.Update();
            }
            // Console.WriteLine("Empty cell is at: " + myGC.emptyX.ToString() + ", " + myGC.emptyY.ToString());
        }
    }
}
