using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DevExpress.Xpf.Core.Commands;
using DevExpress.Xpf.ReportDesigner;

namespace ReportsSilverlight_SaveLoad_Example {
    public class MainPageViewModel : INotifyPropertyChanged {
        static readonly string[] reportNames = {
            "ReportLibrary.ProductsReport, ReportLibrary",
            "ReportLibrary.CategoriesReport, ReportLibrary"
        };
        readonly ReportDesignerViewModel reportDesignerViewModel;
        string currentReportName = reportNames.First();
        ICommand startDesign;

        public string[] ReportNames {
            get { return reportNames; }
        }

        public string CurrentReportName {
            get { return currentReportName; }
            set {
                currentReportName = value;
                RaisePropertyChanged("CurrentReportName");
            }
        }

        public ICommand StartDesign {
            get {
                if(startDesign == null)
                    startDesign = new DelegateCommand<object>(_ => DoStartDesign());
                return startDesign;
            }
        }

        public MainPageViewModel(ReportDesignerViewModel reportDesignerViewModel) {
            this.reportDesignerViewModel = reportDesignerViewModel;
        }

        void DoStartDesign() {
            if(!string.IsNullOrEmpty(reportDesignerViewModel.ReportName))
                reportDesignerViewModel.StartDesign();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propertyName) {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
