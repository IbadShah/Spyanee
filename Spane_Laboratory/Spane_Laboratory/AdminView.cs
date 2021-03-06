﻿using System;
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
        private const string VendorId = "@VendorId";
        private const string VendorName = "@VendorName";
        private const string VendorContactNumber = "@VendorContactNumber";
        private const string VendorAddress = "@VendorAddress";
        private const string PurchaseOrderCode = "@PurchaseOrderCode";
        private const string SaleOrderCode = "@SaleOrderCode";
        private const string IsActive = "@IsActive";
        private const string CreatedBy = "@CreatedBy";
        private const string UpdatedBy = "@UpdatedBy";
        private const string purchaseOrderTable = "@purchaseOrderTable";
        private const string saleOrderTable = "@saleOrderTable";
        private const string ClassId = "@ClassId";
        private const string ClassName = "@ClassName";
        private const string CustomerId = "@CustomerId";
        private const string CustomerName = "@CustomerName";
        private const string CustomerContactNumber = "@CustomerContactNumber";
        private const string CustomerAddress = "@CustomerAddress";
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
            pnlClass.Hide();
            pnlClass.Hide();
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
            pnlClass.Hide();
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
            pnlClass.Hide();
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
            pnlClass.Hide();
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
        public void PopulateStandard() {
            try {
                _oDbHelper.OpenConnection();
                var dt = _oDbHelper.GetDataTable("uspGetAllStandard");
                //Class cmb
                cmbAddClass.DataSource = dt;
                cmbAddClass.DisplayMember = "ClassName";
                cmbAddClass.ValueMember = "ClassId";
                cmbAddClass.SelectedIndex = -1;
               }
            catch (Exception ex) {
                MessageBox.Show("Unable to Load Class." + ex);
                _oDbHelper.CloseConnection();

            }


        }
        public void PopulatePurchaseRate(SqlParameter[]param)
        {
            try
            {
                _oDbHelper.OpenConnection();
                var dt = _oDbHelper.GetDataTable("uspGetPurchaseRate",param);
                //Class cmb
                cmbPurchaseRate.DataSource = dt;
                cmbPurchaseRate.DisplayMember = "UnitRate";
        
                cmbPurchaseRate.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Load Class." + ex);
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
                cmbSelectCatPurchaseOrder.SelectedIndex = -1;
                //Category Screen Order Category cmb
                cmbCategories.DataSource = dt;
                cmbCategories.DisplayMember = "CatName";
                cmbCategories.ValueMember = "CatId";
                cmbCategories.SelectedIndex = -1;
      
                //Purchase Invoice Category cmb
                cmbSelectCatPurchaseInvoice.DataSource = dt;
                cmbSelectCatPurchaseInvoice.DisplayMember = "CatName";
                cmbSelectCatPurchaseInvoice.ValueMember = "CatId";
                cmbSelectCatPurchaseInvoice.SelectedIndex = -1;
                //Sale Invoice Category cmb
                cmbSelectCatSaleInvoice.DataSource = dt;
                cmbSelectCatSaleInvoice.DisplayMember = "CatName";
                cmbSelectCatSaleInvoice.ValueMember = "CatId";
                cmbSelectCatSaleInvoice.SelectedIndex = -1;
                //Sale Order Category cmb
                cmbSelectCatSaleOrder.DataSource = dt;
                cmbSelectCatSaleOrder.DisplayMember = "CatName";
                cmbSelectCatSaleOrder.ValueMember = "CatId";
                cmbSelectCatSaleOrder.SelectedIndex = -1;
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
            PopulateStandard();
            PopulateItems();
            PopulateCategories();
            PopulatePackings();
            PopulateUnits();
            SetPurchaseOrderCode();
            SetPurchaseInvoiceCode();
            SetSaleOrderCode();
            PopulateGvPurchaseOrder();
            PopulateGvSaleOrder();
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
                cmbSelectPackingPurchaseInvoice.DataSource = dt;
                cmbSelectPackingPurchaseInvoice.DisplayMember = "PackingName";
                cmbSelectPackingPurchaseInvoice.ValueMember = "PackingId";
                cmbSelectPackingPurchaseInvoice.SelectedIndex = -1;
                //Sale Invoice Packing cmb
                cmbSelectPackingSaleInvoice.DataSource = dt;
                cmbSelectPackingSaleInvoice.DisplayMember = "PackingName";
                cmbSelectPackingSaleInvoice.ValueMember = "PackingId";
                cmbSelectPackingSaleInvoice.SelectedIndex = -1;
                //Sale Order Packing cmb
                cmbSaleOrderPacking.DataSource = dt;
                cmbSaleOrderPacking.DisplayMember = "PackingName";
                cmbSaleOrderPacking.ValueMember = "PackingId";
                cmbSaleOrderPacking.SelectedIndex = -1;
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
                cmbSelectUnitPurchaseInvoice.DataSource = dt;
                cmbSelectUnitPurchaseInvoice.DisplayMember = "UnitName";
                cmbSelectUnitPurchaseInvoice.ValueMember = "UnitId";
                cmbSelectUnitPurchaseInvoice.SelectedIndex = -1;
                //Sale Invoice Unit cmb
                cmbSelectUnitSaleInvoice.DataSource = dt;
                cmbSelectUnitSaleInvoice.DisplayMember = "UnitName";
                cmbSelectUnitSaleInvoice.ValueMember = "UnitId";
                cmbSelectUnitSaleInvoice.SelectedIndex = -1;
                //Sale order Unit cmb
                cmbSaleOrderUnit.DataSource = dt;
                cmbSaleOrderUnit.DisplayMember = "UnitName";
                cmbSaleOrderUnit.ValueMember = "UnitId";
                cmbSaleOrderUnit.SelectedIndex = -1;
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
                cmbSelectSubCatPurchaseInvoice.DataSource = dt;
                cmbSelectSubCatPurchaseInvoice.DisplayMember = "SubCatName";
                cmbSelectSubCatPurchaseInvoice.ValueMember = "SubCatId";
                cmbSelectSubCatPurchaseInvoice.SelectedIndex = -1;
                //Item Screen SubCategory cmb
                cmbItem.DataSource = dt;
                cmbItem.DisplayMember = "SubCatName";
                cmbItem.ValueMember = "SubCatId";
                cmbItem.SelectedIndex = -1;
                //Sale Order SubCategory cmb
                cmbSelectSubCatSaleOrder.DataSource = dt;
                cmbSelectSubCatSaleOrder.DisplayMember = "SubCatName";
                cmbSelectSubCatSaleOrder.ValueMember = "SubCatId";
                cmbSelectSubCatSaleOrder.SelectedIndex = -1;
                //Sale Invoice SubCategory cmb
                cmbSelectSubCatSaleInvoice.DataSource = dt;
                cmbSelectSubCatSaleInvoice.DisplayMember = "SubCatName";
                cmbSelectSubCatSaleInvoice.ValueMember = "SubCatId";
                cmbSelectSubCatSaleInvoice.SelectedIndex = -1;
                _oDbHelper.CloseConnection();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Loading Items."+ex);
            }
        }
        public void PopulateGvPurchaseOrder()
        {
         
         
            gvPurchaseOrder.ColumnCount = 10;
            gvPurchaseOrder.Columns[0].Name = "PurchaseOrderId";
            gvPurchaseOrder.Columns[0].Visible = false;
            gvPurchaseOrder.Columns[1].Name = "CatName";
            gvPurchaseOrder.Columns[2].Name = "SubCatName";
            gvPurchaseOrder.Columns[3].Name = "UnitName";
            gvPurchaseOrder.Columns[4].Name = "PackingName";
            gvPurchaseOrder.Columns[5].Name = "Quantity";
            gvPurchaseOrder.Columns[6].Name = "UnitRate";
            gvPurchaseOrder.Columns[7].Name = "TotalAmount";
            gvPurchaseOrder.Columns[8].Name = "AmountReceived";
            gvPurchaseOrder.Columns[9].Name = "RemainingAmount";
            gvPurchaseOrder.Columns[0].Width = 124;
            gvPurchaseOrder.Columns[1].Width = 124;
            gvPurchaseOrder.Columns[2].Width = 124;
            gvPurchaseOrder.Columns[3].Width = 124;
            gvPurchaseOrder.Columns[6].Width = 124;
            gvPurchaseOrder.Columns[9].Width =  128;

        }
        public void PopulateGvSaleOrder()
        {


            gvSaleOrder.ColumnCount = 13;
            gvSaleOrder.Columns[0].Name = "SaleOrderId";
            gvSaleOrder.Columns[0].Visible = false;
            gvSaleOrder.Columns[1].Name = "CatName";
            gvSaleOrder.Columns[2].Name = "SubCatName";
            gvSaleOrder.Columns[3].Name = "UnitName";
            gvSaleOrder.Columns[4].Name = "PackingName";
            gvSaleOrder.Columns[5].Name = "ClassName";
            gvSaleOrder.Columns[6].Name = "Quantity";
            gvSaleOrder.Columns[7].Name = "UnitRate";
            gvSaleOrder.Columns[8].Name = "Discount";
            gvSaleOrder.Columns[9].Name = "SaleRate";
            gvSaleOrder.Columns[10].Name = "TotalAmount";
            gvSaleOrder.Columns[11].Name = "AmountReceived";
            gvSaleOrder.Columns[12].Name = "RemainingAmount";
            //gvSaleOrder.Columns[0].Width = 124;
            //gvSaleOrder.Columns[1].Width = 124;
            //gvSaleOrder.Columns[2].Width = 124;
            //gvSaleOrder.Columns[3].Width = 124;
            //gvSaleOrder.Columns[6].Width = 124;
            //gvPurchaseOrder.Columns[9].Width = 128;

        }


        public DataTable GetPurchaseOrderCode()
        {
            SqlParameter[] pram =
            {
                _oDbHelper.OutParam("@RetCode",SqlDbType.VarChar,20)
            };
            return _oDbHelper.GetDataTable("uspPurchaseOrderCodeGet", pram);
        }
        public DataTable GetPurchaseInvoiceCode()
        {
            SqlParameter[] pram =
            {
                _oDbHelper.OutParam("@RetCode",SqlDbType.VarChar,20)
            };
            return _oDbHelper.GetDataTable("uspPurchaseInvoiveCodeGet", pram);
        }
        public DataTable GetSaleOrderCode()
        {
            SqlParameter[] pram =
            {
                _oDbHelper.OutParam("@RetCode",SqlDbType.VarChar,20)
            };
            return _oDbHelper.GetDataTable("uspSaleOrderCodeGet", pram);
        }
        public DataTable GetSaleInvoiceCode()
        {
            SqlParameter[] pram =
            {
                _oDbHelper.OutParam("@RetCode",SqlDbType.VarChar,20)
            };
            return _oDbHelper.GetDataTable("uspSalInvoiveCodeGet", pram);
        }
        //Data Poupulatuion methods END


        //Set Codes Methods START
        public void SetPurchaseOrderCode()
        {
            var dt = GetPurchaseOrderCode();
            tbPurchaseOrderCode.Text = dt.Rows[0]["PurchaseOrderCode"].ToString();
        }
        public void SetPurchaseInvoiceCode()
        {
            var dt = GetPurchaseInvoiceCode();
            tbPurchaseInvoiceCode.Text = dt.Rows[0]["PurchaseInvoiceCode"].ToString();
        }
        public void SetSaleOrderCode()
        {
            var dt = GetSaleOrderCode();
            tbSaleOrderCode.Text = dt.Rows[0]["SaleOrderCode"].ToString();
        }
        //public void SetSaleInvoiceCode()
        //{
        //    var dt = GetSaleInvoiceCode();
        //    tbSaleInvCode.Text = dt.Rows[0]["SaleInvoiceCode"].ToString();
        //}
        //Get Codes Methods END

        //Model Initializer
        private Standard IntilizerStandard() {
            var standard = new Standard
            {
                ClassId = cmbAddClass.Enabled ? (int)cmbAddClass.SelectedValue : 0,
                ClassName = tbAddClass.Text,
                IsActive = cbIsActive.Checked,
                CreatedBy = adminId,
                UpdatedBy=adminId,

            };
            return standard;
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
        private PurchaseOrder InitializerPurchaseOrder()
        {
            var purchaseOrder = new PurchaseOrder
            {
                PurchaseOrderCode = tbPurchaseOrderCode.Text
            };
            return purchaseOrder;
            
        }
        private SaleOrder InitializerSaleOrder()
        {
            var saleOrder = new SaleOrder
            {
                SaleOrderCode = tbSaleOrderCode.Text
            };
            return saleOrder;

        }
        private Vendor InitializerVendor()
        {
            var vendor = new Vendor
            {
                VendorName = tbPurOrderVendorName.Text,
                VendorContactNumber=Convert.ToInt32(tbPurOrContactNumber.Text),
                VendorAddress= richTbPurOrAddress.Text,
                CreatedBy = adminId,
                UpdatedBy = adminId
            };
            return vendor;
        }

        private Customer InitializerCustomer()
        {
            var customer = new Customer
            {
                CustomerName = tbSaleOrderCustomerName.Text,
                CustomerContactNumber = Convert.ToInt32(tbSaleOrderCustomerContactNumber.Text),
                CustomerAddress = richTbSaleOrder.Text,
                CreatedBy = adminId,
                UpdatedBy = adminId
            };
            return customer;
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
        public void SavePurchaseOrder(Vendor model,PurchaseOrder model1,DataTable dt)
        {

            SqlParameter[] param =
            {

                _oDbHelper.InParam(purchaseOrderTable, SqlDbType.Structured,0,dt),

                    _oDbHelper.InParam(VendorName, SqlDbType.NVarChar, 50, model.VendorName),

                    _oDbHelper.InParam(VendorContactNumber,SqlDbType.BigInt,15,model.VendorContactNumber),

                    _oDbHelper.InParam(VendorAddress,SqlDbType.NVarChar,50,model.VendorAddress),

                   _oDbHelper.InParam(PurchaseOrderCode,SqlDbType.NVarChar,50,model1.PurchaseOrderCode),

                    _oDbHelper.InParam(CreatedBy,SqlDbType.Int,4,model.CreatedBy),

                    _oDbHelper.InParam(UpdatedBy,SqlDbType.Int,4,model.UpdatedBy),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                };
            var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspPurchseOrderSave", RetVal, param);
        }
        public void SaveSaleOrder(Customer model, SaleOrder model1, DataTable dt)
        {

            SqlParameter[] param =
            {

                _oDbHelper.InParam(saleOrderTable, SqlDbType.Structured,0,dt),

                    _oDbHelper.InParam(CustomerName, SqlDbType.NVarChar, 50, model.CustomerName),

                    _oDbHelper.InParam(CustomerContactNumber,SqlDbType.BigInt,15,model.CustomerContactNumber),

                    _oDbHelper.InParam(CustomerAddress,SqlDbType.NVarChar,50,model.CustomerAddress),

                   _oDbHelper.InParam(SaleOrderCode,SqlDbType.NVarChar,50,model1.SaleOrderCode),

                    _oDbHelper.InParam(CreatedBy,SqlDbType.Int,4,model.CreatedBy),

                    _oDbHelper.InParam(UpdatedBy,SqlDbType.Int,4,model.UpdatedBy),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                };
            var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspSaleOrderSave", RetVal, param);
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

        public void SaveStandard(Standard model) {


            SqlParameter[] param =
            {
                _oDbHelper.InParam(ClassId, SqlDbType.Int, 4, model.ClassId),

                _oDbHelper.InParam(ClassName, SqlDbType.NVarChar, 50, model.ClassName),

                    _oDbHelper.InParam(IsActive,SqlDbType.Bit,1,model.IsActive),

                    _oDbHelper.InParam(CreatedBy,SqlDbType.Int,4,model.CreatedBy),

                    _oDbHelper.InParam(UpdatedBy,SqlDbType.Int,4,model.UpdatedBy),

                    _oDbHelper.OutParam(RetVal, SqlDbType.Int, 4)
                };
            var retVal = (int)_oDbHelper.ExecuteScalarOutPram("uspStandardSave", RetVal, param);
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
                ShowError(tbCategories, "Error");

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
                    //MessageBox.Show("Press New Before Entering New Category Record.");
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

        public Standard StandardGetById(int id)
        {
            SqlParameter[] pram =
            {
                _oDbHelper.InParam(ClassId,SqlDbType.Int,4,id)
            };
            var list = _oDbHelper.GenericSqlDataReader<Standard>("uspGetAllStandard", pram).FirstOrDefault();
            return list;
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
                ShowError(tbItem, "Error");

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
                   // MessageBox.Show("Press New Before Entering New Item Record.");
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
          private void btnAddClass_Click(object sender, EventArgs e)
        {
            pnlClass.Show();
            panel1.Hide();
            panel2.Hide();
            pnlUnit.Hide();
            pnlPurchaseOrder.Hide();
            pnlPacking.Hide();
            pnlPurchaseInvoice.Hide();
            pnlSalesOrder.Hide();
            pnlSaleInvoice.Hide();

        }
        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            pnlClass.Hide();
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
            pnlClass.Hide();
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
            pnlClass.Hide();
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
            pnlClass.Hide();
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
            pnlClass.Hide();
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
            pnlClass.Hide();
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

        public void DeleteStandard(int id)
        {
            SqlParameter[] param =
          {
                _oDbHelper.InParam(ClassId, SqlDbType.Int, 4, id)

            };

            _oDbHelper.ExecuteScalar("uspDeleteStandard", param);
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
                ShowError(tbUnit, "Error");

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
                    //MessageBox.Show("Press New Before Entering New Category Record.");
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
                ShowError(tbPacking,"Error");

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
                    //MessageBox.Show("Press New Before Entering New Packing Record.");
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

        //packing screen Buttons END


        //Purchase Order Screen Coding START
       
        private void tbAmountRePurOr_Leave(object sender, EventArgs e)
        {
            decimal purchaseRate = Convert.ToDecimal(tbTotalAmPurOr.Text);
            decimal amountpaid=Convert.ToDecimal(tbAmountRePurOr.Text);
            tbRemAmPurOr.Text= Convert.ToString(purchaseRate-amountpaid);
        }
        private void btnAddPurchaseOrderDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbRemAmPurOr.Text != "")
                {

               
                    gvPurchaseOrder.Rows.Add(0,cmbSelectCatPurchaseOrder.Text, cmbSelectSubCatPurchaseOrder.Text,  cmbPurOrderUnit.Text, cmbPurOrderPacking.Text, Convert.ToDecimal(tbQuantityPurOr.Text), Convert.ToDecimal(tbUnitRatePurOr.Text), Convert.ToDecimal(tbTotalAmPurOr.Text), Convert.ToDecimal(tbAmountRePurOr.Text), Convert.ToDecimal(tbRemAmPurOr.Text));
                    PurchaseFieldClear();
                }
                else
                {
                    MessageBox.Show("please enter values.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
                 
            }

        }

        private void btnSavePurOr_Click(object sender, EventArgs e)
        {
            try
            {
              
                   
                        _oDbHelper.OpenConnection();

                var dt = new DataTable();
                foreach (DataGridViewColumn column in gvPurchaseOrder.Columns)
                {
                   
                        // You could potentially name the column based on the DGV column name (beware of dupes)
                        // or assign a type based on the data type of the data bound to this DGV column.
                        dt.Columns.Add();
                    
                }

                object[] cellValues = new object[gvPurchaseOrder.Columns.Count];
                foreach (DataGridViewRow row in gvPurchaseOrder.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            cellValues[i] = row.Cells[i].Value;
                            if(i==9)
                            {
                                dt.Rows.Add(cellValues);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                   
                }

              
                var vendor = InitializerVendor();
                var purchaseOrder = InitializerPurchaseOrder();
                SavePurchaseOrder(vendor, purchaseOrder, dt);
                SetPurchaseOrderCode();
                _oDbHelper.CloseConnection();
                        cmbUnit.Enabled = true;
                        MessageBox.Show("Category Record is Inserted.");
                        PopulateUnits();
                 
            }

            catch (Exception ex)
            {
                
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnClearPurOr_Click(object sender, EventArgs e)
        {
            tbPurOrderVendorName.Text = "";
            tbPurOrContactNumber.Text = "";
            richTbPurOrAddress.Text = "";
            gvPurchaseOrder.Rows.Clear();
            gvPurchaseOrder.Refresh();
            PurchaseFieldClear();
        }
        private void tbUnitRatePurOr_Leave(object sender, EventArgs e)
        {
            decimal quantity = Convert.ToDecimal(tbQuantityPurOr.Text);
            decimal unitRate = Convert.ToDecimal(tbUnitRatePurOr.Text);
            tbTotalAmPurOr.Text = Convert.ToString(quantity * unitRate);
        }

        //Purchase Order Screen Coding END

        //Check is empty fields on first 4 screens Start
        private void tbCategories_TextChanged(object sender, EventArgs e)
        {

            IsEmptyTextBox(tbCategories,"Please Enter Category.");
        }

        private void tbItem_TextChanged(object sender, EventArgs e)
        {

            IsEmptyTextBox(tbItem, "Please Enter Item.");
        }

        private void tbUnit_TextChanged(object sender, EventArgs e)
        {
            IsEmptyTextBox(tbUnit, "Please Enter Unit.");
        }

        private void tbPacking_TextChanged(object sender, EventArgs e)
        {
            IsEmptyTextBox(tbPacking, "Please Enter Packing.");
        }


        public void IsEmptyTextBox( TextBox tb,string message)
        {

            if (string.IsNullOrEmpty(tb.Text))
            {
                ePCategory.Icon = Properties.Resources.qMark;
                ePCategory.SetError(tb,message);
            }
            else
            {
                ePCategory.Icon = Properties.Resources.cor;
                ePCategory.SetError(tb, "Ok");
            }
        }

        //Button Error Icon Show
        public void ShowError(TextBox tb1, string mess)
        {
            if (string.IsNullOrEmpty(tb1.Text))
            {
                ePCategory.Icon = Properties.Resources.err;
                ePCategory.SetError(tb1, mess);
            }
            else
            {
                ePCategory.Icon = Properties.Resources.cor;
                ePCategory.SetError(tb1, "Ok");
            }
        }

       

       
        //Purchase Order Fields Clear START
        public void PurchaseFieldClear()
        {
            tbQuantityPurOr.Text = "";
            tbUnitRatePurOr.Text = "";
            //tbDiscountPurOr.Text = "";
            tbTotalAmPurOr.Text = "";
            tbAmountRePurOr.Text = "";
            tbRemAmPurOr.Text = "";
        }

        private void btnDeletePurOr_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)gvPurchaseOrder.DataSource;
        }

        private void btnClassNew_Click(object sender, EventArgs e)
        {
            New(cmbAddClass,tbAddClass,cbIsActive);
        }

        private void btnCLassSave_Click(object sender, EventArgs e)
        {
            try
            {
                ShowError(tbAddClass, "Error");

                if (!cmbAddClass.Enabled)
                {
                    if (tbAddClass.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var Standard = IntilizerStandard();
                        SaveStandard(Standard);
                        _oDbHelper.CloseConnection();
                        cmbAddClass.Enabled = true;
                        MessageBox.Show("Class Record is Inserted.");
                        PopulateStandard();
                    }
                    else
                    {
                        MessageBox.Show("Please Insert Record.");
                    }
                }
                else
                {
                    //MessageBox.Show("Press New Before Entering New Packing Record.");
                }
            }

            catch (Exception ex)
            {
                cmbAddClass.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnClassUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAddClass.Enabled)
                {
                    if (cmbAddClass.Text != "")
                    {
                        _oDbHelper.OpenConnection();
                        var Standard = IntilizerStandard();
                        SaveStandard(Standard);
                        _oDbHelper.CloseConnection();
                        cmbAddClass.Enabled = true;
                        MessageBox.Show("Class Record is Updated.");
                        PopulateStandard();
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
                cmbAddClass.Enabled = true;
                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        private void btnClassClear_Click(object sender, EventArgs e)
        {
            Clear(tbAddClass,cbIsActive, cmbAddClass);
        }

        private void btnClassDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAddClass.Text != "")
                {
                    _oDbHelper.OpenConnection();
                    int id = (int)cmbAddClass.SelectedValue;
                    DeleteStandard(id);
                    _oDbHelper.CloseConnection();
                    MessageBox.Show("Class Record is Deleted Successfully.");
                    PopulateStandard();
                }
                else
                {
                    MessageBox.Show("Please Select Class to Deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete." + ex);
                _oDbHelper.CloseConnection();
            }
        }
        // Crystal Report Button Start
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Crytal_Report cry = new Crytal_Report();
            cry.Show();
        }
        private void btnPrintSale_Click(object sender, EventArgs e)
        {
            SaleOrderReport crp = new SaleOrderReport();
            crp.Show();

        }
        // Crystal Report Button End
        private void cmbAddClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (cmbAddClass.SelectedValue != null)
                {
                    _oDbHelper.OpenConnection();
                    Standard Standard;
                    var id = (int)cmbAddClass.SelectedValue;
                    Standard = StandardGetById(id);
                    tbAddClass.Text = Standard.ClassName;
                    cbIsActive.Checked = Standard.IsActive;
                    _oDbHelper.CloseConnection();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbSelectSubCatSaleOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var subCat = cmbSelectSubCatSaleOrder.Text;
                SqlParameter[] pram =
          {
                _oDbHelper.InParam("SubCatName",SqlDbType.NVarChar,50,subCat)
            };
                PopulatePurchaseRate(pram);
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }

        //Sale Order Screen Coding START
        private void tbSaleOrderUnitRate_Leave(object sender, EventArgs e)
        {
            decimal quantity=Convert.ToDecimal(tbSaleOrderQuantity.Text);
            decimal purchaseRate=Convert.ToDecimal(cmbPurchaseRate.Text);
            decimal amount = quantity * purchaseRate;
            tbSaleOrderTotalAmount.Text =Convert.ToString(amount);
            decimal saleRate=(Convert.ToDecimal(tbSaleOrderUnitRate.Text)/100)*amount;
            tbSaleOrderSaleRate.Text = Convert.ToString(saleRate+amount);

        }

        private void tbSaleOrderDiscount_Leave(object sender, EventArgs e)
        {
            decimal discount=Convert.ToDecimal(tbSaleOrderDiscount.Text);
            decimal withDiscount = (discount / 100) * Convert.ToDecimal(tbSaleOrderSaleRate.Text);
            tbSaleOrderSaleRate.Text = Convert.ToString(Convert.ToDecimal(tbSaleOrderSaleRate.Text)-withDiscount);
        }

        private void tbSaleOrderAmountRe_Leave(object sender, EventArgs e)
        {
            decimal amountReceived = Convert.ToDecimal(tbSaleOrderAmountRe.Text);
            decimal saleRate = Convert.ToDecimal(tbSaleOrderSaleRate.Text);
            decimal remainingAmount = saleRate - amountReceived;
            tbSaleOrderRemAmount.Text = Convert.ToString(remainingAmount);
        }

        private void btnSaleOrderAdd_Click(object sender, EventArgs e)
        {
            try
            {
               


          gvSaleOrder.Rows.Add(0,
                                cmbSelectCatSaleOrder.Text,
                                cmbSelectSubCatSaleOrder.Text,
                                cmbSaleOrderUnit.Text,
                                cmbSaleOrderPacking.Text,
                                cmbSelectClass.Text, 
                                Convert.ToDecimal(tbSaleOrderQuantity.Text),
                                Convert.ToDecimal(tbSaleOrderUnitRate.Text),
                                Convert.ToDecimal(tbSaleOrderDiscount.Text), 
                                Convert.ToDecimal(tbSaleOrderSaleRate.Text),
                                Convert.ToDecimal(tbSaleOrderTotalAmount.Text),
                                Convert.ToDecimal(tbSaleOrderAmountRe.Text),
                                Convert.ToDecimal(tbSaleOrderRemAmount.Text)
                                );
                   // PurchaseFieldClear();
            
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }

        private void btnSaveSaleOrder_Click(object sender, EventArgs e)
        {
            try
            {


                _oDbHelper.OpenConnection();

                var dt = new DataTable();
                foreach (DataGridViewColumn column in gvSaleOrder.Columns)
                {

                    dt.Columns.Add();

                }

                object[] cellValues = new object[gvSaleOrder.Columns.Count];
                foreach (DataGridViewRow row in gvSaleOrder.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            cellValues[i] = row.Cells[i].Value;
                            if (i == 12)
                            {
                                dt.Rows.Add(cellValues);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                }


                var customer = InitializerCustomer();
                var saleOrder = InitializerSaleOrder();
                SaveSaleOrder(customer, saleOrder, dt);
                SetSaleOrderCode();
                _oDbHelper.CloseConnection();
            
                MessageBox.Show("Sale Order is Inserted.");
       

            }

            catch (Exception ex)
            {

                MessageBox.Show("Insertion Failed." + ex);
                _oDbHelper.CloseConnection();
            }
        }

        



        //Sale Order Screen Coding START



    }



}

