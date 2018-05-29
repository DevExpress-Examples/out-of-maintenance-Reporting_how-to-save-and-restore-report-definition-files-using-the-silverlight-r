using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using DevExpress.Data.Utils.ServiceModel;
using DevExpress.XtraReports.UI;
using ReportLibrary;

namespace ReportsSilverlight_SaveLoad_Example.Web {
    [SilverlightFaultBehavior]
    public class ReportService : DevExpress.XtraReports.Service.ReportService {
        static string GetFilePath(string reportName) {
            reportName = Regex.Replace(reportName, "[., ]", "_");
            return HttpContext.Current.Server.MapPath(string.Format("Reports/{0}.repx", reportName));
        }

        protected override void FillDataSources(XtraReport report, string reportName, bool isDesignActive) {
            if (report is ProductsReport)
                report.DataSource = new Northwind().Products;
            else if (report is CategoriesReport)
                report.DataSource = new Northwind().Categories;
        }

        protected override void SaveReportLayout(string reportName, byte[] layoutData) {
            File.WriteAllBytes(GetFilePath(reportName), layoutData);
        }
        protected override byte[] LoadReportLayout(string reportName) {
            var fileName = GetFilePath(reportName);
            if (File.Exists(fileName))
                return File.ReadAllBytes(fileName);
            return base.LoadReportLayout(reportName);
        }
    }
}
