using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class Address : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ScanFocus_Click(object sender, EventArgs e)
    {
        List<String> stringList = new List<string>();
        WcfServiceLibrary service = new WcfServiceLibrary();
        string urlResult = service.GetUrlString(websiteUrl.Text);
        
        if (websiteUrl.Text == "")
            lblError.Text = "please enter url";
        else
        {
            string url = websiteUrl.Text;

            string[] scanUrlResults = service.WsdlAddress(url);
            foreach (string arrayListItem in scanUrlResults)
            {
                stringList.Add(arrayListItem);
            }
            lvLinks.DataSource = stringList;
            lvLinks.DataBind();
            lblResults.Visible = true;
            ScanResults.Text = urlResult;
        }
    }
}