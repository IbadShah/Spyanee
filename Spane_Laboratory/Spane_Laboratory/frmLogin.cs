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
    public partial class frmLogin : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=LabDatabase;Integrated Security=True");
        SqlCommand querystatement = new SqlCommand();
        SqlDataReader dr;

        public frmLogin()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
            tbPassword.MaxLength = 8;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegistration registration = new frmRegistration();
            this.Hide();
            registration.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            try
            {

                connection.Open();
                querystatement = new SqlCommand("SELECT * FROM tblAdmin where UserName='" + this.tbUserName.Text + "'and Password='" + this.tbPassword.Text + "';", connection);

                dr = querystatement.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                 
                    this.Hide();
                    AdminView ad = new AdminView();
                    ad.Show();
                }
                else if (count > 1)
                {
                    MessageBox.Show("username and password is ....Access denied");

                }
                else
                {
                    MessageBox.Show("username and password is not correct");
                    tbUserName.Clear();
                    tbPassword.Clear();
                }
                connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }
    }
}
