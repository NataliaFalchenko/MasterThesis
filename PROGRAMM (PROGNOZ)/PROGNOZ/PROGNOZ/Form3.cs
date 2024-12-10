using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PROGNOZ
{
    public partial class Form3 : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = baseCollege.mdb";
        private OleDbConnection myConnection;
        
        public Form3()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baseCollegeDataSet.zvazok' table. You can move, or remove it, as needed.
            this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.special' table. You can move, or remove it, as needed.
            this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.zaclad' table. You can move, or remove it, as needed.
            this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);
            comboBox1.Text = " ";
            comboBox2.Text = " ";
        }
        // ПОБУДОВА ТАБЛИЦІ ДЛЯ ПРОГНОЗУВАННЯ
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                // вибірка з таблиці zaclad НОМЕРУ закладу за відомою НАЗВОЮ
                string nameZa = comboBox1.Text;
                string query5 = "SELECT id_za FROM zaclad WHERE (namecol ='" + nameZa + "') ";
                OleDbDataAdapter command = new OleDbDataAdapter(query5, myConnection);
                DataTable dt = new DataTable();
                command.Fill(dt);
                dataGridView1.DataSource = dt;
                int t1 = Convert.ToInt32(dataGridView1[0, 0].Value);

                // вибірка з таблиці special КОДУ спеціальності за відомою НАЗОЮ
                string nameSp = comboBox2.Text;
                string query6 = "SELECT kod_sp FROM special WHERE (name_sp ='" + nameSp + "') ";
                OleDbDataAdapter command1 = new OleDbDataAdapter(query6, myConnection);
                DataTable dt1 = new DataTable();
                command1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                int t2 = Convert.ToInt32(dataGridView2[0, 0].Value);

                // TODO: This line of code loads data into the 'baseCollegeDataSet.zvazok' table. You can move, or remove it, as needed.
                this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
                // TODO: This line of code loads data into the 'baseCollegeDataSet.special' table. You can move, or remove it, as needed.
                this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
                // TODO: This line of code loads data into the 'baseCollegeDataSet.zaclad' table. You can move, or remove it, as needed.
                this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);

                // вибірка з таблиці zvazok НОМЕРУ зв'язку за відомим НОМЕРОМ ЗАКЛАДУ і відомим КОДОМ СПЕЦІАЛЬНОсті
                string query7 = "SELECT nom_row FROM zvazok WHERE (id_za =" + t1 + ") and (kod_sp=" + t2 + ")";
                OleDbDataAdapter command2 = new OleDbDataAdapter(query7, myConnection);
                DataTable dt2 = new DataTable();
                command2.Fill(dt2);
                dataGridView3.DataSource = dt2;
                // dataGridView3.ColumnHeadersVisible = false;
                int t3 = Convert.ToInt32(dataGridView3[0, 0].Value);

                //int selectedIndex = comboBox1.SelectedIndex;
                Object selectedItem = comboBox1.SelectedItem;

               


                // побудова таблиці РОКИ -КІЛЬКІСТЬ ЗАЯВ
                string query8 = "SELECT year_sp,count_sp FROM history  WHERE (nom_row =" + t3 + ") ORDER BY year_sp ";
                OleDbDataAdapter command3 = new OleDbDataAdapter(query8, myConnection);
                DataTable dt3 = new DataTable();
                command3.Fill(dt3);
                dataGridView4.DataSource = dt3;
               
                //ПРОГНОЗ
                     
                int size = dataGridView4.RowCount-2;
                label4.Text=Convert.ToString( dataGridView4[0, 0].Value);
                 DataRow row1 = dt3.NewRow();
                row1["year_sp"] = Convert.ToString((Convert.ToInt32(dataGridView4[0, size].Value) + 1));
                row1["count_sp"] = 0;
                dt3.Rows.Add(row1);
                 double a1 = (Convert.ToDouble( dataGridView4[1, size].Value) - Convert.ToDouble(dataGridView4[1,0].Value)) / (Convert.ToDouble(dataGridView4[0,size].Value) - Convert.ToDouble(dataGridView4[0,0].Value));
                 double a0 = Convert.ToDouble(dataGridView4[1, 0].Value) - (a1 * Convert.ToDouble(dataGridView4[0, 0].Value));
                 dataGridView4[1, size+1].Value = a0 + (a1 * Convert.ToDouble(dataGridView4[0, size+1].Value));
            
                comboBox1.Text = nameZa;
                comboBox2.Text = nameSp;
              
                
                // int selectedIndex2 = comboBox2.SelectedIndex;
                // Object selectedItem2 = comboBox2.SelectedItem;

                /*int k = 0;
                            int nom = Convert.ToInt32(textBox7.Text);
                            int nomspec = Convert.ToInt32(textBox8.Text);
                            int kol_1 = Convert.ToInt32(textBox9.Text);
                            int kol_2 = Convert.ToInt32(textBox10.Text);
                            double kol_3 = Convert.ToDouble(textBox11.Text);
                            string query3 = "SELECT nom_row FROM zvazok WHERE (id_za =" + nom + ") and (kod_sp=" + nomspec + ")";
                            OleDbDataAdapter command = new OleDbDataAdapter(query3, myConnection);
                            DataTable dt = new DataTable();
                            command.Fill(dt);
                            dataGridView4.DataSource = dt;
                            dataGridView4.ColumnHeadersVisible = false;

                            k = Convert.ToInt32(dataGridView4[0, 0].Value);
                            string query4 = "INSERT INTO history(year_sp,count_sp,avg_bal,nom_row) VALUES(" + kol_1 + "," + kol_2 + "," + kol_3 + "," + k + ")";
                            OleDbCommand command1 = new OleDbCommand(query4, myConnection);
                            command1.ExecuteNonQuery();


                            MessageBox.Show("Інформацію про кількість вступників додано");
                            */
            }

            if (radioButton2.Checked)
            {
                // вибірка з таблиці zaclad НОМЕРУ закладу за відомою НАЗВОЮ
                string nameZa = comboBox1.Text;
                string query5 = "SELECT id_za FROM zaclad WHERE (namecol ='" + nameZa + "') ";
                OleDbDataAdapter command = new OleDbDataAdapter(query5, myConnection);
                DataTable dt = new DataTable();
                command.Fill(dt);
                dataGridView1.DataSource = dt;
                int t1 = Convert.ToInt32(dataGridView1[0, 0].Value);

                // вибірка з таблиці special КОДУ спеціальності за відомою НАЗОЮ
                string nameSp = comboBox2.Text;
                string query6 = "SELECT kod_sp FROM special WHERE (name_sp ='" + nameSp + "') ";
                OleDbDataAdapter command1 = new OleDbDataAdapter(query6, myConnection);
                DataTable dt1 = new DataTable();
                command1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                int t2 = Convert.ToInt32(dataGridView2[0, 0].Value);

                // TODO: This line of code loads data into the 'baseCollegeDataSet.zvazok' table. You can move, or remove it, as needed.
                this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
                // TODO: This line of code loads data into the 'baseCollegeDataSet.special' table. You can move, or remove it, as needed.
                this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
                // TODO: This line of code loads data into the 'baseCollegeDataSet.zaclad' table. You can move, or remove it, as needed.
                this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);

                // вибірка з таблиці zvazok НОМЕРУ зв'язку за відомим НОМЕРОМ ЗАКЛАДУ і відомим КОДОМ СПЕЦІАЛЬНОсті
                string query7 = "SELECT nom_row FROM zvazok WHERE (id_za =" + t1 + ") and (kod_sp=" + t2 + ")";
                OleDbDataAdapter command2 = new OleDbDataAdapter(query7, myConnection);
                DataTable dt2 = new DataTable();
                command2.Fill(dt2);
                dataGridView3.DataSource = dt2;
                // dataGridView3.ColumnHeadersVisible = false;
                int t3 = Convert.ToInt32(dataGridView3[0, 0].Value);

                //int selectedIndex = comboBox1.SelectedIndex;
                Object selectedItem = comboBox1.SelectedItem;




                // побудова таблиці РОКИ -КІЛЬКІСТЬ ЗАЯВ
                string query8 = "SELECT year_sp,count_sp FROM history  WHERE (nom_row =" + t3 + ") ORDER BY year_sp ";
                OleDbDataAdapter command3 = new OleDbDataAdapter(query8, myConnection);
                DataTable dt3 = new DataTable();
                command3.Fill(dt3);
                dataGridView4.DataSource = dt3;

                //ПРОГНОЗ
                /*DataRow row = dt3.NewRow();
                row["year_sp"] = 2024;
                row["count_sp"] = 0;
                dt3.Rows.Add(row);*/

                int size1 = dataGridView4.RowCount-2;
               int h1 = dataGridView4.RowCount / 2;
             //  label4.Text = Convert.ToString(h1);
                DataRow row1 = dt3.NewRow();
                row1["year_sp"] = Convert.ToString((Convert.ToInt32(dataGridView4[0, size1].Value)+1));
                row1["count_sp"] = 0;
                dt3.Rows.Add(row1);

                double s1 = 0;int k1 = 0;
                for (int i = 0; i < h1; i++)
                {
                     s1 = Convert.ToDouble(dataGridView4[0, i].Value) + s1;
                      k1++;
                }
                double xsr_1 = s1 / k1;

                double s2 = 0; int k2 = 0;
                for (int i = h1; i < size1+1; i++)
                {
                    s2 = Convert.ToDouble (dataGridView4[0, i].Value) + s2;
                    k2++;
                }
                double xsr_2 = s2 / k2;

                double m1 = 0; 
                for (int i = 0; i < h1; i++)
                {
                    m1 = Convert.ToDouble(dataGridView4[1, i].Value) + m1;
                                    }
                double ysr_1 = m1 / k1;

                double m2 = 0; 
                for (int i = h1; i < size1 + 1; i++)
                {
                    m2 = Convert.ToDouble(dataGridView4[1, i].Value) + m2;
                    
                }
                double ysr_2 = m2 / k2;


                /* double xsr_1 = (Convert.ToDouble(dataGridView4[0, 0].Value) + Convert.ToDouble(dataGridView4[0, 1].Value)) / 2;
                 double xsr_2 = (Convert.ToDouble(dataGridView4[0, 2].Value) + Convert.ToDouble(dataGridView4[0, 3].Value)+ Convert.ToDouble(dataGridView4[0, 4].Value)) / 3;
                 double ysr_1 = (Convert.ToDouble(dataGridView4[1, 0].Value) + Convert.ToDouble(dataGridView4[1, 1].Value)) / 2;
                 double ysr_2 = (Convert.ToDouble(dataGridView4[1, 2].Value) + Convert.ToDouble(dataGridView4[1, 3].Value)+ Convert.ToDouble(dataGridView4[1, 4].Value)) / 3;
                 */


                double a1 = (ysr_2 - ysr_1) / (xsr_2 - xsr_1);
                double a0 = ysr_1 - a1 * xsr_1;
                   dataGridView4[1, size1 + 1].Value = a0 + (a1 * Convert.ToDouble(dataGridView4[0, size1 + 1].Value));
               // dataGridView4[1, 5].Value = a0 + (a1 * Convert.ToDouble(dataGridView4[0, 5].Value));
                //label4.Text = Convert.ToString(dataGridView4[1, 0].Value);


                comboBox1.Text = nameZa;
                comboBox2.Text = nameSp;
                // int selectedIndex2 = comboBox2.SelectedIndex;
                // Object selectedItem2 = comboBox2.SelectedItem;

                /*int k = 0;
                            int nom = Convert.ToInt32(textBox7.Text);
                            int nomspec = Convert.ToInt32(textBox8.Text);
                            int kol_1 = Convert.ToInt32(textBox9.Text);
                            int kol_2 = Convert.ToInt32(textBox10.Text);
                            double kol_3 = Convert.ToDouble(textBox11.Text);
                            string query3 = "SELECT nom_row FROM zvazok WHERE (id_za =" + nom + ") and (kod_sp=" + nomspec + ")";
                            OleDbDataAdapter command = new OleDbDataAdapter(query3, myConnection);
                            DataTable dt = new DataTable();
                            command.Fill(dt);
                            dataGridView4.DataSource = dt;
                            dataGridView4.ColumnHeadersVisible = false;

                            k = Convert.ToInt32(dataGridView4[0, 0].Value);
                            string query4 = "INSERT INTO history(year_sp,count_sp,avg_bal,nom_row) VALUES(" + kol_1 + "," + kol_2 + "," + kol_3 + "," + k + ")";
                            OleDbCommand command1 = new OleDbCommand(query4, myConnection);
                            command1.ExecuteNonQuery();


                            MessageBox.Show("Інформацію про кількість вступників додано");
                            */
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          // chart1.ChartAreas[0].AxisX.Minimum = 2015;
          // chart1.ChartAreas[0].AxisX.Maximum = 2026;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 150;
            /*
                        int a = Convert.ToInt32(dataGridView4[0, 0].Value);
                        int b = a + dataGridView4.Rows.Count-1;
                        int h = 1;
                        int x=a, y;
                        int d = 0;

                        while (x <= b)
                        {
                            y = Convert.ToInt32(dataGridView4[d,1].Value);
                            this.chart1.Series[0].Points.AddXY(x, y);
                            x = x + h;
                            d=d+1;
                        }
                        comboBox1.Text = " ";
                        comboBox2.Text = " ";
            */
            chart1.Series[0].Points.Clear();
           
            for (int i = 0; i < dataGridView4.Rows.Count-1; i++)
            {
                
                chart1.Series[0].Points.AddXY(Convert.ToDouble(dataGridView4.Rows[i].Cells[0].Value), Convert.ToDouble(dataGridView4.Rows[i].Cells[1].Value));
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
