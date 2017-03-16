namespace Scoala
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.claseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaClasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeClasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaClasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eleviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapoarteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diriginticlaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaPeClaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clasaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NrElevi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diriginteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scoalaDataSet = new Scoala.ScoalaDataSet();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idElevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eleviBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claseTableAdapter = new Scoala.ScoalaDataSetTableAdapters.ClaseTableAdapter();
            this.tableAdapterManager = new Scoala.ScoalaDataSetTableAdapters.TableAdapterManager();
            this.eleviTableAdapter = new Scoala.ScoalaDataSetTableAdapters.EleviTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoalaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eleviBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.claseToolStripMenuItem,
            this.eleviToolStripMenuItem,
            this.rapoarteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // claseToolStripMenuItem
            // 
            this.claseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaClasaToolStripMenuItem,
            this.stergeClasaToolStripMenuItem,
            this.modificaClasaToolStripMenuItem});
            this.claseToolStripMenuItem.Name = "claseToolStripMenuItem";
            this.claseToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.claseToolStripMenuItem.Text = "Clase";
            // 
            // adaugaClasaToolStripMenuItem
            // 
            this.adaugaClasaToolStripMenuItem.Name = "adaugaClasaToolStripMenuItem";
            this.adaugaClasaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.adaugaClasaToolStripMenuItem.Text = "Adaugă clasă";
            this.adaugaClasaToolStripMenuItem.Click += new System.EventHandler(this.adaugaClasaToolStripMenuItem_Click);
            // 
            // stergeClasaToolStripMenuItem
            // 
            this.stergeClasaToolStripMenuItem.Name = "stergeClasaToolStripMenuItem";
            this.stergeClasaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.stergeClasaToolStripMenuItem.Text = "Șterge clasă";
            this.stergeClasaToolStripMenuItem.Click += new System.EventHandler(this.stergeClasaToolStripMenuItem_Click);
            // 
            // modificaClasaToolStripMenuItem
            // 
            this.modificaClasaToolStripMenuItem.Name = "modificaClasaToolStripMenuItem";
            this.modificaClasaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.modificaClasaToolStripMenuItem.Text = "Modifică clasă";
            this.modificaClasaToolStripMenuItem.Click += new System.EventHandler(this.modificaClasaToolStripMenuItem_Click);
            // 
            // eleviToolStripMenuItem
            // 
            this.eleviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaElevToolStripMenuItem,
            this.stergeElevToolStripMenuItem,
            this.modificaElevToolStripMenuItem});
            this.eleviToolStripMenuItem.Name = "eleviToolStripMenuItem";
            this.eleviToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.eleviToolStripMenuItem.Text = "Elevi";
            // 
            // adaugaElevToolStripMenuItem
            // 
            this.adaugaElevToolStripMenuItem.Name = "adaugaElevToolStripMenuItem";
            this.adaugaElevToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.adaugaElevToolStripMenuItem.Text = "Adaugă elev";
            // 
            // stergeElevToolStripMenuItem
            // 
            this.stergeElevToolStripMenuItem.Name = "stergeElevToolStripMenuItem";
            this.stergeElevToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.stergeElevToolStripMenuItem.Text = "Șterge elev";
            // 
            // modificaElevToolStripMenuItem
            // 
            this.modificaElevToolStripMenuItem.Name = "modificaElevToolStripMenuItem";
            this.modificaElevToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.modificaElevToolStripMenuItem.Text = "Modifica elev";
            // 
            // rapoarteToolStripMenuItem
            // 
            this.rapoarteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diriginticlaseToolStripMenuItem,
            this.mediaPeClaseToolStripMenuItem});
            this.rapoarteToolStripMenuItem.Name = "rapoarteToolStripMenuItem";
            this.rapoarteToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.rapoarteToolStripMenuItem.Text = "Rapoarte";
            // 
            // diriginticlaseToolStripMenuItem
            // 
            this.diriginticlaseToolStripMenuItem.Name = "diriginticlaseToolStripMenuItem";
            this.diriginticlaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.diriginticlaseToolStripMenuItem.Text = "Diriginti-clase";
            // 
            // mediaPeClaseToolStripMenuItem
            // 
            this.mediaPeClaseToolStripMenuItem.Name = "mediaPeClaseToolStripMenuItem";
            this.mediaPeClaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediaPeClaseToolStripMenuItem.Text = "Media pe clase";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(803, 257);
            this.splitContainer1.SplitterDistance = 349;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clasaDataGridViewTextBoxColumn,
            this.NrElevi,
            this.diriginteDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.claseBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(349, 257);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // clasaDataGridViewTextBoxColumn
            // 
            this.clasaDataGridViewTextBoxColumn.DataPropertyName = "Clasa";
            this.clasaDataGridViewTextBoxColumn.HeaderText = "Clasa";
            this.clasaDataGridViewTextBoxColumn.Name = "clasaDataGridViewTextBoxColumn";
            // 
            // NrElevi
            // 
            this.NrElevi.DataPropertyName = "NrElevi";
            this.NrElevi.HeaderText = "Nr. Elevi";
            this.NrElevi.Name = "NrElevi";
            // 
            // diriginteDataGridViewTextBoxColumn
            // 
            this.diriginteDataGridViewTextBoxColumn.DataPropertyName = "Diriginte";
            this.diriginteDataGridViewTextBoxColumn.HeaderText = "Diriginte";
            this.diriginteDataGridViewTextBoxColumn.Name = "diriginteDataGridViewTextBoxColumn";
            // 
            // claseBindingSource
            // 
            this.claseBindingSource.DataMember = "Clase";
            this.claseBindingSource.DataSource = this.scoalaDataSet;
            // 
            // scoalaDataSet
            // 
            this.scoalaDataSet.DataSetName = "ScoalaDataSet";
            this.scoalaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idElevDataGridViewTextBoxColumn,
            this.numeDataGridViewTextBoxColumn,
            this.mediaDataGridViewTextBoxColumn,
            this.clasaDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.eleviBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(450, 257);
            this.dataGridView2.TabIndex = 0;
            // 
            // idElevDataGridViewTextBoxColumn
            // 
            this.idElevDataGridViewTextBoxColumn.DataPropertyName = "IdElev";
            this.idElevDataGridViewTextBoxColumn.HeaderText = "ID Elev";
            this.idElevDataGridViewTextBoxColumn.Name = "idElevDataGridViewTextBoxColumn";
            // 
            // numeDataGridViewTextBoxColumn
            // 
            this.numeDataGridViewTextBoxColumn.DataPropertyName = "Nume";
            this.numeDataGridViewTextBoxColumn.HeaderText = "Nume";
            this.numeDataGridViewTextBoxColumn.Name = "numeDataGridViewTextBoxColumn";
            // 
            // mediaDataGridViewTextBoxColumn
            // 
            this.mediaDataGridViewTextBoxColumn.DataPropertyName = "Media";
            this.mediaDataGridViewTextBoxColumn.HeaderText = "Media";
            this.mediaDataGridViewTextBoxColumn.Name = "mediaDataGridViewTextBoxColumn";
            // 
            // clasaDataGridViewTextBoxColumn1
            // 
            this.clasaDataGridViewTextBoxColumn1.DataPropertyName = "Clasa";
            this.clasaDataGridViewTextBoxColumn1.HeaderText = "Clasa";
            this.clasaDataGridViewTextBoxColumn1.Name = "clasaDataGridViewTextBoxColumn1";
            // 
            // eleviBindingSource
            // 
            this.eleviBindingSource.DataMember = "Elevi";
            this.eleviBindingSource.DataSource = this.scoalaDataSet;
            // 
            // claseTableAdapter
            // 
            this.claseTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClaseTableAdapter = this.claseTableAdapter;
            this.tableAdapterManager.EleviTableAdapter = this.eleviTableAdapter;
            this.tableAdapterManager.UpdateOrder = Scoala.ScoalaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // eleviTableAdapter
            // 
            this.eleviTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 281);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Școala";
            this.Load += new System.EventHandler(this.Scoala_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoalaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eleviBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem claseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaClasaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeClasaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaClasaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eleviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapoarteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diriginticlaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaPeClaseToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private ScoalaDataSet scoalaDataSet;
        private System.Windows.Forms.BindingSource claseBindingSource;
        private ScoalaDataSetTableAdapters.ClaseTableAdapter claseTableAdapter;
        private ScoalaDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private ScoalaDataSetTableAdapters.EleviTableAdapter eleviTableAdapter;
        private System.Windows.Forms.BindingSource eleviBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NrElevi;
        private System.Windows.Forms.DataGridViewTextBoxColumn diriginteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idElevDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mediaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasaDataGridViewTextBoxColumn1;
    }
}

