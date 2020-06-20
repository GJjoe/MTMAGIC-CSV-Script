using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
//using WindowsInput;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
      //  string path;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



      



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult result = MessageBox.Show("Script will run 5 seconds after clicking Yes.\n\nPlease navigate to the desired text entry field" +
                " within 5 seconds of clicking Yes to this prompt\n\nClick No to abort running this script.", "Run Script?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    if (textBox1.Text != "")
                    {
                        //   var sim = new InputSimulator();
                        string whole_file = System.IO.File.ReadAllText(textBox1.Text);

                        // Split into lines.
                        if (checkBox1.Checked)
                        {
                            whole_file = whole_file.Replace(Environment.NewLine, "\n");
                        }
                        whole_file = whole_file.Replace("\n", "~");
                        whole_file = whole_file.Replace(",", "~");
                        whole_file = whole_file.Replace("#", "+{RIGHT}");
                        whole_file = whole_file.Replace("$", ",");
                        whole_file = whole_file.Replace("@", "{F10}");
                        whole_file = whole_file.Replace("&", "{DOWN}");

                        System.Threading.Thread.Sleep(5000);

                        if (checkBox2.Checked)
                        {

                            foreach (char s in whole_file)
                            {
                                SendKeys.SendWait(s.ToString());
                                System.Threading.Thread.Sleep(Convert.ToInt32(numericUpDown1.Value));
                            }
                        }

                        else
                        {
                            SendKeys.SendWait(whole_file);
                        }
                        
                        //SendKeys.SendWait(whole_file);

                        MessageBox.Show("Scripting Complete");
                        // SendKeys.SendWait("+{RIGHT}");
                        //sim.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.RSHIFT, WindowsInput.Native.VirtualKeyCode.RIGHT);
                        //System.Threading.Thread.Sleep(5000);
                        //  SendKeys.Send("HELLO");

                    }
                   
                }
                
            }
            else 
            {
                MessageBox.Show("No Script Selected","Warning",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        void SendKeysSlowly(string whole_file)
        {
            foreach (char s in whole_file)
            {
                SendKeys.SendWait(s.ToString());
                System.Threading.Thread.Sleep(50);

            }
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
             //openFileDialog1.InitialDirectory = "c:\\" ;
    openFileDialog1.Filter = "Database files (*.csv)|*.csv" ;
    openFileDialog1.FilterIndex = 0;
    openFileDialog1.RestoreDirectory = true ;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
    {
                var path = openFileDialog1.FileName;
                MessageBox.Show("Loaded Script: \n" + path,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = path;
   
            }
        }
    }
}
