using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class Discovery : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnWebFocus_Click(object sender, EventArgs e)
    {
        WcfServiceLibrary service = new WcfServiceLibrary();
        List<string> myCollection = new List<string>();

        myCollection.Add("ext: asmx");
        string[] topics = myCollection.ToArray();
        string[] results = service.WsdlDiscovery(topics);
        lblWeb.Text = "";
        foreach (string webUrls in results)
        {
            lblWeb.Text += webUrls + " ";
            lblWeb.Text += "               ";
        }
    }

    protected void btnGoogleFocus_Click(object sender, EventArgs e)
    {

    }
   
    protected void btnYahoo_Click(object sender, EventArgs e)
    {

    }

}