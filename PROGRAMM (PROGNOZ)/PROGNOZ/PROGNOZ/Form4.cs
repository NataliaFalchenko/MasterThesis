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
    public partial class Form4 : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = baseCollege.mdb";
        private OleDbConnection myConnection;
        public Form4()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
        private void Form4_Load_1(object sender, EventArgs e)
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
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

       

       

        private void button1_Click_1(object sender, EventArgs e)
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
           // Object selectedItem = comboBox1.SelectedItem;




            // побудова таблиці РОКИ -КІЛЬКІСТЬ ЗАЯВ
            string query8 = "SELECT year_sp,count_sp FROM history  WHERE (nom_row =" + t3 + ") ORDER BY year_sp ";
            OleDbDataAdapter command3 = new OleDbDataAdapter(query8, myConnection);
            DataTable dt3 = new DataTable();
            command3.Fill(dt3);
            dataGridView4.DataSource = dt3;

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

        private void button2_Click(object sender, EventArgs e)
        {
            {
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 150;
                chart1.Series[0].Points.Clear();

                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {

                    chart1.Series[0].Points.AddXY(Convert.ToDouble(dataGridView4.Rows[i].Cells[0].Value), Convert.ToDouble(dataGridView4.Rows[i].Cells[1].Value));
                }

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
