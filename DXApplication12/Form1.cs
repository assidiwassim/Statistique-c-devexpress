using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace DXApplication12
{
    public partial class Form1 : RibbonForm
    {
        public static string[] data;
        public static string[] data1;
        public static int[] obm;
        public static float[] fd;
        public static float[] cfd;
        public static float mediane;
        public static float moy;
        public static float var;
        public static float std;
        public Form1()
        {
            InitializeComponent();
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data.GetDataFromTxtFile(out data, @"C:\Users\assid\Desktop\Exercice\modalite.txt");


            for (int i = 0; i < data.Length - 1; i++)
            {
                listView1.Items.Add(data[i].ToString());
            }
           Data.GetDataFromExcelFile(out data1, @"C:\Users\assid\Desktop\Exercice\observation.xlsx");

            for (int i = 0; i < data1.Length - 1; i++)
            {
                listView2.Items.Add(data1[i].ToString());
            }
           DataAnalysis.tri(data);
            DataAnalysis.tri(data1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DataAnalysis.ObservationByModality(ref obm, data, data1);
            DataAnalysis.FrequenceDistribution(ref fd, data, data1);
            DataAnalysis.CumFrepDistribution(ref cfd, data, data1);
            DataAnalysis.Mediane1(ref mediane, data, data1);
            DataAnalysis.Mean(ref moy, data1);
            DataAnalysis.Var(ref var, data, data1);
            DataAnalysis.std(ref std, data, data1);
            for (int i = 0; i < data.Length - 1; i++)
            {
                label12.Text += data[i] + "==>\n\n";
                label16.Text += data[i] + "==>\n\n";
                label17.Text += data[i] + "==>\n\n";
                label13.Text += obm[i] + "\n\n";
                label18.Text += fd[i] + "\n\n";
                label19.Text += cfd[i] + "\n\n";
            }
            label20.Text = mediane.ToString();
            label21.Text = moy.ToString();
            label22.Text = var.ToString();
            label23.Text = std.ToString();
        }
    }
}
