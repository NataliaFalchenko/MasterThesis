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
    public partial class Form2 : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = baseCollege.mdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();
        }

        public DataSet CreateCmdsAndUpdate(string connectionString,
  string queryString, string dataGridView3)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand(queryString, connection);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                connection.Open();

                DataSet customers = new DataSet();
                adapter.Fill(customers);

                //code to modify data in dataset here

                adapter.Update(customers, dataGridView3);

                return customers;
            }
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baseCollegeDataSet.history' table. You can move, or remove it, as needed.
            this.historyTableAdapter.Fill(this.baseCollegeDataSet.history);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.special' table. You can move, or remove it, as needed.
            this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.zvazok' table. You can move, or remove it, as needed.
            this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.zaclad' table. You can move, or remove it, as needed.
            this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);
            
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            // comboBox3.Text = "  ";
            
        

        }
        // ВИДАЛЕННЯ закладу
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "") MessageBox.Show("Вкажіть номер");
            else
            {
                int b = 0;
                int n = Convert.ToInt32(textBox13.Text);
                int l = dataGridView3.RowCount;
                for (int i = 0; i < l; i++)
                {
                    if (Convert.ToInt32(dataGridView3[0, i].Value) == n) b++;
                }

                if (b != 0)
                {
                    string query = " DELETE FROM zaclad WHERE id_za=" + n + "";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дані про навчальний заклад видалено");
                    this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);
                    textBox13.Text = " ";

                }
                else
                {
                    MessageBox.Show("Такого номера не існує");
                    textBox13.Text = " ";

                }
            }
        }
                private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Додавання навчального закладу
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""|| textBox2.Text == ""|| textBox3.Text == "") MessageBox.Show("Вкажіть дані");
            else
            {
                int nr = 0;
                int nomer = Convert.ToInt32(textBox1.Text);
                string name = textBox2.Text;
                string misto = textBox3.Text;

                int l = dataGridView3.RowCount; // кількість рядків таблиці
                for (int i = 0; i < l; i++)
                {
                    if (Convert.ToInt32(dataGridView3[0, i].Value) == nomer)
                    { nr++; break; }
                }
                if (nr == 0)
                {
                    string query = "INSERT INTO zaclad(id_za,namecol,city) VALUES(" + nomer + ",'" + name + "','" + misto + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дані про навчальний заклад додано");
                    this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);
                    this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
                    this.historyTableAdapter.Fill(this.baseCollegeDataSet.history);

                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";

                }
                else
                {
                    MessageBox.Show("Такий номер вже існує");
                    textBox13.Text = " ";

                }

            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Додавання нової спеціальності
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "") MessageBox.Show("Вкажіть дані");
            else
            {
                int nr = 0;
                int nomersp = Convert.ToInt32(textBox4.Text);
                string namesp = textBox5.Text;
                int l = dataGridView1.RowCount; // кількість рядків таблиці
                for (int i = 0; i < l; i++)
                {
                    if (Convert.ToInt32(dataGridView1[0, i].Value) == nomersp)
                    { nr++; break; }
                }
                if (nr == 0)
                {
                    string query1 = "INSERT INTO special(kod_sp,name_sp) VALUES(" + nomersp + ",'" + namesp + "')";
                    OleDbCommand command = new OleDbCommand(query1, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Інформацію про спеціальність додано");
                    this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
                    this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);
                    this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
                    this.historyTableAdapter.Fill(this.baseCollegeDataSet.history);
                    textBox4.Text = " ";
                    textBox5.Text = " ";

                }
                else
                {
                    MessageBox.Show("Такий код вже існує, повторіть введення");
                    textBox4.Text = " ";
                    textBox5.Text = " ";

                }
            }
        }
        // Видалення спеціальності
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "") MessageBox.Show("Вкажіть код спеціальнсті");
            else
            {
                int b = 0;
                int l = dataGridView1.RowCount;
                int nomersp = Convert.ToInt32(textBox6.Text);
                for (int i = 0; i < l; i++)
                {
                    if (Convert.ToInt32(dataGridView1[0, i].Value) == nomersp) b++;
                }

                if (b != 0)
                {

                    string query = " DELETE FROM special WHERE kod_sp=" + nomersp + "";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дані про спеціальність видалено");
                    this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
                    textBox6.Text = " ";
                }
                else
                {
                    MessageBox.Show("Такого коду не існує");
                    textBox6.Text = " ";

                }
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.historyTableAdapter.FillBy(this.baseCollegeDataSet.history);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.historyTableAdapter.FillBy2(this.baseCollegeDataSet.history);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        //КНОПКА ДОДАТИ ДАНІ (КІЛЬКІСТЬ ЗАЯВ)
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "") MessageBox.Show("Вкажіть дані");
            else
            {

                // Додавання даних про кількість вступників у таблицю history
                string namename = comboBox1.Text;
                int nomspec = Convert.ToInt32(comboBox2.Text);
                int kol_1 = Convert.ToInt32(textBox9.Text);
                int kol_2 = Convert.ToInt32(textBox10.Text);
                double kol_3 = Convert.ToDouble(textBox11.Text);


                int nr1 = 0;
                int l = dataGridView2.RowCount; // кількість рядків таблиці
                for (int i = 0; i < l; i++)
                {
                    if (Convert.ToInt32(dataGridView2[0, i].Value) == kol_1)
                    { nr1++; break; }
                }
                if (nr1 == 0)
                {


                    int k = 0;

                    string query13 = "SELECT id_za FROM zaclad WHERE (namecol ='" + namename + "') ";
                    OleDbDataAdapter command13 = new OleDbDataAdapter(query13, myConnection);
                    DataTable dt13 = new DataTable();
                    command13.Fill(dt13);
                    dataGridView11.DataSource = dt13;
                    int t13 = Convert.ToInt32(dataGridView11[0, 0].Value);


                    string query3 = "SELECT nom_row FROM zvazok WHERE (id_za =" + t13 + ") and (kod_sp=" + nomspec + ")";
                    OleDbDataAdapter command = new OleDbDataAdapter(query3, myConnection);
                    DataTable dt = new DataTable();
                    command.Fill(dt);
                    dataGridView4.DataSource = dt;
                    dataGridView4.ColumnHeadersVisible = false;

                    k = Convert.ToInt32(dataGridView4[0, 0].Value);
                    string query20 = "INSERT INTO history(year_sp,count_sp,avg_bal,nom_row) VALUES(" + kol_1 + "," + kol_2 + "," + kol_3 + "," + k + ")";
                    OleDbCommand command1 = new OleDbCommand(query20, myConnection);
                    command1.ExecuteNonQuery();


                    MessageBox.Show("Інформацію про кількість вступників додано");

                    // вибірка з таблиці zaclad НОМЕРУ закладу за відомою НАЗВОЮ
                    string nameZa = comboBox1.Text;
                    string query4 = "SELECT id_za FROM zaclad WHERE (namecol ='" + nameZa + "') ";
                    OleDbDataAdapter command4 = new OleDbDataAdapter(query4, myConnection);
                    DataTable dt4 = new DataTable();
                    command4.Fill(dt4);
                    dataGridView4.DataSource = dt4;
                    int t4 = Convert.ToInt32(dataGridView4[0, 0].Value);

                    // вибірка з таблиці special КОДУ спеціальності за відомою НАЗОЮ
                    int kodSp = Convert.ToInt32(comboBox2.Text);
                    string query5 = "SELECT kod_sp FROM special WHERE (kod_sp =" + kodSp + ") ";
                    OleDbDataAdapter command5 = new OleDbDataAdapter(query5, myConnection);
                    DataTable dt5 = new DataTable();
                    command5.Fill(dt5);
                    dataGridView5.DataSource = dt5;
                    int t5 = Convert.ToInt32(dataGridView5[0, 0].Value);

                    // TODO: This line of code loads data into the 'baseCollegeDataSet.zvazok' table. You can move, or remove it, as needed.
                    this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
                    // TODO: This line of code loads data into the 'baseCollegeDataSet.special' table. You can move, or remove it, as needed.
                    this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
                    // TODO: This line of code loads data into the 'baseCollegeDataSet.zaclad' table. You can move, or remove it, as needed.
                    this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);

                    // вибірка з таблиці zvazok НОМЕРУ зв'язку за відомим НОМЕРОМ ЗАКЛАДУ і відомим КОДОМ СПЕЦІАЛЬНОсті
                    string query6 = "SELECT nom_row FROM zvazok WHERE (id_za =" + t4 + ") and (kod_sp=" + t5 + ")";
                    OleDbDataAdapter command6 = new OleDbDataAdapter(query6, myConnection);
                    DataTable dt6 = new DataTable();
                    command6.Fill(dt6);
                    dataGridView6.DataSource = dt6;
                    // dataGridView3.ColumnHeadersVisible = false;
                    int t6 = Convert.ToInt32(dataGridView6[0, 0].Value);

                    //int selectedIndex = comboBox1.SelectedIndex;
                    Object selectedItem = comboBox1.SelectedItem;


                    // побудова таблиці РОКИ -КІЛЬКІСТЬ ЗАЯВ
                    string query8 = "SELECT year_sp,count_sp,avg_bal FROM history  WHERE (nom_row =" + t6 + ") ORDER BY year_sp ";
                    OleDbDataAdapter command7 = new OleDbDataAdapter(query8, myConnection);
                    DataTable dt7 = new DataTable();
                    command7.Fill(dt7);
                    dataGridView2.DataSource = dt7;

                    textBox9.Text = " ";
                    textBox10.Text = " ";
                    textBox11.Text = " ";
                    comboBox1.Text = nameZa;
                    comboBox2.Text = Convert.ToString(kodSp);
                }
                else
                {
                    if (textBox9.Text == " " || textBox10.Text == " " || textBox11.Text == " ")
                        MessageBox.Show("Введіть дані");
                    else
                    {
                        MessageBox.Show("Такий рік вже існує, повторіть введення");
                        textBox9.Text = " ";
                        textBox10.Text = " ";
                        textBox11.Text = " ";
                    }
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
     
        
        //КНОПКА ОНОВИТИ ТАБЛИЦЮ
        private void button8_Click(object sender, EventArgs e)
        {
            /*   this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);
               this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
               this.historyTableAdapter.Fill(this.baseCollegeDataSet.history);
               MessageBox.Show("Інформацію оновлено");
               */
            // вибірка з таблиці zaclad НОМЕРУ закладу за відомою НАЗВОЮ
            string nameZa = comboBox1.Text;
            string query4 = "SELECT id_za FROM zaclad WHERE (namecol ='" + nameZa + "') ";
            OleDbDataAdapter command4 = new OleDbDataAdapter(query4, myConnection);
            DataTable dt4 = new DataTable();
            command4.Fill(dt4);
            dataGridView4.DataSource = dt4;
            int t4 = Convert.ToInt32(dataGridView4[0, 0].Value);

            // вибірка з таблиці special КОДУ спеціальності за відомою НАЗОЮ
            int kodSp = Convert.ToInt32(comboBox2.Text);
            string query5 = "SELECT kod_sp FROM special WHERE (kod_sp =" + kodSp + ") ";
            OleDbDataAdapter command5 = new OleDbDataAdapter(query5, myConnection);
            DataTable dt5 = new DataTable();
            command5.Fill(dt5);
            dataGridView5.DataSource = dt5;
            int t5 = Convert.ToInt32(dataGridView5[0, 0].Value);

            // TODO: This line of code loads data into the 'baseCollegeDataSet.zvazok' table. You can move, or remove it, as needed.
            this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.special' table. You can move, or remove it, as needed.
            this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.zaclad' table. You can move, or remove it, as needed.
            this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);

            // вибірка з таблиці zvazok НОМЕРУ зв'язку за відомим НОМЕРОМ ЗАКЛАДУ і відомим КОДОМ СПЕЦІАЛЬНОсті
            string query6 = "SELECT nom_row FROM zvazok WHERE (id_za =" + t4 + ") and (kod_sp=" + t5 + ")";
            OleDbDataAdapter command6 = new OleDbDataAdapter(query6, myConnection);
            DataTable dt6 = new DataTable();
            command6.Fill(dt6);
            dataGridView6.DataSource = dt6;
            // dataGridView3.ColumnHeadersVisible = false;
            int t6 = Convert.ToInt32(dataGridView6[0, 0].Value);

            //int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;
                       

            // побудова таблиці РОКИ -КІЛЬКІСТЬ ЗАЯВ
            string query8 = "SELECT year_sp,count_sp,avg_bal FROM history  WHERE (nom_row =" + t6 + ") ORDER BY year_sp ";
            OleDbDataAdapter command7 = new OleDbDataAdapter(query8, myConnection);
            DataTable dt7 = new DataTable();
            command7.Fill(dt7);
            dataGridView2.DataSource = dt7;

            comboBox1.Text = nameZa;
            comboBox2.Text = Convert.ToString(kodSp);
            textBox12.Text = " ";
        }



        //КНОПКА ВИДАЛИТИ ДАНІ
        // видалення даних з таблиці РОКИ-ЗАЯВИ

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
                MessageBox.Show("Введіть дані");
            else
            {
                string nameZa = comboBox1.Text;
                int kodSp = Convert.ToInt32(comboBox2.Text);
                int rik = Convert.ToInt32(textBox12.Text);
                int l = dataGridView2.RowCount;
                int b = 0;
                for (int i = 0; i < l; i++)
                {
                    if (Convert.ToInt32(dataGridView2[0, i].Value) == rik) b++;
                }

                if (b > 0)
                {
                    // видалення року з таблиці history

                    // вибірка з таблиці zaclad НОМЕРУ закладу за відомою НАЗВОЮ
                    //string nameZa = comboBox1.Text;
                    string query14 = "SELECT id_za FROM zaclad WHERE (namecol ='" + nameZa + "') ";
                    OleDbDataAdapter command14 = new OleDbDataAdapter(query14, myConnection);
                    DataTable dt14 = new DataTable();
                    command14.Fill(dt14);
                    dataGridView7.DataSource = dt14;
                    int t14 = Convert.ToInt32(dataGridView7[0, 0].Value);

                    // вибірка з таблиці special КОДУ спеціальності за відомою НАЗОЮ
                    // int kodSp = Convert.ToInt32(comboBox2.Text);
                    string query15 = "SELECT kod_sp FROM special WHERE (kod_sp =" + kodSp + ") ";
                    OleDbDataAdapter command15 = new OleDbDataAdapter(query15, myConnection);
                    DataTable dt15 = new DataTable();
                    command15.Fill(dt15);
                    dataGridView8.DataSource = dt15;
                    int t15 = Convert.ToInt32(dataGridView8[0, 0].Value);



                    // вибірка з таблиці zvazok НОМЕРУ зв'язку за відомим НОМЕРОМ ЗАКЛАДУ і відомим КОДОМ СПЕЦІАЛЬНОсті
                    string query16 = "SELECT nom_row FROM zvazok WHERE (id_za =" + t14 + ") and (kod_sp=" + t15 + ")";
                    OleDbDataAdapter command6 = new OleDbDataAdapter(query16, myConnection);
                    DataTable dt16 = new DataTable();
                    command6.Fill(dt16);
                    dataGridView9.DataSource = dt16;
                    // dataGridView3.ColumnHeadersVisible = false;
                    int t16 = Convert.ToInt32(dataGridView9[0, 0].Value);

                    //int selectedIndex = comboBox1.SelectedIndex;
                    Object selectedItem = comboBox1.SelectedItem;

                    // вибірка з таблиці history НОМЕРУ рядка за відомим НОМЕРОМ зв'язку і відомим роком

                    string query17 = "SELECT id FROM history WHERE (nom_row =" + t16 + ") and (year_sp=" + rik + ")";
                    OleDbDataAdapter command17 = new OleDbDataAdapter(query17, myConnection);
                    DataTable dt17 = new DataTable();
                    command17.Fill(dt17);
                    dataGridView10.DataSource = dt17;
                    // dataGridView3.ColumnHeadersVisible = false;
                    int t17 = Convert.ToInt32(dataGridView10[0, 0].Value);

                    string query19 = " DELETE FROM history WHERE (id=" + t17 + ") ";
                    OleDbCommand command = new OleDbCommand(query19, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дані  видалено");
                    this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);
                    this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
                    this.historyTableAdapter.Fill(this.baseCollegeDataSet.history);
                    this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);

                    comboBox1.Text = nameZa;
                    comboBox2.Text = Convert.ToString(kodSp);
                }
                else
                {
                    MessageBox.Show("Такого року немає в таблиці");
                    textBox12.Text = " ";

                    comboBox1.Text = nameZa;
                    comboBox2.Text = Convert.ToString(kodSp);


                }
                /*string c1 = comboBox1.Text;
                int c2 = Convert.ToInt32(comboBox2.Text);
                int b = 0;
                int l = dataGridView2.RowCount;
                int rik = Convert.ToInt32(textBox12.Text);
                for (int i = 0; i < l; i++)
                {
                    if (Convert.ToInt32(dataGridView2[0, i].Value) == rik) b++;
                }

                if (b != 0)
                {


                    string query = " DELETE FROM history WHERE (year_sp=" + rik + " count_sp=" + c2+ " namecol='"+c1+"'";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дані  видалено");
                }
                else
                {
                    MessageBox.Show("Такого коду не існує");
                    textBox12.Text = " ";

                }*/
            }
        }
           

