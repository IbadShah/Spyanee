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
        private const string SubCatId = "@SubCatId";
        private const string Item = "@Item";
        private const string Quantity = "@Quantity";
        private const string Units = "@Units";
        private const string UnitRate = "@UnitRate";
        private const string Amount = "@Amount";


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
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();

          
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();

        }

        private void Admin_View_Load(object sender, EventArgs e)
        {

            DataLoader();
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();
          

        }

      

        private void button4_Click(object sender, EventArgs e)
        {

            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmLogin fm = new frmLogin();
            this.Hide();
            fm.Show();

        }

        private void Admin_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CustomMessageBox customMessageBox = new CustomMessageBox();

            //customMessageBox.Show();
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
            //PopulateItems();
            //PopulateCategories();
            //PopulateSubCategoryGrid();
        }

        public void PopulateItems()
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt = _oDbHelper.GetDataTable("uspGetAllSubCategories");
                cmbItem.DataSource = dt;
                cmbItem.DisplayMember = "Item";
                cmbItem.ValueMember = "SubCatId";
                _oDbHelper.CloseConnection();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Loading Items."+ex);
            }
        }

        private Categories Initializer()
        {
            var catgories = new Categories
            {
                CatId = cmbCategories.Enabled ? (int)cmbCategories.SelectedValue : 0,
                CatName = tbCategories.Text
            };
            return catgories;
        }
        private SubCategories Initializer1()
        {
            var subCatgories = new SubCategories
            {
                SubCatId = cmbItem.Enabled ? (int)cmbItem.SelectedValue : 0,
                SubCateName = Convert.ToString(tbItem.Text)

            };
            return subCatgories;
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

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                _oDbHelper.OpenConnection();
                var subCategories = Initializer1();
                SaveSubCategories(subCategories);
                _oDbHelper.CloseConnection();
                MessageBox.Show("Item is Successfully Inserted.");
                DataLoader();
                cmbItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item is not Inserted."+ex);
            }
        }
        public void SaveSubCategories(SubCategories subCategories)
        {
            //SqlParameter[] param =
            // {
            //        _oDbHelper.InParam(SubCatId, SqlDbType.Int, 4, subCategories.SubCatId),
            //        _oDbHelper.InParam(Item, SqlDbType.NVarChar, 50, subCategories.Item),
            //        _oDbHelper.InParam(Quantity,SqlDbType.Decimal,18,subCategories.Quantity),
            //        _oDbHelper.InParam(Units,SqlDbType.NVarChar,50,subCategories.Units),
            //        _oDbHelper.InParam(UnitRate,SqlDbType.Decimal,18,subCategories.UnitRate),
            //        _oDbHelper.InParam(Amount,SqlDbType.Decimal,18,subCategories.Amount),
            //        _oDbHelper.InParam(CatId,SqlDbType.Int,4,subCategories.CatId),
            //        _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
            // };
            //   var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspSubCategoriesSave", RetVal, param);
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            cmbItem.Enabled = false;
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Show();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();
           
        }

        private void btnAddPacking_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Show();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Show();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();
          
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Show();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();
       
        }

        private void btnSaleOrder_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Show();
            pnlSaleInvoice.Hide();
           
        }

        private void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Show();
            
        }
    }



}

