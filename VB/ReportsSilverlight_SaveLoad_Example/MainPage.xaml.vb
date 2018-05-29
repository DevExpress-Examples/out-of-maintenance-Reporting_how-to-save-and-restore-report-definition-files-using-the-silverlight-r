Imports Microsoft.VisualBasic
Imports System.Windows.Controls

Namespace ReportsSilverlight_SaveLoad_Example
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			DataContext = New MainPageViewModel(reportDesigner.Model)
		End Sub
	End Class
End Namespace
