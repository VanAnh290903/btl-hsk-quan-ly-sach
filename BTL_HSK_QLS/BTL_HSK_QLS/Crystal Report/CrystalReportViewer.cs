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
using CrystalDecisions.Shared;
using System.IO;
namespace BTL_HSK_QLS.Crystal_Report
{
    public partial class CrystalReportViewer : Form
    {
        public CrystalReportViewer()
        {
            InitializeComponent();
        }

        private void CrystalReportViewer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            
        }
        public void loadHoaDonChiTiet( string data)
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            //string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;

            //string reportPath = Path.Combine(projectDirectory, $"Crystal Report\\{crystalReportName}");
            ReportDocument report = new ReportDocument();
            report.Load(@"D:\VANH\HSK\BTL_HSK_QLS\BTL_HSK_QLS\Crystal Report\HoaDonCrystal.rpt");

            // Lấy tham số theo tên
            ParameterFieldDefinitions parameterFields = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameterField = parameterFields["@mahd"];

            // Khởi tạo giá trị cho tham số
            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = data; // Thay giá trị này bằng giá trị muốn truyền vào

            // Gán giá trị cho tham số
            ParameterValues currentParameterValues = parameterField.CurrentValues;
            currentParameterValues.Clear();
            currentParameterValues.Add(parameterValue);
            parameterField.ApplyCurrentValues(currentParameterValues);


            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
        public void loadCrystalReportNhanVien()
        {
            ReportDocument report = new ReportDocument();
            report.Load(@"D:\VANH\HSK\BTL_HSK_QLS\BTL_HSK_QLS\Crystal Report\NhanVienCrystal.rpt");
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}