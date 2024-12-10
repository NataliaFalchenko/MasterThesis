using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;                    //1-й крок підключення до БД

namespace PROGNOZ
{
    public partial class Form1 : Form
    {
                                           // 2-й крок підключення до БД
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = baseCollege.mdb";
        private OleDbConnection myConnection;
                                            //
        public Form1()
        {
            InitializeComponent();
                                        // 3-й крок підключення до БД
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();
                                        //

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Owner = this;
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
                        // 4-й крок закриття з'єднання з БД
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Owner = this;
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.Owner = this;
            f4.Show();
        }
    }
}