private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.historyTableAdapter.FillBy1(this.baseCollegeDataSet.history);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        //КНОПКА СФОРМУВАТИ ТАБЛИЦЮ
        //ФОРМУВАННЯ ТАБЛИЦІ ЗА НАЗВОЮ НАВЧАЛЬНОГО ЗАКЛАДУ І КОДОМ СПЕЦІАЛЬНОСТІ
        private void button11_Click(object sender, EventArgs e)
        {

            // вибірка з таблиці zaclad НОМЕРУ закладу за відомою НАЗВОЮ
            string nameZa = comboBox1.Text;
            string query4 = "SELECT id_za FROM zaclad WHERE (namecol ='" + nameZa + "') ";
            OleDbDataAdapter command4 = new OleDbDataAdapter(query4, myConnection);
            DataTable dt4 = new DataTable();
            command4.Fill(dt4);
            dataGridView4.DataSource = dt4;
            int t4 = Convert.ToInt32(dataGridView4[0, 0].Value);

            // вибірка з таблиці special КОДУ спеціальності за відомою НАЗОЮ
            int kodSp = Convert.ToInt32(comboBox2.Text);
            string query5 = "SELECT kod_sp FROM special WHERE (kod_sp =" + kodSp + ") ";
            OleDbDataAdapter command5 = new OleDbDataAdapter(query5, myConnection);
            DataTable dt5 = new DataTable();
            command5.Fill(dt5);
            dataGridView5.DataSource = dt5;
            int t5 = Convert.ToInt32(dataGridView5[0, 0].Value);

            // TODO: This line of code loads data into the 'baseCollegeDataSet.zvazok' table. You can move, or remove it, as needed.
            this.zvazokTableAdapter.Fill(this.baseCollegeDataSet.zvazok);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.special' table. You can move, or remove it, as needed.
            this.specialTableAdapter.Fill(this.baseCollegeDataSet.special);
            // TODO: This line of code loads data into the 'baseCollegeDataSet.zaclad' table. You can move, or remove it, as needed.
            this.zacladTableAdapter.Fill(this.baseCollegeDataSet.zaclad);

            // вибірка з таблиці zvazok НОМЕРУ зв'язку за відомим НОМЕРОМ ЗАКЛАДУ і відомим КОДОМ СПЕЦІАЛЬНОсті
            string query6 = "SELECT nom_row FROM zvazok WHERE (id_za =" + t4 + ") and (kod_sp=" + t5 + ")";
            OleDbDataAdapter command6 = new OleDbDataAdapter(query6, myConnection);
            DataTable dt6 = new DataTable();
            command6.Fill(dt6);
            dataGridView6.DataSource = dt6;
            // dataGridView3.ColumnHeadersVisible = false;
            int t6 = Convert.ToInt32(dataGridView6[0, 0].Value);

            //int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;

                        // побудова таблиці РОКИ -КІЛЬКІСТЬ ЗАЯВ
            string query8 = "SELECT year_sp,count_sp,avg_bal FROM history  WHERE (nom_row =" + t6 + ") ORDER BY year_sp ";
            OleDbDataAdapter command7 = new OleDbDataAdapter(query8, myConnection);
            DataTable dt7 = new DataTable();
            command7.Fill(dt7);
            dataGridView2.DataSource = dt7;

            comboBox1.Text = nameZa;
            comboBox2.Text = Convert.ToString(kodSp);
        }
      


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter )
            {
                

            } 
        }

        private void dataGridView3_KeyUp(object sender, KeyEventArgs e)
        {
           
           
        }


    }
}

