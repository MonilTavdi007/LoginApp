using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                new SqlConnection().ConnectionString= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BLUEDEVIL\source\repos\LOGIN001\Database1.mdf;Integrated Security=True" ;
                {
                    string query = "SELECT * FROM Login WHERE Username = '" + txtusername.Text.Trim() +
                        "' AND Password == '" + txtpassword.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.FIll(dta);
                    if (dta.Rows.Count == 1)
                    {
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.Show();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        private bool isValid()
        {       
            if (txtusername.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Enter valid username please", "Error");
                return false;

            } else if (txtpassword.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Please enter the correct credentials", "Error");
                return false;
            }
            return true;
        }
    }
}
