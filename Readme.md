<!-- default file list -->
*Files to look at*:

* [ReportService.svc.cs](./CS/ReportsSilverlight_SaveLoad_Example.Web/ReportService.svc.cs) (VB: [ReportService.svc.vb](./VB/ReportsSilverlight_SaveLoad_Example.Web/ReportService.svc.vb))
* **[MainPage.xaml](./CS/ReportsSilverlight_SaveLoad_Example/MainPage.xaml) (VB: [MainPage.xaml](./VB/ReportsSilverlight_SaveLoad_Example/MainPage.xaml))**
* [MainPage.xaml.cs](./CS/ReportsSilverlight_SaveLoad_Example/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/ReportsSilverlight_SaveLoad_Example/MainPage.xaml.vb))
<!-- default file list end -->
# How to save and restore report definition files using the Silverlight report designer


<p>This example illustrates how you can load a report into an in-browser designer and, after making any changes to the report, save these changes.</p><p>After clicking the Save Changes button in the designer’s Ribbon-style menu, the <strong>Save</strong><strong>Layout </strong>method is called on the server, which you can override to allow saving the report layout to any source (a database, file, or ASP.NET session).</p><p>In addition, it is possible to override the <strong>Load</strong><strong>Layout </strong>method on the server to allow restoring a layout (in an XML format) to the design session.</p><p>See also:<br />
- <a href="https://www.devexpress.com/Support/Center/p/E3690">How to use the Silverlight report designer</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E3769">How to customize the Silverlight Report Designer</a>.</p>

<br/>


