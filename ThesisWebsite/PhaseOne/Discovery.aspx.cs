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
        StringBuilder sb = new StringBuilder();

        // used on each read operation
        byte[] buf = new byte[8192];
        string GS = "http://google.com/search?q=";
        // prepare the web page we will be asking for
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GS);

        // execute the request
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        // we will read data via the response stream
        Stream resStream = response.GetResponseStream();
        string tempString = null;
        int count = 0;
        do
        {
            // fill the buffer with data
            count = resStream.Read(buf, 0, buf.Length);
            // make sure we read some data
            if (count != 0)
            {
                // translate from bytes to ASCII text
                tempString = Encoding.ASCII.GetString(buf, 0, count);

                // continue building the string
                sb.Append(tempString);
            }
        }
        while (count > 0);
    }
   
    protected void btnYahoo_Click(object sender, EventArgs e)
    {
        Uri address = new Uri("http://api.search.yahoo.com/ContentAnalysisService/V1/termExtraction");  
  
        // Create the web request  
        HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;  
  
        // Set type to POST  
        request.Method = "POST";  
        request.ContentType = "application/x-www-form-urlencoded";  
  
        // Create the data we want to send  
        string appId = "YahooDemo";  
        string context = "Italian sculptors and painters of the renaissance"  
                            + "favored the Virgin Mary for inspiration";  
        string query = "madonna";  
  
        StringBuilder data = new StringBuilder();  
        data.Append("appid=" + HttpUtility.UrlEncode(appId));  
        data.Append("&context=" + HttpUtility.UrlEncode(context));  
        data.Append("&query=" + HttpUtility.UrlEncode(query));  
  
        // Create a byte array of the data we want to send  
        byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());  
  
        // Set the content length in the request headers  
        request.ContentLength = byteData.Length;  
  
        // Write data  
        using (Stream postStream = request.GetRequestStream())  
        {  
            postStream.Write(byteData, 0, byteData.Length);  
        }  
  
        // Get response  
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)  
        {  
            // Get the response stream  
            StreamReader reader = new StreamReader(response.GetResponseStream());  
  
            // Console application output  
            lblYahoo.Text += reader.ReadToEnd();
        }  
    }
    //http://developer.yahoo.com/dotnet/howto-rest_cs.html

}