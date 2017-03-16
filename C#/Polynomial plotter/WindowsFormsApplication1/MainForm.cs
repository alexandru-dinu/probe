using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<string> coeff;

        int i;

        double x = -100;

        private void _getCoeff()
        {
            string _tempS = txtBoxCoeff.Text;
            coeff = new List<string>(_tempS.Split(new string[] { ",",";","/" }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            numUpDownPGrade.Minimum = 0;
            numUpDownPGrade.Maximum = 4;
            numUpDownPGrade.Increment = 1;

            numUpDownSmoothness.Minimum = 1;
            numUpDownSmoothness.Maximum = 10;
            numUpDownSmoothness.Increment = 1;
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            _getCoeff();
            i = coeff.Count;
            tmrPlotRatio.Start();

            numUpDownPGrade.Enabled = false;
            numUpDownSmoothness.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tmrPlotRatio.Stop();

            plotArea.Update();

            numUpDownPGrade.Enabled = true;
            numUpDownSmoothness.Enabled = true;
        }

        private void tmrPlotRatio_Tick(object sender, EventArgs e)
        {
            this.plotArea.Series["Polynomial"].Points.AddXY(
                x,
                Convert.ToDouble(coeff.ElementAt(i - 4)) * Math.Pow(x, 3) +
                Convert.ToDouble(coeff.ElementAt(i - 3)) * Math.Pow(x, 2) +
                Convert.ToDouble(coeff.ElementAt(i - 2)) * x +
                Convert.ToDouble(coeff.ElementAt(i - 1)));

            x += Convert.ToDouble(numUpDownSmoothness.Value);
        }
    }
}
