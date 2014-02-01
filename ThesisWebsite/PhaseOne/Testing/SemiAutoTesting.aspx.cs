using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class SemiAutoTesting : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ScanFocus_Click(object sender, EventArgs e)
    {
        WcfServiceLibrary service = new WcfServiceLibrary();

        List<String> stringList = new List<string>();
        string testValues = "";

        if (txtWSDL.Text != "")
        {
            string[] OperationList = service.GetOperations(txtWSDL.Text);


            //string[] scanUrlResults = service.WsdlAddress(url);
            ScanResults.Text = "The following are the operations in " + txtWSDL.Text + "\n \n";
            ScanResults.Text += "Scanning Wsdl..... \n \n";
            foreach (string arrayListItem in OperationList)
            {
                ScanResults.Text += arrayListItem + "\n";
                //stringList.Add(arrayListItem);
            }

            foreach (string arrayListItem in OperationList)
            {
                ScanResults.Text += "\nScanning " + arrayListItem + "'s Parameters..... \n";
                string[] parameterList = service.GetOperationSoapParameters(txtWSDL.Text, arrayListItem);
                foreach (string parameterListItem in parameterList)
                {
                    ScanResults.Text += parameterListItem + "\n";
                    ScanResults.Text += "  Generating value for " + parameterListItem + "... \n";
                    string value = service.WsValues(parameterListItem);
                    ScanResults.Text += "    " + parameterListItem + ":" + value + "\n";
                    testValues += value + " ";
                    //stringList.Add(arrayListItem);
                }

                //INVOKE NOW

                //Create testValues parameters
                if (testValues != "")
                {
                    testValues = testValues.Trim();
                    string[] testParameters = testValues.Split(' ');
                    ScanResults.Text += "Invoking method \n";
                    ScanResults.Text += "result:" + service.WsReflectionTesting(txtWSDL.Text, arrayListItem, "Soap12", testParameters) + "\n";
                    testValues = "";
                }
                else
                {
                    ScanResults.Text += "Error testing " + arrayListItem + "\n";

                }
            }


            lvLinks.DataSource = stringList;
            lvLinks.DataBind();

            //ScanResults.Text = urlResult;
        }
        else
            lblError.Text = "please enter url";

    }
}