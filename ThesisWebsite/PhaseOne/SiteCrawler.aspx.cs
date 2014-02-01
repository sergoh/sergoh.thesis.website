using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class Operations : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnWebFocus_Click(object sender, EventArgs e)
    {
        List<String> stringList = new List<string>();
        WcfServiceLibrary service = new WcfServiceLibrary();
        if (txtURI.Text != "")
        {
            //string[] topics = txtTopic1.Text.Split(',');
            string[] results = service.ChilkatCrawler(txtURI.Text);
            lblWeb.Text = "";
            foreach (string arrayListItem in results)
            {
                string[] scanUrlResults = service.ScanRepository(arrayListItem);
                //service.scanRepository(arrayListItem);
                foreach (string listItem in scanUrlResults)
                {
                    stringList.Add(listItem);
                }
            }
            lvLinks.DataSource = stringList;
            lvLinks.DataBind();

            //ScanResults.Text = results;
        }
        else
        {
            lblWeb.Text = "Pleas enter search topics";
        }
    }

}