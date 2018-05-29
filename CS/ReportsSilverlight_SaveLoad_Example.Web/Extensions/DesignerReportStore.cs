using System.ComponentModel.Composition;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using DevExpress.XtraReports.Service.Extensions;

namespace ReportsSilverlight_SaveLoad_Example.Web.Extensions {
    [Export(typeof(IDesignerReportStore))]
    public class DesignerReportStore : IDesignerReportStore {
        string GetFilePath(string reportName) {
            reportName = Regex.Replace(reportName, "[., ]", "_");
            return HttpContext.Current.Server.MapPath(string.Format("~/Reports/{0}.repx", reportName));
        }

        public byte[] LoadLayout(string reportName) {
            var fileName = GetFilePath(reportName);
            if(File.Exists(fileName))
                return File.ReadAllBytes(fileName);
            return null;
        }

        public void SaveLayout(string reportName, byte[] layoutData) {        
            File.WriteAllBytes(GetFilePath(reportName), layoutData);
        }
    }
}