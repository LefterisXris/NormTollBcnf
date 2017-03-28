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
        
        private List<Attr> attrList = new List<Attr>();
        private List<FD> fdList = new List<FD>();
        private string msg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            msg += "Logging Console...";
            log.InnerText = msg;

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

            if (ViewState["attrListVS"] != null)
            {
                attrList = (List<Attr>)ViewState["attrListVS"];
            } 
            if (ViewState["fdListVS"] != null)
            {
                fdList = (List<FD>)ViewState["fdListVS"];
            }
            if (ViewState["log"] != null)
            {
                msg = (string)ViewState["log"];
            }


            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState.Add("attrListVS", attrList);
            ViewState.Add("fdListVS", fdList);
            ViewState.Add("log", msg);
        }

        
        protected void btnNewAttrClick(object sender, EventArgs e)
        {
            attrList.Add(new Attr(tbxNewAttrName.Text.ToString(),""));
            loadListBox(lboxAttr, 0);

            tbxNewAttrName.Text = "";
            updateCheckBoxLists();

            msg += "\nNew attribute inserted.";
            log.InnerText = msg;
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

            fdList.Add(fd);
            loadListBox(lboxFD,1);

            AttrCheckBoxList1.ClearSelection();
            AttrCheckBoxList2.ClearSelection();

            msg += "\nNew FD inserted.";
            log.InnerText = msg;
        }

        protected void deleteAttr(object sender, EventArgs e)
        {
            int index = lboxAttr.SelectedIndex;
            attrList.RemoveAt(index);
            
            loadListBox(lboxAttr,0);
        }

        protected void deleteFD(object sender, EventArgs e)
        {
            int index = lboxFD.SelectedIndex;
            fdList.RemoveAt(index);

            loadListBox(lboxFD, 1);
        }

        protected void CalculateClosure(object sender, EventArgs e)
        {
            List<Attr> attrListSelected = new List<Attr>();

            foreach (ListItem item in EglismosCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    int index = EglismosCheckBoxList.SelectedIndex;
                    attrListSelected.Add(attrList[index]);
                }
            }

            Closure closure = new Closure(attrList, fdList);
            msg = closure.btnOK_Click(attrListSelected);
            log.InnerText = msg;
        }

        
        protected void updateCheckBoxLists()
        {
            AttrCheckBoxList1.Items.Clear();
            AttrCheckBoxList2.Items.Clear();
            EglismosCheckBoxList.Items.Clear();

            foreach (Attr attr in attrList)
            {
                AttrCheckBoxList1.Items.Add(attr.Name);
                AttrCheckBoxList2.Items.Add(attr.Name);
                EglismosCheckBoxList.Items.Add(attr.Name);
            }
        }

        protected void loadListBox(ListBox lbox, int i)
        {
            lbox.Items.Clear();
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

        protected void loadbbb(object sender, EventArgs e)
        {
            foreach (Attr attr in attrList)
            {
                EglismosCheckBoxList.Items.Add(attr.Name);
            }
        }
    }
}