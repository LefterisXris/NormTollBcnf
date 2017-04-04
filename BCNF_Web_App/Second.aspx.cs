using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Normalization;
using System.Net;

namespace BCNF_Web_App
{
    public partial class Second : System.Web.UI.Page
    {
        
        private List<Attr> attrList = new List<Attr>();
        private List<FD> fdList = new List<FD>();
        private string msg = "";
        private List<string> schemasForLoad = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            msg += "Logging Console...";
            log.InnerText = msg;

            if (IsPostBack == false)
            {
                attrList.Add(new Attr("A", ""));
                attrList.Add(new Attr("B", ""));
                attrList.Add(new Attr("C", ""));
                attrList.Add(new Attr("D", ""));
                attrList.Add(new Attr("E", ""));

                loadListBox(lboxAttr, 0);

                FD fd1 = new FD();
                fd1.AddLeft(attrList[0]);
                fd1.AddRight(attrList[1]);
                fd1.AddRight(attrList[2]);

                fdList.Add(fd1);

                FD fd2 = new FD();
                fd2.AddLeft(attrList[1]);
                fd2.AddRight(attrList[3]);
                fd2.AddRight(attrList[4]);

                fdList.Add(fd2);

                loadListBox(lboxFD, 1);

                updateCheckBoxLists();

                
                schemasForLoad.Add("f.nor");
                schemasForLoad.Add("sc_StockExchange.nor");
                schemasForLoad.Add("sc1_01.nor");
                schemasForLoad.Add("sc1_02.nor");
                schemasForLoad.Add("sc1_A1.nor");
                schemasForLoad.Add("sc1_A2.nor");
                schemasForLoad.Add("sc2_01.nor");
                schemasForLoad.Add("sc2_02.nor");
                schemasForLoad.Add("sc2_03.nor");
                schemasForLoad.Add("sc2_04.nor");
                schemasForLoad.Add("sc2_05.nor");
                schemasForLoad.Add("sc3.nor");
                schemasForLoad.Add("ΖΑΧΑΡΟΠΛΑΣΤΕΙΟ.nor");
                schemasForLoad.Add("ΙΑΤΡΕΙΟ.nor");

                loadSchemsDropDownList(schemasForLoad);



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
            if (ViewState["loadSchemas"] != null)
            {
                schemasForLoad = (List<string>)ViewState["loadSchemas"];
            }


            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState.Add("attrListVS", attrList);
            ViewState.Add("fdListVS", fdList);
            ViewState.Add("log", msg);
            ViewState.Add("loadSchemas", schemasForLoad);
        }

        
        protected void btnNewAttrClick(object sender, EventArgs e)
        {
            attrList.Add(new Attr(tbxNewAttrName.Text.Trim(),tbxNewAttrType.Text.Trim()));
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
                    int index = EglismosCheckBoxList.Items.IndexOf(item);
                    attrListSelected.Add(attrList[index]);
                }
            }

            Closure closure = new Closure(attrList, fdList);
            msg = closure.btnOK_Click(attrListSelected);
            log.InnerText = msg;
        }

        protected void CalculateKeys(object sender, EventArgs e)
        {
            Closure closure = new Closure(attrList, fdList);
            List<Key> keyList = new List<Key>();
            keyList = closure.KeysGet(fdList, attrList, true);

            msg = "";
            msg += "Υποψήφια κλειδιά Που βρέθηκαν: \n";

            foreach (Key key in keyList)
            {
                msg += key.ToString() + "\n";
            }

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

        protected void loadSchemsDropDownList(List<string> schemasForLoad)
        {
            foreach (String schema in schemasForLoad)
            {
                schemaLoadDropDownList.Items.Add(schema);
            }
        }

        protected void loadSchemasInApplication(object sender, EventArgs e)
        {
            int index = schemaLoadDropDownList.SelectedIndex;
            attrList.Clear();
            fdList.Clear();

            switch (index)
            {
                case 0:
                    attrList.Add(new Attr("A", "")); attrList.Add(new Attr("B", ""));
                    attrList.Add(new Attr("C", "")); attrList.Add(new Attr("D", ""));
                    attrList.Add(new Attr("E", ""));

                    FD fd1 = new FD();
                    fd1.AddLeft(attrList[0]); fd1.AddRight(attrList[1]); fd1.AddRight(attrList[2]);

                    FD fd2 = new FD();
                    fd2.AddLeft(attrList[1]); fd2.AddRight(attrList[3]); fd2.AddRight(attrList[4]);

                    fdList.Add(fd1);     fdList.Add(fd2);

                    loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    break;
                case 1:
                    attrList.Add(new Attr("A", "")); attrList.Add(new Attr("B", ""));
                    attrList.Add(new Attr("C", "")); attrList.Add(new Attr("D", ""));
                    attrList.Add(new Attr("E", ""));
                    //TODO: Load the schemas
                    FD fd1 = new FD();
                    fd1.AddLeft(attrList[0]); fd1.AddRight(attrList[1]); fd1.AddRight(attrList[2]);

                    FD fd2 = new FD();
                    fd2.AddLeft(attrList[1]); fd2.AddRight(attrList[3]); fd2.AddRight(attrList[4]);

                    fdList.Add(fd1); fdList.Add(fd2);

                    loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                default:
                    msg = "Προέκυψε κάποιο σφάλμα...";
                    log.InnerText = msg;
                    
                    SchemaLoaderMethod();
                    break;
            }
        }

        protected void SchemaLoaderMethod(List<string> attrNames, List<int> leftIndexes, List<int> rightIndexes)
        {
            attrList.Clear();
            foreach (string attrName in attrNames)
            {
                attrList.Add(new Attr(attrName, ""));
            }
            loadListBox(lboxAttr, 0);

            fdList.Clear();
            FD fd = new FD();
            foreach (int index in leftIndexes)
            {
                fd.AddLeft(attrList[index]);
            }

            foreach (int index in rightIndexes)
            {
                fd.AddRight(attrList[index]);
            }

            fdList.Add(fd);
            loadListBox(lboxFD, 1);
        }

        protected void loadbbb(object sender, EventArgs e)
        {
            foreach (Attr attr in attrList)
            {
                EglismosCheckBoxList.Items.Add(attr.Name);
            }
        }

        protected void UploadFile(object sender, EventArgs e)
        {
          /*  String uriString = "ftp://localhost/Files";


            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            string fileName = FileUpload1.FileName.ToString();

            // Upload the file to the URI.
            // The 'UploadFile(uriString,fileName)' method implicitly uses HTTP POST method.
            byte[] responseArray = myWebClient.UploadFile(uriString, fileName);

            // Decode and display the response.
            msg = System.Text.Encoding.ASCII.GetString(responseArray);
            log.InnerText = msg;*/
        }
    }
}