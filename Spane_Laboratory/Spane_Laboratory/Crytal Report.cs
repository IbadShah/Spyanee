using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
namespace Spane_Laboratory
{
    public partial class Crytal_Report : Form
    {
        DbHelper dbHelper = new DbHelper();
        ReportDocument rd = new ReportDocument();
        public Crytal_Report()
        {
            InitializeComponent();
        }

        private void Crytal_Report_Load(object sender, EventArgs e)
        {
            try
            {
          //    MessageBox.Show(Application.StartupPath+ @"\CReport.rpt");
                dbHelper.OpenConnection();
                rd.Load(@"C:\Users\Jawad Khan\Documents\GitHub\Spyanee\Spane_Laboratory\Spane_Laboratory\CReport.rpt");
                SqlDataAdapter sda = new SqlDataAdapter("uspGePurchaseOrder",Connection.ConnectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = null;
                DataSet st = new DataSet();
                sda.Fill(st, "PurchaseOrderData");
                rd.SetDataSource(st);
                crystalReportViewer1.ReportSource = rd;
                dbHelper.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbHelper.OpenConnection();
                rd.Load(@"C:\Users\Jawad Khan\Documents\GitHub\Spyanee\Spane_Laboratory\Spane_Laboratory\CReport.rpt");
                SqlDataAdapter sda = new SqlDataAdapter("uspGePurchaseOrder", Connection.ConnectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@code",SqlDbType.NVarChar,50).Value=textBox1.Text;
                DataSet st = new DataSet();
                sda.Fill(st, "PurchaseOrderData");
                rd.SetDataSource(st);
                crystalReportViewer1.ReportSource = rd;
                dbHelper.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
