namespace PD_Projesi.UI
{
    partial class MainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlHeadingCenter = new System.Windows.Forms.Panel();
            this.lblHeadingCenter = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.pieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDurumIcindekiler = new System.Windows.Forms.Label();
            this.lblDurumSekil = new System.Windows.Forms.Label();
            this.lblDurumTablo = new System.Windows.Forms.Label();
            this.lblDurumEkler = new System.Windows.Forms.Label();
            this.lblDurumKaynak = new System.Windows.Forms.Label();
            this.btnDetailes = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDurumKelime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDurumTirnak = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlDetailes = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dgvHatalar = new System.Windows.Forms.DataGridView();
            this.Detailes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLoading = new System.Windows.Forms.Label();
            this.picInfo1 = new System.Windows.Forms.PictureBox();
            this.picInfo3 = new System.Windows.Forms.PictureBox();
            this.picInfo5 = new System.Windows.Forms.PictureBox();
            this.picInfo7 = new System.Windows.Forms.PictureBox();
            this.picInfo2 = new System.Windows.Forms.PictureBox();
            this.picInfo4 = new System.Windows.Forms.PictureBox();
            this.picInfo6 = new System.Windows.Forms.PictureBox();
            this.pnlHeading.SuspendLayout();
            this.pnlHeadingCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).BeginInit();
            this.pnlDetailes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHatalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo6)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeading
            // 
            this.pnlHeading.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlHeading.Controls.Add(this.btnMinimize);
            this.pnlHeading.Controls.Add(this.btnExit);
            this.pnlHeading.Controls.Add(this.pnlHeadingCenter);
            this.pnlHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeading.Location = new System.Drawing.Point(0, 0);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(866, 49);
            this.pnlHeading.TabIndex = 0;
            this.pnlHeading.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseDown);
            this.pnlHeading.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseMove);
            this.pnlHeading.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Teal;
            this.btnMinimize.Location = new System.Drawing.Point(801, 13);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(25, 25);
            this.btnMinimize.TabIndex = 8;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Teal;
            this.btnExit.Location = new System.Drawing.Point(831, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(23, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlHeadingCenter
            // 
            this.pnlHeadingCenter.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlHeadingCenter.Controls.Add(this.lblHeadingCenter);
            this.pnlHeadingCenter.Location = new System.Drawing.Point(299, 0);
            this.pnlHeadingCenter.Name = "pnlHeadingCenter";
            this.pnlHeadingCenter.Size = new System.Drawing.Size(279, 49);
            this.pnlHeadingCenter.TabIndex = 1;
            this.pnlHeadingCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseDown);
            this.pnlHeadingCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseMove);
            this.pnlHeadingCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseUp);
            // 
            // lblHeadingCenter
            // 
            this.lblHeadingCenter.AutoSize = true;
            this.lblHeadingCenter.Font = new System.Drawing.Font("Cairo", 18.75F, System.Drawing.FontStyle.Bold);
            this.lblHeadingCenter.ForeColor = System.Drawing.Color.White;
            this.lblHeadingCenter.Location = new System.Drawing.Point(29, 0);
            this.lblHeadingCenter.Name = "lblHeadingCenter";
            this.lblHeadingCenter.Size = new System.Drawing.Size(228, 47);
            this.lblHeadingCenter.TabIndex = 0;
            this.lblHeadingCenter.Text = "Tez Kontrol Sistemi";
            this.lblHeadingCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseDown);
            this.lblHeadingCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseMove);
            this.lblHeadingCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeading_MouseUp);
            // 
            // lblLocation
            // 
            this.lblLocation.ForeColor = System.Drawing.Color.DarkGray;
            this.lblLocation.Location = new System.Drawing.Point(248, 86);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(582, 37);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "//Lütfen kontrol etmek istediğniz tezin PDF dosyası ekleyiniz.";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cairo SemiBold", 15.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dosya :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(248, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 4);
            this.panel3.TabIndex = 5;
            // 
            // btnImport
            // 
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnImport.Location = new System.Drawing.Point(160, 91);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(28, 34);
            this.btnImport.TabIndex = 0;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnDelete.Location = new System.Drawing.Point(203, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 34);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.ForeColor = System.Drawing.Color.Transparent;
            this.btnControl.Location = new System.Drawing.Point(18, 153);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(812, 45);
            this.btnControl.TabIndex = 2;
            this.btnControl.Text = "Kontrol Et";
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // pieChart
            // 
            this.pieChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.pieChart.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.BackSecondaryColor = System.Drawing.Color.Transparent;
            legend2.BorderColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Cairo Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Cairo Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pieChart.Legends.Add(legend2);
            this.pieChart.Location = new System.Drawing.Point(9, 270);
            this.pieChart.Name = "pieChart";
            this.pieChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.BackSecondaryColor = System.Drawing.Color.Transparent;
            series2.BorderColor = System.Drawing.Color.Transparent;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Cairo Light", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "s1";
            this.pieChart.Series.Add(series2);
            this.pieChart.Size = new System.Drawing.Size(231, 299);
            this.pieChart.TabIndex = 9;
            this.pieChart.Text = "chart1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Cairo", 16.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hataların Dağılımı :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Cairo", 16.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(434, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 37);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tezin Kontrolleri :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(293, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 37);
            this.label5.TabIndex = 12;
            this.label5.Text = "İçindekiler :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(606, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 37);
            this.label6.TabIndex = 13;
            this.label6.Text = "Şekiller Listesi : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(293, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 37);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tablolar Listesi : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(606, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 37);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ekler Listesi : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(293, 389);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 37);
            this.label9.TabIndex = 16;
            this.label9.Text = "Kaynaklar :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDurumIcindekiler
            // 
            this.lblDurumIcindekiler.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumIcindekiler.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDurumIcindekiler.Location = new System.Drawing.Point(388, 277);
            this.lblDurumIcindekiler.Name = "lblDurumIcindekiler";
            this.lblDurumIcindekiler.Size = new System.Drawing.Size(187, 37);
            this.lblDurumIcindekiler.TabIndex = 17;
            this.lblDurumIcindekiler.Text = "İşlenir ..";
            this.lblDurumIcindekiler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDurumSekil
            // 
            this.lblDurumSekil.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumSekil.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDurumSekil.Location = new System.Drawing.Point(739, 279);
            this.lblDurumSekil.Name = "lblDurumSekil";
            this.lblDurumSekil.Size = new System.Drawing.Size(133, 37);
            this.lblDurumSekil.TabIndex = 18;
            this.lblDurumSekil.Text = "İşlenir ..";
            this.lblDurumSekil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDurumTablo
            // 
            this.lblDurumTablo.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumTablo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDurumTablo.Location = new System.Drawing.Point(427, 333);
            this.lblDurumTablo.Name = "lblDurumTablo";
            this.lblDurumTablo.Size = new System.Drawing.Size(154, 37);
            this.lblDurumTablo.TabIndex = 19;
            this.lblDurumTablo.Text = "İşlenir ..";
            this.lblDurumTablo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDurumEkler
            // 
            this.lblDurumEkler.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumEkler.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDurumEkler.Location = new System.Drawing.Point(721, 333);
            this.lblDurumEkler.Name = "lblDurumEkler";
            this.lblDurumEkler.Size = new System.Drawing.Size(142, 37);
            this.lblDurumEkler.TabIndex = 20;
            this.lblDurumEkler.Text = "İşlenir ..";
            this.lblDurumEkler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDurumKaynak
            // 
            this.lblDurumKaynak.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumKaynak.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDurumKaynak.Location = new System.Drawing.Point(387, 389);
            this.lblDurumKaynak.Name = "lblDurumKaynak";
            this.lblDurumKaynak.Size = new System.Drawing.Size(175, 37);
            this.lblDurumKaynak.TabIndex = 21;
            this.lblDurumKaynak.Text = "İşlenir ..";
            this.lblDurumKaynak.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDetailes
            // 
            this.btnDetailes.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnDetailes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailes.Font = new System.Drawing.Font("Cairo", 13.25F, System.Drawing.FontStyle.Bold);
            this.btnDetailes.ForeColor = System.Drawing.Color.Transparent;
            this.btnDetailes.Location = new System.Drawing.Point(299, 506);
            this.btnDetailes.Name = "btnDetailes";
            this.btnDetailes.Size = new System.Drawing.Size(555, 41);
            this.btnDetailes.TabIndex = 3;
            this.btnDetailes.Text = "Hataların Ayrıntılarını Göster";
            this.btnDetailes.UseVisualStyleBackColor = false;
            this.btnDetailes.Click += new System.EventHandler(this.btnDetailes_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(262, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 307);
            this.panel4.TabIndex = 23;
            // 
            // lblDurumKelime
            // 
            this.lblDurumKelime.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumKelime.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDurumKelime.Location = new System.Drawing.Point(697, 389);
            this.lblDurumKelime.Name = "lblDurumKelime";
            this.lblDurumKelime.Size = new System.Drawing.Size(166, 37);
            this.lblDurumKelime.TabIndex = 25;
            this.lblDurumKelime.Text = "İşlenir ..";
            this.lblDurumKelime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(606, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 37);
            this.label11.TabIndex = 24;
            this.label11.Text = "Kelimeler :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDurumTirnak
            // 
            this.lblDurumTirnak.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumTirnak.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblDurumTirnak.Location = new System.Drawing.Point(426, 447);
            this.lblDurumTirnak.Name = "lblDurumTirnak";
            this.lblDurumTirnak.Size = new System.Drawing.Size(360, 37);
            this.lblDurumTirnak.TabIndex = 27;
            this.lblDurumTirnak.Text = "(“) ifadesi metinde 0 defa geçiyor.";
            this.lblDurumTirnak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Cairo SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(293, 446);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 37);
            this.label13.TabIndex = 26;
            this.label13.Text = "Tırnak Sayısı (“) :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetailes
            // 
            this.pnlDetailes.Controls.Add(this.btnReturn);
            this.pnlDetailes.Controls.Add(this.dgvHatalar);
            this.pnlDetailes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailes.Location = new System.Drawing.Point(0, 49);
            this.pnlDetailes.Name = "pnlDetailes";
            this.pnlDetailes.Size = new System.Drawing.Size(866, 532);
            this.pnlDetailes.TabIndex = 28;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Cairo", 13.25F, System.Drawing.FontStyle.Bold);
            this.btnReturn.ForeColor = System.Drawing.Color.Transparent;
            this.btnReturn.Location = new System.Drawing.Point(146, 470);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(555, 41);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Geri Dön";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dgvHatalar
            // 
            this.dgvHatalar.AllowUserToAddRows = false;
            this.dgvHatalar.AllowUserToDeleteRows = false;
            this.dgvHatalar.AllowUserToResizeColumns = false;
            this.dgvHatalar.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHatalar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHatalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHatalar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHatalar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHatalar.ColumnHeadersHeight = 35;
            this.dgvHatalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHatalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detailes,
            this.Source});
            this.dgvHatalar.EnableHeadersVisualStyles = false;
            this.dgvHatalar.GridColor = System.Drawing.Color.White;
            this.dgvHatalar.Location = new System.Drawing.Point(12, 18);
            this.dgvHatalar.Name = "dgvHatalar";
            this.dgvHatalar.ReadOnly = true;
            this.dgvHatalar.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHatalar.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHatalar.Size = new System.Drawing.Size(842, 433);
            this.dgvHatalar.TabIndex = 0;
            // 
            // Detailes
            // 
            this.Detailes.HeaderText = "Hatanın ayrıntıları";
            this.Detailes.Name = "Detailes";
            this.Detailes.ReadOnly = true;
            // 
            // Source
            // 
            this.Source.FillWeight = 30F;
            this.Source.HeaderText = "Hatanın kaynağı";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            // 
            // lblLoading
            // 
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.Font = new System.Drawing.Font("Cairo", 10.25F);
            this.lblLoading.ForeColor = System.Drawing.Color.DarkGray;
            this.lblLoading.Location = new System.Drawing.Point(141, 191);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(582, 37);
            this.lblLoading.TabIndex = 29;
            this.lblLoading.Text = "İşleniyor Lütfen Bekleyiniz ..";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picInfo1
            // 
            this.picInfo1.Image = ((System.Drawing.Image)(resources.GetObject("picInfo1.Image")));
            this.picInfo1.Location = new System.Drawing.Point(274, 287);
            this.picInfo1.Name = "picInfo1";
            this.picInfo1.Size = new System.Drawing.Size(16, 18);
            this.picInfo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfo1.TabIndex = 30;
            this.picInfo1.TabStop = false;
            this.picInfo1.MouseHover += new System.EventHandler(this.CommonInfoPictureBox_MouseHover);
            // 
            // picInfo3
            // 
            this.picInfo3.Image = ((System.Drawing.Image)(resources.GetObject("picInfo3.Image")));
            this.picInfo3.Location = new System.Drawing.Point(274, 343);
            this.picInfo3.Name = "picInfo3";
            this.picInfo3.Size = new System.Drawing.Size(16, 18);
            this.picInfo3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfo3.TabIndex = 31;
            this.picInfo3.TabStop = false;
            this.picInfo3.MouseHover += new System.EventHandler(this.CommonInfoPictureBox_MouseHover);
            // 
            // picInfo5
            // 
            this.picInfo5.Image = ((System.Drawing.Image)(resources.GetObject("picInfo5.Image")));
            this.picInfo5.Location = new System.Drawing.Point(274, 399);
            this.picInfo5.Name = "picInfo5";
            this.picInfo5.Size = new System.Drawing.Size(16, 18);
            this.picInfo5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfo5.TabIndex = 32;
            this.picInfo5.TabStop = false;
            this.picInfo5.MouseHover += new System.EventHandler(this.CommonInfoPictureBox_MouseHover);
            // 
            // picInfo7
            // 
            this.picInfo7.Image = ((System.Drawing.Image)(resources.GetObject("picInfo7.Image")));
            this.picInfo7.Location = new System.Drawing.Point(274, 456);
            this.picInfo7.Name = "picInfo7";
            this.picInfo7.Size = new System.Drawing.Size(16, 18);
            this.picInfo7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfo7.TabIndex = 33;
            this.picInfo7.TabStop = false;
            this.picInfo7.MouseHover += new System.EventHandler(this.CommonInfoPictureBox_MouseHover);
            // 
            // picInfo2
            // 
            this.picInfo2.Image = ((System.Drawing.Image)(resources.GetObject("picInfo2.Image")));
            this.picInfo2.Location = new System.Drawing.Point(584, 287);
            this.picInfo2.Name = "picInfo2";
            this.picInfo2.Size = new System.Drawing.Size(16, 18);
            this.picInfo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfo2.TabIndex = 34;
            this.picInfo2.TabStop = false;
            this.picInfo2.MouseHover += new System.EventHandler(this.CommonInfoPictureBox_MouseHover);
            // 
            // picInfo4
            // 
            this.picInfo4.Image = ((System.Drawing.Image)(resources.GetObject("picInfo4.Image")));
            this.picInfo4.Location = new System.Drawing.Point(584, 343);
            this.picInfo4.Name = "picInfo4";
            this.picInfo4.Size = new System.Drawing.Size(16, 18);
            this.picInfo4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfo4.TabIndex = 35;
            this.picInfo4.TabStop = false;
            this.picInfo4.MouseHover += new System.EventHandler(this.CommonInfoPictureBox_MouseHover);
            // 
            // picInfo6
            // 
            this.picInfo6.Image = ((System.Drawing.Image)(resources.GetObject("picInfo6.Image")));
            this.picInfo6.Location = new System.Drawing.Point(584, 399);
            this.picInfo6.Name = "picInfo6";
            this.picInfo6.Size = new System.Drawing.Size(16, 18);
            this.picInfo6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfo6.TabIndex = 36;
            this.picInfo6.TabStop = false;
            this.picInfo6.MouseHover += new System.EventHandler(this.CommonInfoPictureBox_MouseHover);
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(866, 581);
            this.Controls.Add(this.pnlDetailes);
            this.Controls.Add(this.lblDurumTirnak);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblDurumKelime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnDetailes);
            this.Controls.Add(this.lblDurumKaynak);
            this.Controls.Add(this.lblDurumEkler);
            this.Controls.Add(this.lblDurumTablo);
            this.Controls.Add(this.lblDurumSekil);
            this.Controls.Add(this.lblDurumIcindekiler);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pieChart);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.pnlHeading);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.picInfo1);
            this.Controls.Add(this.picInfo3);
            this.Controls.Add(this.picInfo5);
            this.Controls.Add(this.picInfo7);
            this.Controls.Add(this.picInfo2);
            this.Controls.Add(this.picInfo4);
            this.Controls.Add(this.picInfo6);
            this.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tez Kontrol Sistemi";
            this.Load += new System.EventHandler(this.MainDashboard_Load);
            this.pnlHeading.ResumeLayout(false);
            this.pnlHeadingCenter.ResumeLayout(false);
            this.pnlHeadingCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).EndInit();
            this.pnlDetailes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHatalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeading;
        private System.Windows.Forms.Panel pnlHeadingCenter;
        private System.Windows.Forms.Label lblHeadingCenter;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDurumIcindekiler;
        private System.Windows.Forms.Label lblDurumSekil;
        private System.Windows.Forms.Label lblDurumTablo;
        private System.Windows.Forms.Label lblDurumEkler;
        private System.Windows.Forms.Label lblDurumKaynak;
        private System.Windows.Forms.Button btnDetailes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblDurumKelime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDurumTirnak;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlDetailes;
        private System.Windows.Forms.DataGridView dgvHatalar;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detailes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox picInfo1;
        private System.Windows.Forms.PictureBox picInfo3;
        private System.Windows.Forms.PictureBox picInfo5;
        private System.Windows.Forms.PictureBox picInfo7;
        private System.Windows.Forms.PictureBox picInfo2;
        private System.Windows.Forms.PictureBox picInfo4;
        private System.Windows.Forms.PictureBox picInfo6;
    }
}