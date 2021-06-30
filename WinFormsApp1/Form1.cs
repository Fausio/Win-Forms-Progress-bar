using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var progress = new Progress<int>(x => 
            {
                label1.Text = x.ToString() + " %";
                progressBar1.Value = x;

                
               
            });


          await Task.Run( ()=> loop(100, progress));
            label1.Text = "complite";
        }


        void loop(int length,IProgress<int> progress)
        {
            for (int i = 0; i < length; i++)
            {
                Thread.Sleep(100);
                var percents = (i * 100) / length;
                progress.Report(percents);
                
            }
        }
    }
}
