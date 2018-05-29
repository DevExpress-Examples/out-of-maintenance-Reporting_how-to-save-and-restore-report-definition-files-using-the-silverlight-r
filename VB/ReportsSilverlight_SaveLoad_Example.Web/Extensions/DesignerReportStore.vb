Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web
Imports DevExpress.XtraReports.Service.Extensions

Namespace ReportsSilverlight_SaveLoad_Example.Web.Extensions
	<Export(GetType(IDesignerReportStore))> _
	Public Class DesignerReportStore
		Implements IDesignerReportStore
        Private Function GetFilePath(ByVal reportName As String) As String
            reportName = Regex.Replace(reportName, "[., ]", "_")
            Return HttpContext.Current.Server.MapPath(String.Format("~/Reports/{0}.repx", reportName))
        End Function

        Public Function LoadLayout(ByVal reportName As String) As Byte() Implements IDesignerReportStore.LoadLayout
            Dim fileName = GetFilePath(reportName)
            If File.Exists(fileName) Then
                Return File.ReadAllBytes(fileName)
            End If
            Return Nothing
        End Function

        Public Sub SaveLayout(ByVal reportName As String, ByVal layoutData() As Byte) Implements IDesignerReportStore.SaveLayout
            File.WriteAllBytes(GetFilePath(reportName), layoutData)
        End Sub
	End Class
End Namespace