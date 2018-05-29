using System.Windows.Controls;

namespace ReportsSilverlight_SaveLoad_Example {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            DataContext = new MainPageViewModel(reportDesigner.Model);
        }
    }
}
