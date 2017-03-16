namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelChart = new System.Windows.Forms.Panel();
            this.plotArea = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtBoxCoeff = new System.Windows.Forms.TextBox();
            this.numUpDownPGrade = new System.Windows.Forms.NumericUpDown();
            this.tmrPlotRatio = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numUpDownSmoothness = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plotArea)).BeginInit();
            this.gbControls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPGrade)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSmoothness)).BeginInit();
            this.SuspendLayout();
            // 
            // panelChart
            // 
            this.panelChart.Controls.Add(this.plotArea);
            this.panelChart.Location = new System.Drawing.Point(12, 12);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(710, 432);
            this.panelChart.TabIndex = 0;
            // 
            // plotArea
            // 
            this.plotArea.BackColor = System.Drawing.Color.Transparent;
            this.plotArea.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.plotArea.ChartAreas.Add(chartArea3);
            this.plotArea.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.plotArea.Legends.Add(legend3);
            this.plotArea.Location = new System.Drawing.Point(0, 0);
            this.plotArea.Name = "plotArea";
            this.plotArea.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Polynomial";
            this.plotArea.Series.Add(series3);
            this.plotArea.Size = new System.Drawing.Size(710, 432);
            this.plotArea.TabIndex = 0;
            this.plotArea.Text = "Polynomial plotter";
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnRefresh);
            this.gbControls.Controls.Add(this.btnPlot);
            this.gbControls.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbControls.Location = new System.Drawing.Point(490, 450);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(232, 79);
            this.gbControls.TabIndex = 1;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(6, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(220, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh chart";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlot.Location = new System.Drawing.Point(6, 19);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(220, 23);
            this.btnPlot.TabIndex = 0;
            this.btnPlot.Text = "Plot polynomial";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblGrade);
            this.groupBox1.Controls.Add(this.txtBoxCoeff);
            this.groupBox1.Controls.Add(this.numUpDownPGrade);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coefficients: ";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(6, 23);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(43, 15);
            this.lblGrade.TabIndex = 2;
            this.lblGrade.Text = "Grade:";
            // 
            // txtBoxCoeff
            // 
            this.txtBoxCoeff.Location = new System.Drawing.Point(83, 48);
            this.txtBoxCoeff.Name = "txtBoxCoeff";
            this.txtBoxCoeff.Size = new System.Drawing.Size(143, 23);
            this.txtBoxCoeff.TabIndex = 1;
            // 
            // numUpDownPGrade
            // 
            this.numUpDownPGrade.Location = new System.Drawing.Point(83, 19);
            this.numUpDownPGrade.Name = "numUpDownPGrade";
            this.numUpDownPGrade.Size = new System.Drawing.Size(143, 23);
            this.numUpDownPGrade.TabIndex = 0;
            // 
            // tmrPlotRatio
            // 
            this.tmrPlotRatio.Tick += new System.EventHandler(this.tmrPlotRatio_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numUpDownSmoothness);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(250, 450);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // numUpDownSmoothness
            // 
            this.numUpDownSmoothness.Location = new System.Drawing.Point(106, 19);
            this.numUpDownSmoothness.Name = "numUpDownSmoothness";
            this.numUpDownSmoothness.Size = new System.Drawing.Size(120, 23);
            this.numUpDownSmoothness.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Smoothness:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 536);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.panelChart);
            this.Name = "MainForm";
            this.Text = "Polynomial plotter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plotArea)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPGrade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSmoothness)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotArea;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxCoeff;
        private System.Windows.Forms.NumericUpDown numUpDownPGrade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Timer tmrPlotRatio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownSmoothness;
    }
}

