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
    
    public partial class frmRegistration : Form
    {
   
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=LabDatabase;Integrated Security=True");
        SqlCommand querystatement = new SqlCommand();
        frmLogin login = new frmLogin();
        //SqlDataReader dr;
        public frmRegistration()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
            tbPassword.MaxLength = 8;
        }

       

        private void Register_Person_Load(object sender, EventArgs e)
        {
            querystatement.Connection = connection;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if (tbUserName.Text != "" && tbPassword.Text != "")
                {
                    querystatement.CommandText = "insert into tblAdmin (UserName,Password) Values ('" + tbUserName.Text + "','" + tbPassword.Text+ "')";
                    querystatement.ExecuteNonQuery();
                    querystatement.Clone();
                    MessageBox.Show("record inserted sucessfully");

                    clearScreen();

                    switchScreen();

                }
                else
                {
                    MessageBox.Show("please enter some  value");
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable for Registration");
                clearScreen();
                connection.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                querystatement.CommandText = "update  tblAdmin set UserName='" + this.tbUserName.Text + "',Password='" + this.tbPassword.Text + "';";
                querystatement.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Record is Updated.");

                clearScreen();
                connection.Close();
                switchScreen();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to Update.");
                clearScreen();
                connection.Close();
            }
        }

        public void clearScreen()
        {
            tbUserName.Clear();
            tbPassword.Clear();
           
        }
      public void switchScreen()
        {
            this.Close();
            login.Show();
        }

        private void frmRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            login.Show();
        }
    }
}
