
using System;
using System.Windows.Forms;

namespace Kółko_i_krzyżyk
{
    public partial class Form1 : Form
    {
        public char PlayerChar, OpponentChar;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            Program.buttonList[0] = resetButton;
            Program.buttonList[1] = button1;
            Program.buttonList[2] = button2;
            Program.buttonList[3] = button3;
            Program.buttonList[4] = button4;
            Program.buttonList[5] = button5;
            Program.buttonList[6] = button6;
            Program.buttonList[7] = button7;
            Program.buttonList[8] = button8;
            Program.buttonList[9] = button9;
            Program.buttonList[10] = button10;
            Program.textBox = textBox1;
            Program.labelList[0] = label1;
            Program.labelList[1] = label2;

            Program.buttonList[10].Enabled = false;

            button10.Image = Properties.Resources.cross;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Program.turn == true)
            {
                button.Image = Properties.Resources.cross;
                button.Tag = "x";
            }
            else
            {
                button.Image = Properties.Resources.circle;
                button.Tag = "o";
            }

            button.Enabled = false;

            
            Program.Check();
            Program.turn = !Program.turn;

            if (Program.turn && !Program.win) button10.Image = Properties.Resources.cross;
            else if (!Program.turn && !Program.win) button10.Image = Properties.Resources.circle;


            if (Program.turn && !Program.win) button10.Image = Properties.Resources.cross;
            else if (!Program.turn && !Program.win) button10.Image = Properties.Resources.circle;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            for(int i = 1; i < 10; i++)
            {
                Button button = Program.buttonList[i];
                button.Image = Properties.Resources.white;
                button.Enabled = true;
                button.Tag = "null";
            }

            textBox1.Text = "Tura: ";
            if (Program.turn && !Program.win) button10.Image = Properties.Resources.cross;
            else if (!Program.turn) button10.Image = Properties.Resources.circle;

            Program.win = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "X : 0";
            label2.Text = "O : 0";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
