using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Filsparande
{
    public partial class Form1 : Form
    {
        private List<PlayerScore> scores;

        public Form1()
        {
            InitializeComponent();
            scores = new List<PlayerScore>();
            LoadScores();
            PrintScoreList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PlayerScore temp = new PlayerScore(txtName.Text, int.Parse( txtPoints.Text));
            scores.Add(temp);
            SortList();
            PrintScoreList();
            SaveScores();
            txtName.Text = "";
            txtPoints.Text = "";
        }

        private void PrintScoreList()
        {
            lblList.Text = "";
            foreach(PlayerScore s in scores)
            {
                lblList.Text += s.Name + "\t" + s.Score + "\r\n";
            }
        }

        private void SortList()
        {
            
        }

        private void SaveScores()
        {
            StreamWriter sw = new StreamWriter("hs.txt");

            foreach(PlayerScore s in scores)
            {
                sw.WriteLine(s.Name + ";" + s.Score + "\r\n");
            }
            sw.Close();
        }

        private void LoadScores()
        {
            StreamReader sr = new StreamReader("hs.txt");

            string row;
            while((row= sr.ReadLine()) != null)
            {
                if (row.IndexOf(";") > -1)
                {
                    string[] rowParts = row.Split(';');

                    if (rowParts.Length > 1)
                    {
                        PlayerScore temp = new PlayerScore(rowParts[0], int.Parse(rowParts[1]));
                        scores.Add(temp);
                    }
                }
            }
            sr.Close();
        }
    }
}
