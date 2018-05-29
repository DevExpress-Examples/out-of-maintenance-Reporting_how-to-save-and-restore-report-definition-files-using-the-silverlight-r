Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports DevExpress.XtraReports.Service.Extensions
Imports DevExpress.XtraReports.UI
Imports ReportLibrary

Namespace ReportsSilverlight_SaveLoad_Example.Web.Extensions
	<Export(GetType(IDataSourceService))> _
	Public Class DataSourceService
		Implements IDataSourceService
        Public Sub FillDataSources(ByVal report As XtraReport, ByVal reportName As String, ByVal isDesignActive As Boolean) Implements IDataSourceService.FillDataSources
            If TypeOf report Is ProductsReport Then
                report.DataSource = New Northwind().Products
            ElseIf TypeOf report Is CategoriesReport Then
                report.DataSource = New Northwind().Categories
            End If
        End Sub

        Public Sub RegisterDataSources(ByVal report As DevExpress.XtraReports.UI.XtraReport, ByVal reportName As String) Implements IDataSourceService.RegisterDataSources
        End Sub

	End Class
End Namespace