using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class RepositoryTesting : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        scanresults.Visible = false;

    }

    protected void btnScan_Click(object sender, EventArgs e)
    {
        WcfServiceLibrary service = new WcfServiceLibrary();
        WebserviceBaseList wsUrlBaseList = new WebserviceBaseList();
        string txtTopic1 = ".svc?wsdl,.asmx?wsdl";//.php?wsdl,
        string[] topics = txtTopic1.Split(',');
        DataTable scanResults = new DataTable();
        WebserviceBaseList wsbList = service.ScanBing(topics);

        string[] results = service.ChilkatCrawler("http://www.webservicex.net");

        foreach (string arrayListItem in results)
        {
            wsUrlBaseList = service.ScanRepositoryWs(arrayListItem);

            wsbList = service.MergeWebserviceBaseList(wsbList, wsUrlBaseList);
        }
        string[] results2 = service.ChilkatCrawler("http://www.remotemethods.com");

        foreach (string arrayListItem in results2)
        {
            wsUrlBaseList = service.ScanRepositoryWs(arrayListItem);

            wsbList = service.MergeWebserviceBaseList(wsbList, wsUrlBaseList);

        }
        string[] results3 = service.ChilkatCrawler("http://venus.eas.asu.edu/WSRepository/repository.html");

        foreach (string value in results3)
        {
            if (value.Contains(".asmx") || value.Contains(".svc") || value.Contains(".php"))
            {
                if (value.Trim().EndsWith(".asmx?WSDL") || value.Trim().EndsWith(".svc?WSDL") || value.Trim().EndsWith(".php?WSDL"))
                {
                    WebserviceBase wsBase = new WebserviceBase();
                    wsBase.Title = "Repository";
                    wsBase.Url = value;
                    wsBase.Documentation = service.GetDocumentation(value);
                    wsbList = service.AddSingleWebserviceBase(wsbList, wsBase);

                }
                if (value.Trim().EndsWith(".asmx") || value.Trim().EndsWith(".svc") || value.Trim().EndsWith(".php"))
                {
                    WebserviceBase wsBase = new WebserviceBase();
                    wsBase.Title = "Repository";
                    wsBase.Url = value + "?WSDL";
                    wsBase.Documentation = service.GetDocumentation(value + "?WSDL");
                    wsbList = service.AddSingleWebserviceBase(wsbList, wsBase);

                }

            }
        }

        gvScanList.DataSource = wsbList.BaseList;
        gvScanList.DataBind();

        scanresults.Visible = true;


    }
    protected void gvScanList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hscanLink = (HyperLink)e.Row.FindControl("scanLink");
            hscanLink.NavigateUrl = "WebserviceDetail.aspx?url=" + e.Row.Cells[1].Text;
        }

    }
    protected void scanLink_Click(object sender, EventArgs e)
    {
        WcfServiceLibrary service = new WcfServiceLibrary();
        string txtTopic1 = ".php?wsdl,.svc?wsdl,.asmx?wsdl";
        string[] topics = txtTopic1.Split(',');
        DataTable scanResults = service.ScanWeb(topics);

        gvScanList.DataSource = scanResults;
        gvScanList.DataBind();

        scanresults.Visible = true;


    }
}