using System.ComponentModel.Composition;
using DevExpress.XtraReports.Service.Extensions;
using DevExpress.XtraReports.UI;
using ReportLibrary;

namespace ReportsSilverlight_SaveLoad_Example.Web.Extensions {
    [Export(typeof(IDataSourceService))]
    public class DataSourceService : IDataSourceService {
        public void FillDataSources(XtraReport report, string reportName, bool isDesignActive) {
            if(report is ProductsReport)
                report.DataSource = new Northwind().Products;
            else if(report is CategoriesReport)
                report.DataSource = new Northwind().Categories;
        }

        public void RegisterDataSources(DevExpress.XtraReports.UI.XtraReport report, string reportName) { }
    }
}