using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        int VK_A = 0x41;
        int VK_B = 0x42;
        int VK_SPACE = 0x20;
        int VK_W = 0x57;
        int VK_S = 0x53;
        int VK_D = 0x44;
        bool flag = false;


        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr
        
        private static void FocusProcess()
        {
            IntPtr hWnd; //change this to IntPtr
            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.ProcessName == "FortniteClient-Win64-Shipping")
                {
                    hWnd = pr.MainWindowHandle; //use it as IntPtr not int
                    ShowWindow(hWnd, 3);
                    SetForegroundWindow(hWnd); //set to topmost
                }
            }
        }

       

        public static void KeyPress(int keycode, int delay = 0)
        {
            keybd_event((byte)keycode, 0x0, 0, 0);// presses
            System.Threading.Thread.Sleep(delay);
            keybd_event((byte)keycode, 0x0, 2, 0); //releases
        }

        public static void KeyDown(int keycode, int delay = 0)
        {
            keybd_event((byte)keycode, 0x0, 0, 0);// presses
            
        }

        public static void KeyUp(int keycode, int delay = 0)
        {
            
            keybd_event((byte)keycode, 0x0, 2, 0); //releases
        }
        public Form1()
        {
            InitializeComponent();

            // Set the background image
            this.BackgroundImage = Properties.Resources.fortnite_myths_and_mortals_battle_pass_1920x1080_56228b70b9b3;

            // Set the background image layout mode
            this.BackgroundImageLayout = ImageLayout.Stretch;

            button3.BackColor = Color.Red;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FocusProcess();
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value * 1000);
            timer1.Enabled = true;

            button3.BackColor = Color.Green;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button3.BackColor = Color.Red;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton2.Checked) {
                FocusProcess();
                KeyDown(VK_B, 0);
                KeyPress(VK_SPACE, 500);
                KeyPress(VK_SPACE, 500);
                KeyUp(VK_B, 0);
            }
            else if (radioButton1.Checked)
            {
                if (flag == false)
                {
                    KeyPress(VK_W, 300);
                    KeyPress(VK_D, 300);
                    KeyPress(VK_S, 300);
                    KeyPress(VK_A, 300);
                }
                if (flag == true)
                {
                    
                    KeyPress(VK_D, 300);
                    KeyPress(VK_W, 300);
                    KeyPress(VK_A, 300);
                    KeyPress(VK_S, 300);
                    
                }

                flag = !flag;




            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
          
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Stop();
                timer1.Interval = Convert.ToInt32(numericUpDown1.Value * 1000);
                timer1.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 120;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 10;
        }
    }
}
