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
        private const string PackingId = "@PackingId";
        private const string PackingName = "@PackingName";
        private const string UnitId = "@UnitId";
        private const string UnitName = "@UnitName";
        private const string RetVal = "@RetVal";
        private const string SubCatId = "@SubCatId";
        private const string SubCatName = "@SubCatName";
        private const string Quantity = "@Quantity";
        private const string Units = "@Units";
        private const string UnitRate = "@UnitRate";
        private const string Amount = "@Amount";
        private const string IsActive = "@IsActive";
        private const string CreatedBy = "@CreatedBy";
        private const string UpdatedBy = "@UpdatedBy";

        #endregion
        private readonly DbHelper _oDbHelper = new DbHelper();
        public int adminId = 1;
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
            cmbCategories.Text = "";
            tbCategories.Text = "";
            chkCategoryIsActive.Checked = false;
         
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cmbCategories.Enabled)
                {
                    if (tbCategories.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var catgories = Initializer();
                        SaveCategories(catgories);
                        _oDbHelper.CloseConnection();
                        cmbCategories.Enabled = true;
                        MessageBox.Show("Category Record is Inserted.");
                        PopulateCategories();
                    }
                    else
                    {
                        MessageBox.Show("Please Insert Record.");
                    }
                }
                else
                {
                    MessageBox.Show("Press New Before Entering New Category Record.");
                }
            }   
            
                 catch (Exception ex)
            {
                cmbCategories.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
          
        }
        public void PopulateCategories()
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt=_oDbHelper.GetDataTable("uspGetAllCategories");
                //Purchase Order Category cmb
                cmbSelectCatPurchaseOrder.DataSource = dt;
                cmbSelectCatPurchaseOrder.DisplayMember = "CatName";
                cmbSelectCatPurchaseOrder.ValueMember = "CatId";
                //Category Screen Order Category cmb
                cmbCategories.DataSource = dt;
                cmbCategories.DisplayMember = "CatName";
                cmbCategories.ValueMember = "CatId";
                cmbCategories.SelectedText = "--Select Category--";
      
                //Purchase Invoice Category cmb
                cmbPurInvCat.DataSource = dt;
                cmbPurInvCat.DisplayMember = "CatName";
                cmbPurInvCat.ValueMember = "CatId";
                //Sale Invoice Category cmb
                cmbSaleInvCat.DataSource = dt;
                cmbSaleInvCat.DisplayMember = "CatName";
                cmbSaleInvCat.ValueMember = "CatId";
                //Sale Order Category cmb
                cmbSalOrderCat.DataSource = dt;
                cmbSalOrderCat.DisplayMember = "CatName";
                cmbSalOrderCat.ValueMember = "CatId";
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
            PopulateItems();
            PopulateCategories();
            PopulatePackings();
            PopulateUnits();
        }
        public void PopulatePackings()
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt = _oDbHelper.GetDataTable("uspGetAllPackings");
                //Purchase Order Packing cmb
                cmbPurOrderPacking.DataSource = dt;
                cmbPurOrderPacking.DisplayMember = "PackingName";
                cmbPurOrderPacking.ValueMember = "PackingId";
                //Packing Screen Packing cmb
                cmbPacking.DataSource = dt;
                cmbPacking.DisplayMember = "PackingName";
                cmbPacking.ValueMember = "PackingId";
                //Purchase Invoice Packing cmb
                cmbPurInvPacking.DataSource = dt;
                cmbPurInvPacking.DisplayMember = "PackingName";
                cmbPurInvPacking.ValueMember = "PackingId";
                //Sale Invoice Packing cmb
                cmbSaleInvPacking.DataSource = dt;
                cmbSaleInvPacking.DisplayMember = "PackingName";
                cmbSaleInvPacking.ValueMember = "PackingId";
                //Sale Order Packing cmb
                cmbSalOrderPacking.DataSource = dt;
                cmbSalOrderPacking.DisplayMember = "PackingName";
                cmbSalOrderPacking.ValueMember = "PackingId";
                _oDbHelper.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Loading Items." + ex);
            }
        }
        public void PopulateUnits()
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt = _oDbHelper.GetDataTable("uspGetAllUnits");
                //Purchase Order Unit cmb
                cmbPurOrderUnit.DataSource = dt;
                cmbPurOrderUnit.DisplayMember = "UnitName";
                cmbPurOrderUnit.ValueMember = "UnitId";
                //Unit Screen Unit cmb
                cmbUnit.DataSource = dt;
                cmbUnit.DisplayMember = "UnitName";
                cmbUnit.ValueMember = "UnitId";
                //Purchase Invoice Unit cmb
                cmbPurInvUnit.DataSource = dt;
                cmbPurInvUnit.DisplayMember = "UnitName";
                cmbPurInvUnit.ValueMember = "UnitId";
                //Sale Invoice Unit cmb
                cmbSaleInvUnit.DataSource = dt;
                cmbSaleInvUnit.DisplayMember = "UnitName";
                cmbSaleInvUnit.ValueMember = "UnitId";
                //Sale order Unit cmb
                cmbSalOrderUnit.DataSource = dt;
                cmbSalOrderUnit.DisplayMember = "UnitName";
                cmbSalOrderUnit.ValueMember = "UnitId";
                _oDbHelper.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Loading Items." + ex);
            }
        }
        public void PopulateItems()
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt = _oDbHelper.GetDataTable("uspGetAllSubCategories");
                //Purchase Order SubCategory cmb
                cmbSelectSubCatPurchaseOrder.DataSource = dt;
                cmbSelectSubCatPurchaseOrder.DisplayMember = "SubCatName";
                cmbSelectSubCatPurchaseOrder.ValueMember = "SubCatId";
                //Purchase Invoice SubCategory cmb
                cmbPurInvSubCat.DataSource = dt;
                cmbPurInvSubCat.DisplayMember = "SubCatName";
                cmbPurInvSubCat.ValueMember = "SubCatId";
                //Item Screen SubCategory cmb
                cmbItem.DataSource = dt;
                cmbItem.DisplayMember = "SubCatName";
                cmbItem.ValueMember = "SubCatId";
                //Sale Order SubCategory cmb
                cmbSalOrderSubCat.DataSource = dt;
                cmbSalOrderSubCat.DisplayMember = "SubCatName";
                cmbSalOrderSubCat.ValueMember = "SubCatId";
                //Sale Invoice SubCategory cmb
                cmbSaleInvSubCat.DataSource = dt;
                cmbSaleInvSubCat.DisplayMember = "SubCatName";
                cmbSaleInvSubCat.ValueMember = "SubCatId";
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
                CatName = tbCategories.Text,
                IsActive = chkCategoryIsActive.Checked,
                CreatedBy = adminId,
                UpdatedBy=adminId
            };
            return catgories;
        }
        private SubCategories Initializer1()
        {
            var subCatgories = new SubCategories
            {
                SubCatId = cmbItem.Enabled ? (int)cmbItem.SelectedValue : 0,
                SubCatName =tbItem.Text,
                IsActive = chkItemIsActive.Checked,
                CreatedBy = adminId,
                UpdatedBy = adminId

            };
            return subCatgories;
        }
        public void SaveCategories(Categories model)
        {         
                SqlParameter[] param =
                {
                    _oDbHelper.InParam(CatId, SqlDbType.Int, 4, model.CatId),

                    _oDbHelper.InParam(CatName, SqlDbType.NVarChar, 50, model.CatName),

                    _oDbHelper.InParam(IsActive,SqlDbType.Bit,1,model.IsActive),

                    _oDbHelper.InParam(CreatedBy,SqlDbType.Int,4,model.CreatedBy),

                    _oDbHelper.InParam(UpdatedBy,SqlDbType.Int,4,model.UpdatedBy),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                };
               var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspCategoriesSave", RetVal, param);    
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategories.Enabled)
                {
                    if (cmbCategories.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var catgories = Initializer();
                        SaveCategories(catgories);
                        _oDbHelper.CloseConnection();
                        cmbCategories.Enabled = true;
                        MessageBox.Show("Category Record is Updated.");
                        PopulateCategories();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Category.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Category Before Update Record.");
                }
            }

            catch (Exception ex)
            {
                cmbCategories.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }
        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Categories categories;
                var id = (int)cmbCategories.SelectedValue;
                categories = GetById(id);
                tbCategories.Text = categories.CatName;
                chkCategoryIsActive.Checked = categories.IsActive;
            }
            catch(Exception ex)
            {
               // MessageBox.Show("Category Loading Failed."+ex);
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
        public SubCategories subCategoryGetById(int id)
        {
            SqlParameter[] pram =
            {
                _oDbHelper.InParam(SubCatId,SqlDbType.Int,4,id)
            };
            var list = _oDbHelper.GenericSqlDataReader<SubCategories>("uspGetAllSubCategories", pram).FirstOrDefault();
            return list;
        }
        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cmbItem.Enabled)
                {
                    _oDbHelper.OpenConnection();
                    var subCategories = Initializer1();
                    SaveSubCategories(subCategories);
                    _oDbHelper.CloseConnection();
                    MessageBox.Show("Item is Successfully Inserted.");
                    DataLoader();
                    cmbItem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Press New Before Entering New Item Record.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item is not Inserted."+ex);
            }
        }
        public void SaveSubCategories(SubCategories subCategories)
        {
            SqlParameter[] param =
             {
                    _oDbHelper.InParam(SubCatId, SqlDbType.Int, 4, subCategories.SubCatId),

                    _oDbHelper.InParam(SubCatName, SqlDbType.NVarChar, 50, subCategories.SubCatName),

                    _oDbHelper.InParam(IsActive,SqlDbType.Bit,1,subCategories.IsActive),

                    _oDbHelper.InParam(CreatedBy,SqlDbType.Int,4,subCategories.CreatedBy),

                    _oDbHelper.InParam(UpdatedBy,SqlDbType.Int,4,subCategories.UpdatedBy),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                    
             };
            var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspSubCategoriesSave", RetVal, param);
        }
        private void btnNewItem_Click(object sender, EventArgs e)
        {
            cmbItem.Enabled = false;
            cmbItem.Text = "";
            tbItem.Text = "";
            chkItemIsActive.Checked = false;
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

        private void btnCategoriesClear_Click(object sender, EventArgs e)
        {
            tbCategories.Text = "";
            cmbCategories.Text = "";
            chkCategoryIsActive.Checked = false;
            cmbCategories.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategories.Text != "")
                {
                    _oDbHelper.OpenConnection();
                    int id = (int)cmbCategories.SelectedValue;
                    DeleteCategory(id);
                    _oDbHelper.CloseConnection();
                    MessageBox.Show("Category Record is Deleted Successfully.");
                    PopulateCategories();
                }
                else
                {
                    MessageBox.Show("Please Select Category to Deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete."+ex);
                _oDbHelper.CloseConnection();
            }

        }
        public void DeleteCategory(int id)
        {
            SqlParameter[] param =
           {
                _oDbHelper.InParam(CatId, SqlDbType.Int, 4, id)

            };

            _oDbHelper.ExecuteScalar("uspDeleteCategory", param);
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItem.SelectedValue != null)
                {
                    _oDbHelper.OpenConnection();
                    SubCategories subCategories;
                    var id = (int)cmbItem.SelectedValue;
                    subCategories = subCategoryGetById(id);
                    tbItem.Text = subCategories.SubCatName;
                    chkItemIsActive.Checked = subCategories.IsActive;
                    _oDbHelper.CloseConnection();
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tbItem.Text = "";
            chkItemIsActive.Checked = false;
            cmbItem.Text = "";
            cmbItem.Enabled = true;
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
           try
            {
                _oDbHelper.OpenConnection();
                var subCategories = Initializer1();
                SaveSubCategories(subCategories);
                _oDbHelper.CloseConnection();
                cmbItem.Enabled = true;
                MessageBox.Show("Item Record is Updated.");
                PopulateItems();
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }
    }



}

