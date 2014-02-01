using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class WebserviceDetail : Page
{
    WcfServiceLibrary service = new WcfServiceLibrary();
    private string strWsdlURL = "";
    public string WsdlURL
    {
        get
        {
            return strWsdlURL;
        }
        set
        {
            strWsdlURL = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = String.Empty;

        bool bContinue = true;
        if (!IsPostBack)
        {

            if (Request.QueryString["url"] != String.Empty)
            {
                WsdlURL = Request.QueryString["url"];
            }
            else
                bContinue = false;

            if (bContinue)
            {
                if (service.GetOperationsTable(WsdlURL).Rows.Count > 0)
                {
                    dvOperationList.DataSource = service.GetOperationsTable(WsdlURL);
                    dvOperationList.DataBind();
                }
                else
                {
                    Session["Exception"] = "There was an error getting the operations from the wsdl flie";
                    Response.Redirect("~/Errorpage.aspx", true);

                }




                //Track when Commission Detail was changed
                if (Session["History"] != null)
                    Session["History"] += ";";
                Session["History"] += "Wsdl detail was requested for the url " + strWsdlURL;
            }
        }

    }

    protected void dgItemCommand(Object sender, DataGridCommandEventArgs e)
    {

    }


    protected void dgOperationList_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hscanLink = (HyperLink)e.Row.FindControl("scanLink");
            hscanLink.NavigateUrl = "OperationDetail.aspx?url=" + Request.QueryString["url"] + "&operation=" + e.Row.Cells[1].Text + "&protocol=" + e.Row.Cells[2].Text;
        }
    }

    protected void parametersSet_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}