namespace PROGNOZ
{
    partial class Form4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.zvazokBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseCollegeDataSet = new PROGNOZ.baseCollegeDataSet();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.specialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.zacladBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.zacladTableAdapter = new PROGNOZ.baseCollegeDataSetTableAdapters.zacladTableAdapter();
            this.specialTableAdapter = new PROGNOZ.baseCollegeDataSetTableAdapters.specialTableAdapter();
            this.zvazokTableAdapter = new PROGNOZ.baseCollegeDataSetTableAdapters.zvazokTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zvazokBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseCollegeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zacladBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(974, 915);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.LightSlateGray;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(700, 400);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series2.IsXValueIndexed = true;
            series2.LabelForeColor = System.Drawing.Color.Maroon;
            series2.Legend = "Legend1";
            series2.MarkerBorderWidth = 10;
            series2.Name = "Динаміка за спеціальністю";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(809, 400);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(17, 403);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 28;
            this.dataGridView4.Size = new System.Drawing.Size(504, 407);
            this.dataGridView4.TabIndex = 26;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.zvazokBindingSource;
            this.comboBox3.DisplayMember = "nom_row";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(1197, 81);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 28);
            this.comboBox3.TabIndex = 25;
            this.comboBox3.ValueMember = "nom_row";
            this.comboBox3.Visible = false;
            // 
            // zvazokBindingSource
            // 
            this.zvazokBindingSource.DataMember = "zvazok";
            this.zvazokBindingSource.DataSource = this.baseCollegeDataSet;
            // 
            // baseCollegeDataSet
            // 
            this.baseCollegeDataSet.DataSetName = "baseCollegeDataSet";
            this.baseCollegeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1043, 845);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.Size = new System.Drawing.Size(205, 90);
            this.dataGridView3.TabIndex = 24;
            this.dataGridView3.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(591, 845);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(163, 90);
            this.dataGridView2.TabIndex = 23;
            this.dataGridView2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(784, 845);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(184, 90);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.specialBindingSource;
            this.comboBox2.DisplayMember = "name_sp";
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(611, 81);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(557, 37);
            this.comboBox2.TabIndex = 20;
            this.comboBox2.ValueMember = "name_sp";
            // 
            // specialBindingSource
            // 
            this.specialBindingSource.DataMember = "special";
            this.specialBindingSource.DataSource = this.baseCollegeDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(665, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Оберіть СПЕЦІАЛЬНІСТЬ";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.zacladBindingSource;
            this.comboBox1.DisplayMember = "namecol";
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(557, 37);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.ValueMember = "namecol";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // zacladBindingSource
            // 
            this.zacladBindingSource.DataMember = "zaclad";
            this.zacladBindingSource.DataSource = this.baseCollegeDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-123, -31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Оберіть НАВЧАЛЬНИЙ ЗАКЛАД";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Оберіть НАВЧАЛЬНИЙ ЗАКЛАД";
            // 
            // zacladTableAdapter
            // 
            this.zacladTableAdapter.ClearBeforeFill = true;
            // 
            // specialTableAdapter
            // 
            this.specialTableAdapter.ClearBeforeFill = true;
            // 
            // zvazokTableAdapter
            // 
            this.zvazokTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Location = new System.Drawing.Point(181, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 85);
            this.button1.TabIndex = 30;
            this.button1.Text = "ПОБУДУВАТИ ТАБЛИЦЮ СТАТИСТИКИ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.Location = new System.Drawing.Point(989, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 85);
            this.button2.TabIndex = 31;
            this.button2.Text = "ПОБУДУВАТИ ДІАГРАМУ СТАТИСТИКИ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(1602, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 44);
            this.button3.TabIndex = 32;
            this.button3.Text = "ЗАКРИТИ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1778, 944);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "СТАТИСТИКА";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form4_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zvazokBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseCollegeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zacladBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private baseCollegeDataSet baseCollegeDataSet;
        private System.Windows.Forms.BindingSource zacladBindingSource;
        private baseCollegeDataSetTableAdapters.zacladTableAdapter zacladTableAdapter;
        private System.Windows.Forms.BindingSource specialBindingSource;
        private baseCollegeDataSetTableAdapters.specialTableAdapter specialTableAdapter;
        private System.Windows.Forms.BindingSource zvazokBindingSource;
        private baseCollegeDataSetTableAdapters.zvazokTableAdapter zvazokTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}