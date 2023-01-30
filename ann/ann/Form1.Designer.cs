namespace ann
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.egitimOraniNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.gizliKatmanNoronAdediLabel = new System.Windows.Forms.Label();
            this.epokAdediLabel = new System.Windows.Forms.Label();
            this.egitimHiziLabel = new System.Windows.Forms.Label();
            this.egitimOraniLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.testOraniLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.egitimHiziTextBox = new System.Windows.Forms.TextBox();
            this.epokAdediTextBox = new System.Windows.Forms.TextBox();
            this.gizliKatmanNoronAdediTextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.egitimOraniNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(456, 20);
            this.textBox1.TabIndex = 0;
            // 
            // egitimOraniNumericUpDown
            // 
            this.egitimOraniNumericUpDown.Location = new System.Drawing.Point(202, 155);
            this.egitimOraniNumericUpDown.Name = "egitimOraniNumericUpDown";
            this.egitimOraniNumericUpDown.Size = new System.Drawing.Size(124, 20);
            this.egitimOraniNumericUpDown.TabIndex = 6;
            this.egitimOraniNumericUpDown.ValueChanged += new System.EventHandler(this.egitimOraniNumericUpDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(474, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Giriş Dosyası Seç";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gizliKatmanNoronAdediLabel
            // 
            this.gizliKatmanNoronAdediLabel.AutoSize = true;
            this.gizliKatmanNoronAdediLabel.Location = new System.Drawing.Point(9, 77);
            this.gizliKatmanNoronAdediLabel.Name = "gizliKatmanNoronAdediLabel";
            this.gizliKatmanNoronAdediLabel.Size = new System.Drawing.Size(127, 13);
            this.gizliKatmanNoronAdediLabel.TabIndex = 10;
            this.gizliKatmanNoronAdediLabel.Text = "Gizli Katman Nöron Adedi";
            // 
            // epokAdediLabel
            // 
            this.epokAdediLabel.AutoSize = true;
            this.epokAdediLabel.Location = new System.Drawing.Point(9, 103);
            this.epokAdediLabel.Name = "epokAdediLabel";
            this.epokAdediLabel.Size = new System.Drawing.Size(62, 13);
            this.epokAdediLabel.TabIndex = 11;
            this.epokAdediLabel.Text = "Epok Adedi";
            // 
            // egitimHiziLabel
            // 
            this.egitimHiziLabel.AutoSize = true;
            this.egitimHiziLabel.Location = new System.Drawing.Point(9, 129);
            this.egitimHiziLabel.Name = "egitimHiziLabel";
            this.egitimHiziLabel.Size = new System.Drawing.Size(55, 13);
            this.egitimHiziLabel.TabIndex = 12;
            this.egitimHiziLabel.Text = "Eğitim Hızı";
            // 
            // egitimOraniLabel
            // 
            this.egitimOraniLabel.AutoSize = true;
            this.egitimOraniLabel.Location = new System.Drawing.Point(9, 155);
            this.egitimOraniLabel.Name = "egitimOraniLabel";
            this.egitimOraniLabel.Size = new System.Drawing.Size(63, 13);
            this.egitimOraniLabel.TabIndex = 13;
            this.egitimOraniLabel.Text = "Eğitim Oranı";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(456, 20);
            this.textBox2.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(474, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Çıkış Dosyası Seç";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // testOraniLabel
            // 
            this.testOraniLabel.AutoSize = true;
            this.testOraniLabel.Location = new System.Drawing.Point(9, 181);
            this.testOraniLabel.Name = "testOraniLabel";
            this.testOraniLabel.Size = new System.Drawing.Size(67, 13);
            this.testOraniLabel.TabIndex = 16;
            this.testOraniLabel.Text = "Test Oranı %";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chart1.Location = new System.Drawing.Point(579, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            series2.BorderColor = System.Drawing.Color.Transparent;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Purple;
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(857, 468);
            this.chart1.TabIndex = 17;
            this.chart1.MouseEnter += new System.EventHandler(this.chart1_MouseEnter);
            this.chart1.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(474, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 22);
            this.button3.TabIndex = 18;
            this.button3.Text = "Eğit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 20;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.GreenYellow;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 244);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(270, 199);
            this.listBox1.TabIndex = 21;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.GreenYellow;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(303, 244);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(270, 199);
            this.listBox2.TabIndex = 22;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 449);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(480, 31);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(199, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 24;
            // 
            // egitimHiziTextBox
            // 
            this.egitimHiziTextBox.Location = new System.Drawing.Point(202, 129);
            this.egitimHiziTextBox.Name = "egitimHiziTextBox";
            this.egitimHiziTextBox.Size = new System.Drawing.Size(124, 20);
            this.egitimHiziTextBox.TabIndex = 25;
            this.egitimHiziTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.egitimHiziTextBox_KeyPress);
            // 
            // epokAdediTextBox
            // 
            this.epokAdediTextBox.Location = new System.Drawing.Point(202, 103);
            this.epokAdediTextBox.Name = "epokAdediTextBox";
            this.epokAdediTextBox.Size = new System.Drawing.Size(124, 20);
            this.epokAdediTextBox.TabIndex = 26;
            this.epokAdediTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.epokAdediTextBox_KeyPress);
            // 
            // gizliKatmanNoronAdediTextBox
            // 
            this.gizliKatmanNoronAdediTextBox.Location = new System.Drawing.Point(202, 77);
            this.gizliKatmanNoronAdediTextBox.Name = "gizliKatmanNoronAdediTextBox";
            this.gizliKatmanNoronAdediTextBox.Size = new System.Drawing.Size(124, 20);
            this.gizliKatmanNoronAdediTextBox.TabIndex = 27;
            this.gizliKatmanNoronAdediTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gizliKatmanNoronAdediTextBox_KeyPress);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(498, 449);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 31);
            this.button4.TabIndex = 28;
            this.button4.Text = "Sıfırla";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(1448, 490);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.gizliKatmanNoronAdediTextBox);
            this.Controls.Add(this.epokAdediTextBox);
            this.Controls.Add(this.egitimHiziTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.testOraniLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.egitimOraniLabel);
            this.Controls.Add(this.egitimHiziLabel);
            this.Controls.Add(this.epokAdediLabel);
            this.Controls.Add(this.gizliKatmanNoronAdediLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.egitimOraniNumericUpDown);
            this.Controls.Add(this.textBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1464, 529);
            this.MinimumSize = new System.Drawing.Size(1464, 529);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artificial Neural Networks";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.egitimOraniNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown egitimOraniNumericUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label gizliKatmanNoronAdediLabel;
        private System.Windows.Forms.Label epokAdediLabel;
        private System.Windows.Forms.Label egitimHiziLabel;
        private System.Windows.Forms.Label egitimOraniLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label testOraniLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox egitimHiziTextBox;
        private System.Windows.Forms.TextBox epokAdediTextBox;
        private System.Windows.Forms.TextBox gizliKatmanNoronAdediTextBox;
        private System.Windows.Forms.Button button4;
    }
}

