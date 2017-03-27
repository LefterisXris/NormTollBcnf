using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Normalization;

namespace BCNF_Web_App
{
    public partial class Create_Schema : System.Web.UI.Page
    {
        private List<Attr> attrListLeft = new List<Attr>();
        private List<Attr> attrListRight = new List<Attr>();
        private List<FD> fdList = new List<FD>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string name = (string)(Session["NewSchemaName"]);
            lblSchemaName.Text = name;
            //lblNewSchemaName.Text = name;

            if (IsPostBack == false)
            {
                AttrList.Items.Add("kkk");
                AttrList.Items.Add("ppp");
                AttrList.Items.Add("vvv");

                

                AtrrCheckBoxList1.Items.Add("kkk");
                AtrrCheckBoxList1.Items.Add("ppp");
                AtrrCheckBoxList1.Items.Add("vvv");

                AtrrCheckBoxList2.Items.Add("kkk");
                AtrrCheckBoxList2.Items.Add("ppp");
                AtrrCheckBoxList2.Items.Add("vvv");
            }
        }


        protected void btnNewAttrClick(Object sender, EventArgs e)
        {
            lblAttrName.Text = tbxNewAttrName.Text.ToString();
            AttrList.Items.Add(lblAttrName.Text);

            AtrrCheckBoxList1.Items.Add(lblAttrName.Text);
            AtrrCheckBoxList2.Items.Add(lblAttrName.Text);
            tbxNewAttrName.Text = "";
           
        }

        

        protected void btnNewFDClick(object sender, EventArgs e)
        {

            string FD = "";

            foreach (ListItem item in AtrrCheckBoxList1.Items)
                if (item.Selected)
                {
                    FD += item;
                    FD += ", ";
                }

            FD = FD.Remove(FD.Length - 2);

            FD += " ---> ";
          
            foreach (ListItem item in AtrrCheckBoxList2.Items)
                if (item.Selected)
                {
                    FD += item;
                    FD += ", ";
                }

            FD = FD.Remove(FD.Length - 2);

            FDList.Items.Add(FD);

            AtrrCheckBoxList1.ClearSelection();
            AtrrCheckBoxList2.ClearSelection();
        }

        protected void deleteAttr(object sender, EventArgs e)
        {
            AttrList.Items.RemoveAt(AttrList.SelectedIndex);
        }

        protected void deleteFD(object sender, EventArgs e)
        {
            FDList.Items.RemoveAt(FDList.SelectedIndex);
        }



    }
}