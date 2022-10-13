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
                }
            }
        }
    }
}
