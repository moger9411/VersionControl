using mintazh.Mappa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mintazh
{
    public partial class Form1 : Form
    {
        List<OlympicResult> results = new List<OlympicResult>();
        public Form1()
        {
            InitializeComponent();
            Fuggveny("Summer_olympic_Medals.csv");
            FillCombo();
            Scores();
        }

        private void Scores()
        {
            foreach (var x in results)
            {
                x.Position = WhatRes(x);
            }
        }

        private void FillCombo()
        {
            comboBox1.DataSource = (from x in results
                                    orderby x.Year
                                    select x.Year).Distinct().ToList();
        }

        private void Fuggveny(string fileName)
        {
            using (StreamReader sr = new StreamReader("Summer_olympic_Medals.csv",Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    OlympicResult result = new OlympicResult();
                    result.Year = Convert.ToInt32(line[0]);
                    int[] medalok = new int[3];
                    medalok[0] = Convert.ToInt32(line[5]);
                    medalok[1] = Convert.ToInt32(line[6]);
                    medalok[2] = Convert.ToInt32(line[7]);
                    result.Medals = medalok;
                    result.Country = line[3];
                    results.Add(result);
                }
            }

        }
        private int WhatRes(OlympicResult result)
        {
            int counter = 0;
            var eredmeny = from x in results
                           where x.Year == result.Year && x.Country != result.Country
                           select x;
            foreach (var x in eredmeny)
            {
                if (x.Medals[0] > result.Medals[0])
                {
                    counter++;
                }
                if (x.Medals[0] == result.Medals[0] && x.Medals[1] > result.Medals[1])
                {
                    counter++;
                }
                if (x.Medals[0] == result.Medals[0] && x.Medals[1] == result.Medals[1] && x.Medals[2] > result.Medals[2])
                {
                    counter++;
                }
            }
            return counter + 1;
        }
    }
}
