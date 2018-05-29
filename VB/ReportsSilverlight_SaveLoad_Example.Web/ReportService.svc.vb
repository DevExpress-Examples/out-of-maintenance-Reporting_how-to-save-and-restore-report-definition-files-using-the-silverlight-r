Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web
Imports DevExpress.Data.Utils.ServiceModel
Imports DevExpress.XtraReports.UI
Imports ReportLibrary

Namespace ReportsSilverlight_SaveLoad_Example.Web
	<SilverlightFaultBehavior> _
	Public Class ReportService
		Inherits DevExpress.XtraReports.Service.ReportService
		Private Shared Function GetFilePath(ByVal reportName As String) As String
			reportName = Regex.Replace(reportName, "[., ]", "_")
			Return HttpContext.Current.Server.MapPath(String.Format("Reports/{0}.repx", reportName))
		End Function

		Protected Overrides Sub FillDataSources(ByVal report As XtraReport, ByVal reportName As String, ByVal isDesignActive As Boolean)
			If TypeOf report Is ProductsReport Then
				report.DataSource = New Northwind().Products
			ElseIf TypeOf report Is CategoriesReport Then
				report.DataSource = New Northwind().Categories
			End If
		End Sub

		Protected Overrides Sub SaveReportLayout(ByVal reportName As String, ByVal layoutData() As Byte)
			File.WriteAllBytes(GetFilePath(reportName), layoutData)
		End Sub
		Protected Overrides Function LoadReportLayout(ByVal reportName As String) As Byte()
			Dim fileName = GetFilePath(reportName)
			If File.Exists(fileName) Then
				Return File.ReadAllBytes(fileName)
			End If
			Return MyBase.LoadReportLayout(reportName)
		End Function
	End Class
End Namespace
