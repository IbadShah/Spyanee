using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace Spane_Laboratory
{
    public partial class AdminView : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-57NRPCA\SQLEXPRESS;Initial Catalog=Lab_Database;Integrated Security=True");
        SqlCommand querystatement = new SqlCommand();
       
        public AdminView()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide(); 
            panel2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();

            
            
        }

        private void Admin_View_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmLogin fm = new frmLogin();
            this.Hide();
            fm.Show();

        }

        private void Admin_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cmbCategories.Enabled = false;
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                connection.Open();
                if (tbCategories.Text != "")
                {
                    querystatement.CommandText = "insert into tblCategories (CatName) Values ('" + tbCategories.Text + "')";
                    querystatement.ExecuteNonQuery();
                    querystatement.Clone();
                    MessageBox.Show("record inserted sucessfully");
                    tbCategories.Clear();

                }
                else
                {
                    MessageBox.Show("please enter some  value");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable for Registration");
                connection.Close();
            }

            cmbCategories.Enabled = true;
        }

        private void cmbCategories_Click(object sender, EventArgs e)
        {

        }

       


        }

        
       
    }

