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

        //Global Variables

        private readonly DbHelper _oDbHelper = new DbHelper();
        public int adminId = 1;

        //Global Variables END
        public AdminView()
        {
            InitializeComponent();
        }
       
        //Admin Main Form
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
        //Admin Main Form END


        

        //Data Poupulatuion methods START
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
                cmbSelectCatPurchaseOrder.SelectedIndex = -1;
                //Category Screen Order Category cmb
                cmbCategories.DataSource = dt;
                cmbCategories.DisplayMember = "CatName";
                cmbCategories.ValueMember = "CatId";
                cmbCategories.SelectedIndex = -1;
      
                //Purchase Invoice Category cmb
                cmbPurInvCat.DataSource = dt;
                cmbPurInvCat.DisplayMember = "CatName";
                cmbPurInvCat.ValueMember = "CatId";
                cmbPurInvCat.SelectedIndex = -1;
                //Sale Invoice Category cmb
                cmbSaleInvCat.DataSource = dt;
                cmbSaleInvCat.DisplayMember = "CatName";
                cmbSaleInvCat.ValueMember = "CatId";
                cmbSaleInvCat.SelectedIndex = -1;
                //Sale Order Category cmb
                cmbSalOrderCat.DataSource = dt;
                cmbSalOrderCat.DisplayMember = "CatName";
                cmbSalOrderCat.ValueMember = "CatId";
                cmbSalOrderCat.SelectedIndex = -1;
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
                cmbPurOrderPacking.SelectedIndex = -1;
                //Packing Screen Packing cmb
                cmbPacking.DataSource = dt;
                cmbPacking.DisplayMember = "PackingName";
                cmbPacking.ValueMember = "PackingId";
                cmbPacking.SelectedIndex = -1;
                //Purchase Invoice Packing cmb
                cmbPurInvPacking.DataSource = dt;
                cmbPurInvPacking.DisplayMember = "PackingName";
                cmbPurInvPacking.ValueMember = "PackingId";
                cmbPurInvPacking.SelectedIndex = -1;
                //Sale Invoice Packing cmb
                cmbSaleInvPacking.DataSource = dt;
                cmbSaleInvPacking.DisplayMember = "PackingName";
                cmbSaleInvPacking.ValueMember = "PackingId";
                cmbSaleInvPacking.SelectedIndex = -1;
                //Sale Order Packing cmb
                cmbSalOrderPacking.DataSource = dt;
                cmbSalOrderPacking.DisplayMember = "PackingName";
                cmbSalOrderPacking.ValueMember = "PackingId";
                cmbSalOrderPacking.SelectedIndex = -1;
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
                cmbPurOrderUnit.SelectedIndex = -1;
                //Unit Screen Unit cmb
                cmbUnit.DataSource = dt;
                cmbUnit.DisplayMember = "UnitName";
                cmbUnit.ValueMember = "UnitId";
                cmbUnit.SelectedIndex = -1;
                //Purchase Invoice Unit cmb
                cmbPurInvUnit.DataSource = dt;
                cmbPurInvUnit.DisplayMember = "UnitName";
                cmbPurInvUnit.ValueMember = "UnitId";
                cmbPurInvUnit.SelectedIndex = -1;
                //Sale Invoice Unit cmb
                cmbSaleInvUnit.DataSource = dt;
                cmbSaleInvUnit.DisplayMember = "UnitName";
                cmbSaleInvUnit.ValueMember = "UnitId";
                cmbSaleInvUnit.SelectedIndex = -1;
                //Sale order Unit cmb
                cmbSalOrderUnit.DataSource = dt;
                cmbSalOrderUnit.DisplayMember = "UnitName";
                cmbSalOrderUnit.ValueMember = "UnitId";
                cmbSalOrderUnit.SelectedIndex = -1;
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
                cmbSelectSubCatPurchaseOrder.SelectedIndex = -1;
                //Purchase Invoice SubCategory cmb
                cmbPurInvSubCat.DataSource = dt;
                cmbPurInvSubCat.DisplayMember = "SubCatName";
                cmbPurInvSubCat.ValueMember = "SubCatId";
                cmbPurInvSubCat.SelectedIndex = -1;
                //Item Screen SubCategory cmb
                cmbItem.DataSource = dt;
                cmbItem.DisplayMember = "SubCatName";
                cmbItem.ValueMember = "SubCatId";
                cmbItem.SelectedIndex = -1;
                //Sale Order SubCategory cmb
                cmbSalOrderSubCat.DataSource = dt;
                cmbSalOrderSubCat.DisplayMember = "SubCatName";
                cmbSalOrderSubCat.ValueMember = "SubCatId";
                cmbSalOrderSubCat.SelectedIndex = -1;
                //Sale Invoice SubCategory cmb
                cmbSaleInvSubCat.DataSource = dt;
                cmbSaleInvSubCat.DisplayMember = "SubCatName";
                cmbSaleInvSubCat.ValueMember = "SubCatId";
                cmbSaleInvSubCat.SelectedIndex = -1;
                _oDbHelper.CloseConnection();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Loading Items."+ex);
            }
        }
        public void PopulateGvPurchaseOrder()
        {
            gvPurchaseOrder.DataSource = PurchaseOrderDataTable();
        }
     public DataTable PurchaseOrderDataTable()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitRate", typeof(decimal));
            dt.Columns.Add("Discount", typeof(decimal));
            dt.Columns.Add("TotalAmount", typeof(decimal));
            dt.Columns.Add("AmountReceived", typeof(decimal));
            dt.Columns.Add("RemainingAmount", typeof(decimal));
            dt.Columns["Discount"].DefaultValue = 0;
            return dt;
        }
        //public void Populte

        //Data Poupulatuion methods END


        //Model Initializer
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
        private Unit InitializerUnit()
        {
            var unit = new Unit
            {
                UnitId = cmbUnit.Enabled ? (int)cmbUnit.SelectedValue : 0,
                UnitName = tbUnit.Text,
                IsActive = chkUnitIsAcive.Checked,
                CreatedBy = adminId,
                UpdatedBy = adminId
            };
            return unit;
        }
        private Packing InitializerPacking()
        {
            var packing = new Packing
            {
                PackingId = cmbPacking.Enabled ? (int)cmbPacking.SelectedValue : 0,
                PackingName = tbPacking.Text,
                IsActive = chkPackingIsActive.Checked,
                CreatedBy = adminId,
                UpdatedBy = adminId
            };
            return packing;
        }
        //Model Initializer END


        //Save Methods START
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
        public void SaveUnit(Unit model)
        {
            SqlParameter[] param =
            {
                    _oDbHelper.InParam(UnitId, SqlDbType.Int, 4, model.UnitId),

                    _oDbHelper.InParam(UnitName, SqlDbType.NVarChar, 50, model.UnitName),

                    _oDbHelper.InParam(IsActive,SqlDbType.Bit,1,model.IsActive),

                    _oDbHelper.InParam(CreatedBy,SqlDbType.Int,4,model.CreatedBy),

                    _oDbHelper.InParam(UpdatedBy,SqlDbType.Int,4,model.UpdatedBy),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                };
            var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspUnitSave", RetVal, param);
        }
        public void SavePacking(Packing model)
        {
            SqlParameter[] param =
            {
                    _oDbHelper.InParam(PackingId, SqlDbType.Int, 4, model.PackingId),

                    _oDbHelper.InParam(PackingName, SqlDbType.NVarChar, 50, model.PackingName),

                    _oDbHelper.InParam(IsActive,SqlDbType.Bit,1,model.IsActive),

                    _oDbHelper.InParam(CreatedBy,SqlDbType.Int,4,model.CreatedBy),

                    _oDbHelper.InParam(UpdatedBy,SqlDbType.Int,4,model.UpdatedBy),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                };
            var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspPackingSave", RetVal, param);
        }
        //Save Methods END


        //Category Screen Buttons START
        private void btnNew_Click(object sender, EventArgs e)
        {
            New(cmbCategories, tbCategories, chkCategoryIsActive);
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
        private void cmbCategories_TextChanged(object sender, EventArgs e)
        {
            CmbSelectedText("--Select Category--", cmbCategories);
        }
        //Category Screen Buttons END

        //Get Models Methods
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
        public Packing PackingGetById(int id)
        {
            SqlParameter[] pram =
            {
                _oDbHelper.InParam(PackingId,SqlDbType.Int,4,id)
            };
            var list = _oDbHelper.GenericSqlDataReader<Packing>("uspGetAllPackings", pram).FirstOrDefault();
            return list;
        }
        public Unit UnitGetById(int id)
        {
            SqlParameter[] pram =
            {
                _oDbHelper.InParam(UnitId,SqlDbType.Int,4,id)
            };
            var list = _oDbHelper.GenericSqlDataReader<Unit>("uspGetAllUnits", pram).FirstOrDefault();
            return list;
        }
        //Get Models Methods End
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
           New(cmbItem, tbItem, chkItemIsActive);
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
            Clear(tbCategories,chkCategoryIsActive,cmbCategories);
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

        //Delete Methods START
        public void DeleteCategory(int id)
        {
            SqlParameter[] param =
           {
                _oDbHelper.InParam(CatId, SqlDbType.Int, 4, id)

            };

            _oDbHelper.ExecuteScalar("uspDeleteCategory", param);
        }
        public void DeleteItem(int id)
        {
            SqlParameter[] param =
           {
                _oDbHelper.InParam(SubCatId, SqlDbType.Int, 4, id)

            };

            _oDbHelper.ExecuteScalar("uspDeleteSubCategory", param);
        }
        public void DeleteUnit(int id)
        {
            SqlParameter[] param =
           {
                _oDbHelper.InParam(UnitId, SqlDbType.Int, 4, id)

            };

            _oDbHelper.ExecuteScalar("uspDeleteUnit", param);
        }
        public void DeletePacking(int id)
        {
            SqlParameter[] param =
           {
                _oDbHelper.InParam(PackingId, SqlDbType.Int, 4, id)

            };

            _oDbHelper.ExecuteScalar("uspDeletePacking", param);
        }
        //Delete Methods END
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
            cmbItem.SelectedIndex = -1;
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

     

        private void cmbItem_TextChanged(object sender, EventArgs e)
        {
            CmbSelectedText("--Select Item--", cmbItem);
        }

        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            New(cmbUnit,tbUnit,chkUnitIsAcive);
        }

        private void cmbUnit_TextChanged(object sender, EventArgs e)
        {
            CmbSelectedText("--Select Unit--", cmbUnit);
        }
        public void CmbSelectedText(string selectedText,ComboBox cmb)
        {
         
            if(cmb.SelectedIndex<0)
            {
                cmb.Text = selectedText;
            }
            else
            {
                cmb.Text = cmb.SelectedText;
            }
        }
        private void btnUnitClear_Click(object sender, EventArgs e)
        {
            Clear(tbUnit, chkUnitIsAcive, cmbUnit);
        }

        /// <summary>
        /// /*New Button Method*/
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="tb"></param>
        /// <param name="chk"></param>
        public void New(ComboBox cmb,TextBox tb,CheckBox chk)
        {
            cmb.Enabled = false;
         
            cmb.SelectedIndex = -1;
            tb.Text = "";
            chk.Checked = false;
        }

        /// <summary>
        /// /*Clear Button Method*/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
       
        public void Clear(TextBox tb,CheckBox chk,ComboBox cmb)
        {
            tb.Text = "";
            cmb.SelectedIndex = -1;
            chk.Checked = false;
            cmb.Enabled = true;
        }



        //unit screen Buttons START
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbItem.Text != "")
                {
                    _oDbHelper.OpenConnection();
                    int id = (int)cmbItem.SelectedValue;
                    DeleteItem(id);
                    _oDbHelper.CloseConnection();
                    MessageBox.Show("Item Record is Deleted Successfully.");
                    PopulateItems();
                }
                else
                {
                    MessageBox.Show("Please Select Item to Deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnUnitSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cmbUnit.Enabled)
                {
                    if (tbUnit.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var unit = InitializerUnit();
                        SaveUnit(unit);
                        _oDbHelper.CloseConnection();
                        cmbUnit.Enabled = true;
                        MessageBox.Show("Category Record is Inserted.");
                        PopulateUnits();
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
                cmbUnit.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnUnitUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUnit.Enabled)
                {
                    if (cmbUnit.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var unit = InitializerUnit();
                        SaveUnit(unit);
                        _oDbHelper.CloseConnection();
                        cmbUnit.Enabled = true;
                        MessageBox.Show("Unit Record is Updated.");
                        PopulateUnits();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Unit.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Unit Before Update Record.");
                }
            }

            catch (Exception ex)
            {
                cmbUnit.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnUnitDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUnit.Text != "")
                {
                    _oDbHelper.OpenConnection();
                    int id = (int)cmbUnit.SelectedValue;
                    DeleteUnit(id);
                    _oDbHelper.CloseConnection();
                    MessageBox.Show("Unit Record is Deleted Successfully.");
                    PopulateUnits();
                }
                else
                {
                    MessageBox.Show("Please Select Unit to Deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete." + ex);
                _oDbHelper.CloseConnection();
            }

        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbUnit.SelectedValue != null)
                {
                    _oDbHelper.OpenConnection();
                    Unit unit;
                    var id = (int)cmbUnit.SelectedValue;
                    unit = UnitGetById(id);
                    tbUnit.Text = unit.UnitName;
                    chkUnitIsAcive.Checked = unit.IsActive;
                    _oDbHelper.CloseConnection();
                }
            }
            catch (Exception ex)
            {

            }
        }

        //unit screen Buttons END


        //packing screen Buttons START
        private void btnPackingNew_Click(object sender, EventArgs e)
        {
            New(cmbPacking, tbPacking, chkPackingIsActive);
        }

        private void btnPackingSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cmbPacking.Enabled)
                {
                    if (tbPacking.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var packing = InitializerPacking();
                        SavePacking(packing);
                        _oDbHelper.CloseConnection();
                        cmbPacking.Enabled = true;
                        MessageBox.Show("Packing Record is Inserted.");
                        PopulatePackings();
                    }
                    else
                    {
                        MessageBox.Show("Please Insert Record.");
                    }
                }
                else
                {
                    MessageBox.Show("Press New Before Entering New Packing Record.");
                }
            }

            catch (Exception ex)
            {
                cmbPacking.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnPackingUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPacking.Enabled)
                {
                    if (cmbPacking.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var packing = InitializerPacking();
                        SavePacking(packing);
                        _oDbHelper.CloseConnection();
                        cmbPacking.Enabled = true;
                        MessageBox.Show("Packing Record is Updated.");
                        PopulatePackings();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Packing.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Packing Before Update Record.");
                }
            }

            catch (Exception ex)
            {
                cmbUnit.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnPackingClear_Click(object sender, EventArgs e)
        {
            Clear(tbPacking,chkPackingIsActive,cmbPacking);
        }

        private void btnPackingDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPacking.Text != "")
                {
                    _oDbHelper.OpenConnection();
                    int id = (int)cmbPacking.SelectedValue;
                    DeletePacking(id);
                    _oDbHelper.CloseConnection();
                    MessageBox.Show("Packing Record is Deleted Successfully.");
                    PopulatePackings();
                }
                else
                {
                    MessageBox.Show("Please Select Packing to Deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete." + ex);
                _oDbHelper.CloseConnection();
            }

        }

        private void cmbPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPacking.SelectedValue != null)
                {
                    _oDbHelper.OpenConnection();
                    Packing packing;
                    var id = (int)cmbPacking.SelectedValue;
                    packing = PackingGetById(id);
                    tbPacking.Text = packing.PackingName;
                    chkPackingIsActive.Checked = packing.IsActive;
                    _oDbHelper.CloseConnection();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }


        //packing screen Buttons END

    }



}

