Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows.Input
Imports DevExpress.Xpf.Core.Commands
Imports DevExpress.Xpf.ReportDesigner

Namespace ReportsSilverlight_SaveLoad_Example
	Public Class MainPageViewModel
		Implements INotifyPropertyChanged
        Private Shared ReadOnly reportNames_Renamed() As String = _
            {"ReportLibrary.ProductsReport, ReportLibrary", "ReportLibrary.CategoriesReport, ReportLibrary"}
		Private ReadOnly reportDesignerViewModel As ReportDesignerViewModel
		Private currentReportName_Renamed As String = reportNames_Renamed.First()
		Private startDesign_Renamed As ICommand

		Public ReadOnly Property ReportNames() As String()
			Get
				Return reportNames_Renamed
			End Get
		End Property

		Public Property CurrentReportName() As String
			Get
				Return currentReportName_Renamed
			End Get
			Set(ByVal value As String)
				currentReportName_Renamed = value
				RaisePropertyChanged("CurrentReportName")
			End Set
		End Property

		Public ReadOnly Property StartDesign() As ICommand
			Get
				If startDesign_Renamed Is Nothing Then
                    startDesign_Renamed = New DelegateCommand(Of Object)(Sub(ignore) DoStartDesign())
				End If
				Return startDesign_Renamed
			End Get
		End Property

		Public Sub New(ByVal reportDesignerViewModel As ReportDesignerViewModel)
			Me.reportDesignerViewModel = reportDesignerViewModel
		End Sub

		Private Sub DoStartDesign()
			If (Not String.IsNullOrEmpty(reportDesignerViewModel.ReportName)) Then
				reportDesignerViewModel.StartDesign()
			End If
		End Sub

		#Region "INotifyPropertyChanged"
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Private Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
		#End Region
	End Class
End Namespace
