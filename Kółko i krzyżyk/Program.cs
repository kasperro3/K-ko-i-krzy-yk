using System;
using System.Windows.Forms;

namespace Kółko_i_krzyżyk
{
    static class Program
    {
        public static TextBox textBox;
        static public Button[] buttonList = new Button[11];
        public static Label[] labelList = new Label[2];
        public static bool turn = true;
        public static bool win;
        static int xWin = 0, oWin = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // set buttons default state
            for (int i = 1; i < 10; i++)
            {
                Button button = buttonList[i];
                button.Image = Properties.Resources.white;
                button.Enabled = true;
                button.Tag = "null";
            }

        }

        // check for win
        public static void Check()
        {

            if (buttonList[1].Tag != "null" && buttonList[2].Tag != "null" && buttonList[3].Tag != "null" &&
                buttonList[4].Tag != "null" && buttonList[5].Tag != "null" && buttonList[6].Tag != "null" &&
                buttonList[7].Tag != "null" && buttonList[8].Tag != "null" && buttonList[9].Tag != "null")
            {
                LockAll();
                textBox.Text = "Remis!";
                buttonList[10].Image = Properties.Resources.white;
            }

            //Horizontals
            WinCheck(buttonList[1], buttonList[2], buttonList[3], turn);
            WinCheck(buttonList[4], buttonList[5], buttonList[6], turn);
            WinCheck(buttonList[7], buttonList[8], buttonList[9], turn);

            //Verticals
            WinCheck(buttonList[1], buttonList[4], buttonList[7], turn);
            WinCheck(buttonList[2], buttonList[5], buttonList[8], turn);
            WinCheck(buttonList[3], buttonList[6], buttonList[9], turn);

            //Diagonals
            WinCheck(buttonList[1], buttonList[5], buttonList[9], turn);
            WinCheck(buttonList[3], buttonList[5], buttonList[7], turn);
        }

        // check who won
        public static void WinCheck(Button A, Button B, Button C, bool recTurn)
        {
            if (A.Tag == "x" && B.Tag == "x" && C.Tag == "x" && recTurn == true)
            {
                LockAll();
                textBox.Text = "Zwycięża: ";
                buttonList[10].Image = Properties.Resources.cross;
                win = true;
                xWin =+ 1;
                labelList[0].Text = "X : " + xWin;
            }
            else if (A.Tag == "o" && B.Tag == "o" && C.Tag == "o" && recTurn == false)
            {
                LockAll();
                textBox.Text = "Zwycięża: ";
                buttonList[10].Image = Properties.Resources.circle;
                win = true;
                oWin =+ 1;
                labelList[1].Text = "O : " + oWin;
            }
        }

        // lock all buttons if someone won
        public static void LockAll()
        {
            for (int i = 1; i < 11; i++)
            {
                buttonList[i].Enabled = false;
            }
        }

        // unlock all buttons if new game has begun
        public static void UnLockAll()
        {
            for (int i = 1; i < 11; i++)
            {
                buttonList[i].Enabled = true;
            }
        }
    }
}
