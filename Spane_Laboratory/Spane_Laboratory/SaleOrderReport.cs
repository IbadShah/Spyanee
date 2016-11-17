using CrystalDecisions.CrystalReports.Engine;
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

using CrystalDecisions.Shared;

namespace Spane_Laboratory
{
    public partial class SaleOrderReport : Form
    {
        DbHelper dbHelper = new DbHelper();
        ReportDocument rd = new ReportDocument();
        public SaleOrderReport()
        {
            InitializeComponent();
        }

        private void SaleOrderReport_Load(object sender, EventArgs e)
        {

            try
            {
                
                //    MessageBox.Show(Application.StartupPath+ @"\CReport.rpt");
                dbHelper.OpenConnection();
                rd.Load(Application.StartupPath + @"\SaleOrderCrpt.rpt");
                SqlDataAdapter sda = new SqlDataAdapter("uspGetSaleOrder", Connection.ConnectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = null;
                DataSet st = new DataSet();
                sda.Fill(st, "DataSetSaleOrder");
                rd.SetDataSource(st);
                SaleOrderCrptViewr.ReportSource = rd;
                dbHelper.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void btnSaleSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dbHelper.OpenConnection();
                rd.Load(Application.StartupPath + @"\SaleOrderCrpt.rpt");
                SqlDataAdapter sda = new SqlDataAdapter("uspGetSaleOrder", Connection.ConnectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = tbSaleSearch.Text;
                DataSet st = new DataSet();
                sda.Fill(st, "DataSetSaleOrder");
                rd.SetDataSource(st);
                SaleOrderCrptViewr.ReportSource = rd;
                dbHelper.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
