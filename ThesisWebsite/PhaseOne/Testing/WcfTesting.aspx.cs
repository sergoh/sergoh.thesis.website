using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class WcfTesting : Page
{
    WcfServiceLibrary service = new WcfServiceLibrary();
    static int methodIndex = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        parametersSet.Visible = false;
        lbMethods.Visible = false;

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        object result;
        result = service.GetOperations(txtWSDL.Text);
        lbMethods.SelectionMode = ListSelectionMode.Single;
        lbMethods.Visible = true;
        btnMethods.Visible = true;
        lbMethods.DataSource = result;
        lbMethods.DataBind();

    }
    protected void btnOperations_Click(object sender, EventArgs e)
    {
        btnInvoke.Visible = true;
        parametersSet.Visible = true;
        btnGo_Click(sender, e);
    }
    protected void lbMethods_SelectedIndexChanged(object sender, EventArgs e)
    {
        parametersSet.DataSource = service.GetOperationParameters(txtWSDL.Text, lbMethods.SelectedItem.Text);
        parametersSet.DataBind();
        methodIndex = lbMethods.SelectedIndex;

    }

    protected void parametersSet_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        foreach (Control i in parametersSet.Controls)
        {
            Label label = e.Item.FindControl("label") as Label;
            if (label != null)
            {
                label.Text = e.Item.DataItem.ToString();
            }
        }
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        parametersSet.Visible = true;
        lbMethods.Visible = true;
        string parameter = "";
        foreach (RepeaterItem item in parametersSet.Items)
        {
            TextBox text = item.FindControl("text") as TextBox;
            if (text.Text != "")
            {
                parameter += text.Text + ' ';

            }
        }
        parameter = parameter.Trim();
        string[] parameters = parameter.Split(' ');
        lbMethods.SelectedIndex = methodIndex;
        if (parameter != "")
        {
            lblResult.Text = service.WsTesting(txtWSDL.Text, lbMethods.SelectedItem.Text, parameters);
            btnInvoke.Visible = false;
        }
        else
        {
            lblResult.Text = "Please provide a parameter";
        }

    }
}