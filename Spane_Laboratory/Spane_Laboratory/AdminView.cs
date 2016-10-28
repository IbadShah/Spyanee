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
using Lab.Models;

namespace Spane_Laboratory
{
    public partial class AdminView : Form
    {
        #region Procedure Parameters
        private const string CatId = "@CatId";
        private const string CatName = "@CatName";
        private const string RetVal = "@RetVal";
        #endregion
        private readonly DbHelper _oDbHelper = new DbHelper();

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

            DataLoader();
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
            CustomMessageBox customMessageBox = new CustomMessageBox();
          
            customMessageBox.Show();
           
           
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cmbCategories.Enabled = false;
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _oDbHelper.OpenConnection();
                var catgories = Initializer();
                SaveCategories(catgories);
                _oDbHelper.CloseConnection();
                cmbCategories.Enabled = true;
                MessageBox.Show("Record is Inserted.");
                PopulateCategories();
            }   
            
                 catch (Exception ex)
            {
                cmbCategories.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
            }
          
        }

     

       public void PopulateCategories()
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt=_oDbHelper.GetDataTable("uspGetAllCategories");
                cmbCategories.DataSource = dt;
                cmbCategories.DisplayMember = "CatName";
                cmbCategories.ValueMember = "CatId";
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "CatName";
                cmbCategory.ValueMember = "CatId";
                _oDbHelper.CloseConnection();


            }
            catch(Exception ex)
            {

                MessageBox.Show("Unable to Load Categories."+ex);
                _oDbHelper.CloseConnection();
            }
        }

       public void PopulateSubCategoryGrid()
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt = _oDbHelper.GetDataTable("uspGetAllSubCategories");
                gvSubCategories.DataSource = dt;
                _oDbHelper.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to Load SubCategories." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        public void DataLoader()
        {
           
            PopulateCategories();
            PopulateSubCategoryGrid();
        }
        private Categories Initializer()
        {
            var catgories = new Categories
            {
                CatId = cmbCategories.Enabled ? (Int32)cmbCategories.SelectedValue : 0,
                CatName = tbCategories.Text
            };
            return catgories;
        }

        public void SaveCategories(Categories model)
        {         
                SqlParameter[] param =
                {
                    _oDbHelper.InParam(CatId, SqlDbType.Int, 4, model.CatId),

                    _oDbHelper.InParam(CatName, SqlDbType.NVarChar, 50, model.CatName),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                };
               var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspCategoriesSave", RetVal, param);    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var a = cmbCategories.SelectedValue;
            //MessageBox.Show("" + a);
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Categories categories;
                var id = (int)cmbCategories.SelectedValue;
                categories = GetById(id);
                tbCategories.Text = categories.CatName;
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Category Loading Failed."+ex);
            }
        }
        public Categories GetById(int id)
        {
            SqlParameter[] pram =
            {
                _oDbHelper.InParam(CatId,SqlDbType.Int,4,id)
            };
            var list = _oDbHelper.GenericSqlDataReader<Categories>("uspGetAllCategories", pram).FirstOrDefault();
            return list;
        }
    }



}

