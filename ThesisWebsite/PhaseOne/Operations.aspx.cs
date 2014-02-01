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

    protected void btnXPath_Click(object sender, EventArgs e)
    {
        List<String> stringList = new List<string>();
        if ((txtURL2.Text != ""))
        {
            WcfServiceLibrary service = new WcfServiceLibrary();
            //string[] scanUrlResults = service.WsOperations2(txtURL2.Text);
            string[] scanUrlResults = service.WsOperations(txtURL2.Text);
            foreach (string arrayListItem in scanUrlResults)
            {
                stringList.Add(arrayListItem);
            }

            lvOperations.DataSource = stringList;
            lvOperations.DataBind();
        }
        else
        {
            lblValue.Text = "Please enter URL";
        }
    }

}