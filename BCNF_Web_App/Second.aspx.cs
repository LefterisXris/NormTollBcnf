using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Normalization;

namespace BCNF_Web_App
{
    public partial class Second : System.Web.UI.Page
    {
        private List<Attr> attrList
        {
            get { return ViewState["attrList"] as List<Attr>;}
            set { ViewState["attrList"] = value; }
        }
        //private List<Attr> attrList = new List<Attr>();
       
        private List<Attr> attrListRight = new List<Attr>();
        private List<FD> fdList = new List<FD>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                attrList.Add(new Attr("A", ""));
                attrList.Add(new Attr("B", ""));
                attrList.Add(new Attr("C", ""));

                loadListBox(lboxAttr, 0);

                FD fd1 = new FD();
                fd1.AddLeft(attrList[0]);
                fd1.AddRight(attrList[1]);
                fd1.AddRight(attrList[2]);

                fdList.Add(fd1);

                loadListBox(lboxFD, 1);

                updateCheckBoxLists();
            }
        }

        
        protected void btnNewAttrClick(object sender, EventArgs e)
        {
            attrList.Add(new Attr(tbxNewAttrName.Text.ToString(),""));
            loadListBox(lboxAttr, 0);

            tbxNewAttrName.Text = "";
            updateCheckBoxLists();
        }

        protected void btnNewFDClick(object sender, EventArgs e)
        {
            FD fd = new FD();
            
            foreach (ListItem item in AttrCheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    int i = AttrCheckBoxList1.Items.IndexOf(item);
                    fd.AddLeft(attrList[i]);
                }
            }

            foreach (ListItem item in AttrCheckBoxList2.Items)
            {
                if (item.Selected)
                {
                    int i = AttrCheckBoxList2.Items.IndexOf(item);
                    fd.AddRight(attrList[i]);
                }
            }

            loadListBox(lboxFD,1);

            AttrCheckBoxList1.ClearSelection();
            AttrCheckBoxList2.ClearSelection();
        }

        protected void deleteAttr(object sender, EventArgs e)
        {

        }

        protected void deleteFD(object sender, EventArgs e)
        {

        }

        protected void updateCheckBoxLists()
        {
            foreach (Attr attr in attrList)
            {
                AttrCheckBoxList1.Items.Add(attr.Name);
                AttrCheckBoxList2.Items.Add(attr.Name);
            }
        }

        protected void loadListBox(ListBox lbox, int i)
        {
            if (i == 0)
            {
                foreach (Attr attr in attrList)
                {
                    lbox.Items.Add(attr.Name);
                }
            }
            else if (i == 1)
            {
                foreach (FD fd in fdList)
                {
                    lbox.Items.Add(fd.ToString());
                }
            }
            
        }
    }
}