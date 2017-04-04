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
               /* attrList.Add(new Attr("A", ""));
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

                updateCheckBoxLists();*/

                
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
            foreach (string schema in schemasForLoad)
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
                case 0: // f.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddRight(attrList[1]); fdT[0].AddRight(attrList[2]);
                        fdT[1].AddLeft(attrList[1]); fdT[1].AddRight(attrList[3]); fdT[1].AddRight(attrList[4]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 1: // sc_StockExchange.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "bra_name", "COM", "com_symbol", "ftse_name", "ftse_revision", "included_weigh", "PART", "PUB", "pub_com_id", "sed_gd", "ses_date", "SHA", "sha_afm", "sha_com_sharesnum", "SHEET", "sheet_id" };
                        string[] attrTypeRRR = new string[] { "string", "category, gdpart, name, sharesnum", "string", "string", "date", "single", "acts, close, high, low, open, value, volume", "date, intro, link, mme", "integer", "single", "date", "email, entity, name", "integer", "integer", "bookvalue, equity, profits, turnover, year", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD(), new FD(), new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[2]); fdT[0].AddRight(attrList[0]); fdT[0].AddRight(attrList[1]);
                        fdT[1].AddLeft(attrList[3]); fdT[1].AddRight(attrList[4]); 
                        fdT[2].AddLeft(attrList[2]); fdT[2].AddLeft(attrList[3]);  fdT[2].AddRight(attrList[5]);
                        fdT[3].AddLeft(attrList[2]); fdT[3].AddLeft(attrList[8]); fdT[3].AddRight(attrList[7]);
                        fdT[4].AddLeft(attrList[12]); fdT[4].AddRight(attrList[11]); 
                        fdT[5].AddLeft(attrList[2]); fdT[5].AddLeft(attrList[12]); fdT[5].AddRight(attrList[13]);
                        fdT[6].AddLeft(attrList[10]); fdT[6].AddRight(attrList[9]);
                        fdT[7].AddLeft(attrList[2]); fdT[7].AddLeft(attrList[10]); fdT[7].AddRight(attrList[6]);
                        fdT[8].AddLeft(attrList[15]); fdT[8].AddRight(attrList[2]); fdT[8].AddRight(attrList[14]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 2: // sc1_01.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddLeft(attrList[1]); fdT[0].AddRight(attrList[2]);
                        fdT[1].AddLeft(attrList[2]); fdT[1].AddLeft(attrList[3]); fdT[1].AddRight(attrList[4]);
                        fdT[2].AddLeft(attrList[3]); fdT[2].AddLeft(attrList[4]); fdT[2].AddRight(attrList[1]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 3: // sc1_02.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[1]); fdT[0].AddLeft(attrList[2]); fdT[0].AddRight(attrList[0]); fdT[0].AddRight(attrList[3]);
                        fdT[1].AddLeft(attrList[4]); fdT[1].AddRight(attrList[5]); fdT[1].AddRight(attrList[7]);
                        fdT[2].AddLeft(attrList[5]); fdT[2].AddRight(attrList[6]); fdT[2].AddRight(attrList[7]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 4: // sc1_A1.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[1]); fdT[0].AddRight(attrList[4]);
                        fdT[1].AddLeft(attrList[4]); fdT[1].AddRight(attrList[5]); fdT[1].AddRight(attrList[7]);
                        fdT[2].AddLeft(attrList[1]); fdT[2].AddLeft(attrList[2]); fdT[2].AddLeft(attrList[3]); fdT[2].AddRight(attrList[6]);
                        fdT[3].AddLeft(attrList[2]); fdT[3].AddLeft(attrList[3]); fdT[3].AddRight(attrList[0]);
                        fdT[4].AddLeft(attrList[0]); fdT[4].AddRight(attrList[9]);
                        fdT[5].AddLeft(attrList[8]); fdT[5].AddRight(attrList[1]); fdT[5].AddRight(attrList[2]); fdT[5].AddRight(attrList[3]); fdT[5].AddRight(attrList[4]);
                        fdT[6].AddLeft(attrList[7]); fdT[6].AddRight(attrList[8]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 5: // sc1_A2.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddLeft(attrList[1]);  fdT[0].AddRight(attrList[2]);
                        fdT[1].AddLeft(attrList[0]); fdT[1].AddRight(attrList[3]); fdT[1].AddRight(attrList[4]);
                        fdT[2].AddLeft(attrList[1]); fdT[2].AddRight(attrList[5]);
                        fdT[3].AddLeft(attrList[5]); fdT[3].AddRight(attrList[6]); fdT[3].AddRight(attrList[7]);
                        fdT[4].AddLeft(attrList[3]); fdT[4].AddRight(attrList[8]); fdT[4].AddRight(attrList[9]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 6: // sc2_01.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E", "F" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddRight(attrList[1]); fdT[0].AddRight(attrList[2]);
                        fdT[1].AddLeft(attrList[1]); fdT[1].AddRight(attrList[3]); 
                        fdT[2].AddLeft(attrList[0]); fdT[2].AddLeft(attrList[1]);  fdT[2].AddRight(attrList[4]);
                        fdT[3].AddLeft(attrList[4]); fdT[3].AddRight(attrList[5]); 
                        
                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 7: // sc2_02.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E", "F" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddRight(attrList[1]); fdT[0].AddRight(attrList[2]);
                        fdT[1].AddLeft(attrList[1]); fdT[1].AddRight(attrList[3]);
                        fdT[2].AddLeft(attrList[0]); fdT[2].AddLeft(attrList[3]); fdT[2].AddRight(attrList[4]);
                        fdT[3].AddLeft(attrList[3]); fdT[3].AddRight(attrList[5]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 8: // sc2_03.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E", "F" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddRight(attrList[1]); 
                        fdT[1].AddLeft(attrList[1]); fdT[1].AddRight(attrList[2]); fdT[1].AddRight(attrList[3]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 9: // sc2_04.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D" };
                        string[] attrTypeRRR = new string[] { "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddLeft(attrList[1]); fdT[0].AddRight(attrList[2]); fdT[0].AddRight(attrList[3]);
                        fdT[1].AddLeft(attrList[3]); fdT[1].AddRight(attrList[1]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 10: // sc2_05.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "A", "B", "C", "D", "E", "F", "G" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddRight(attrList[1]); fdT[0].AddRight(attrList[2]);
                        fdT[1].AddLeft(attrList[2]); fdT[1].AddRight(attrList[0]); fdT[1].AddRight(attrList[1]);
                        fdT[2].AddLeft(attrList[3]); fdT[2].AddLeft(attrList[4]); fdT[2].AddRight(attrList[5]);
                        fdT[3].AddLeft(attrList[5]); fdT[3].AddRight(attrList[3]); fdT[3].AddRight(attrList[4]);
                        fdT[4].AddLeft(attrList[2]); fdT[4].AddLeft(attrList[6]); fdT[4].AddRight(attrList[5]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 11: // sc3.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "cd_id", "cd_title", "company_id", "company_name", "composer_id", "composer_name", "lyricist_id", "lyricist_name", "performer_id", "performer_name", "rec_duration", "rec_id", "song_id", "song_title", "track_duration", "track_position", "year" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD(), new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[12]); fdT[0].AddRight(attrList[13]);
                        fdT[1].AddLeft(attrList[4]); fdT[1].AddRight(attrList[5]);
                        fdT[2].AddLeft(attrList[6]); fdT[2].AddRight(attrList[7]); 
                        fdT[3].AddLeft(attrList[11]); fdT[3].AddRight(attrList[10]); fdT[3].AddRight(attrList[12]);
                        fdT[4].AddLeft(attrList[8]); fdT[4].AddRight(attrList[9]);
                        fdT[5].AddLeft(attrList[0]); fdT[5].AddLeft(attrList[15]); fdT[5].AddLeft(attrList[11]); fdT[5].AddRight(attrList[14]);
                        fdT[6].AddLeft(attrList[0]); fdT[6].AddRight(attrList[1]); fdT[6].AddRight(attrList[2]); fdT[6].AddRight(attrList[16]);
                        fdT[7].AddLeft(attrList[2]); fdT[7].AddRight(attrList[3]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 12: // ΖΑΧΑΡΟΠΛΑΣΤΕΙΟ.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "ingr_avgcost", "ingr_name", "ingr_volume", "ord_date", "ord_id", "ord_prod_volume", "prod_ingr_volume", "prod_name", "prod_price" };
                        string[] attrTypeRRR = new string[] { "double", "string", "integer", "date", "integer", "double", "integer", "string", "double" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[1]); fdT[0].AddRight(attrList[0]);  fdT[0].AddRight(attrList[2]);
                        fdT[1].AddLeft(attrList[7]); fdT[1].AddRight(attrList[8]);
                        fdT[2].AddLeft(attrList[1]); fdT[2].AddLeft(attrList[7]);  fdT[2].AddRight(attrList[6]);
                        fdT[3].AddLeft(attrList[4]); fdT[3].AddLeft(attrList[7]);  fdT[3].AddRight(attrList[5]);
                        fdT[4].AddLeft(attrList[4]); fdT[4].AddRight(attrList[3]);
                       

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                case 13: // ΙΑΤΡΕΙΟ.nor
                    for (int j = 0; j < 1; j++)
                    {
                        string[] attrNamesRRR = new string[] { "AMKA", "appID", "doctorName", "patName", "time" };
                        string[] attrTypeRRR = new string[] { "", "", "", "", "" };

                        for (int i = 0; i < attrNamesRRR.Length; i++)
                        {
                            AttrCreate(attrNamesRRR[i], attrTypeRRR[i]);
                        }

                        FD[] fdT = new FD[] { new FD(), new FD(), new FD() };

                        fdT[0].AddLeft(attrList[0]); fdT[0].AddRight(attrList[3]);
                        fdT[1].AddLeft(attrList[1]); fdT[1].AddRight(attrList[0]); fdT[1].AddRight(attrList[2]); fdT[1].AddRight(attrList[4]);
                        fdT[2].AddLeft(attrList[4]); fdT[2].AddRight(attrList[1]);

                        for (int i = 0; i < fdT.Length; i++)
                        {
                            fdList.Add(fdT[i]);
                        }

                        loadListBox(lboxAttr, 0); loadListBox(lboxFD, 1); updateCheckBoxLists();
                    }
                    break;
                default:
                    msg = "Προέκυψε κάποιο σφάλμα...";
                    log.InnerText = msg;
                    
                    
                    break;
            }
        }

        protected void SchemaLoaderMethod(string[] attrNames)
        {
            attrList.Clear();
            foreach (string attrName in attrNames)
            {
                attrList.Add(new Attr(attrName, ""));
            }
            loadListBox(lboxAttr, 0);

           /* fdList.Clear();
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
            loadListBox(lboxFD, 1);*/
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

        /// <summary>
        /// Μέθοδος δημιουργίας νέου γνωρίσματος και προσθήκης του στην attrList. Επιστρέφει false αν το όνομα χρησιμοποιείται ήδη για άλλο αντικείμενο
        /// </summary>
        /// <param name="name">Ονομασία του γνωρίσματος</param>
        /// <param name="type">Τύπος του γνωρίσματος</param>
        protected bool AttrCreate(string name, string type)
        {
            //ελέγχεται αν το όνομα του νέου γνωρίσματος χρησιμοποιείται ήδη, κι αν ναι, επιστρέφεται η ένδειξη false
            if (AttrExists(name, null)) return false;

            //δημιουργείται αντικείμενο τύπου Attr και προστίθεται στην attrList
            Attr attr = new Attr(name, type);
            attrList.Add(attr);

            //επιστρέφεται η ένδειξη true
            return true;
        }

        /// <summary>
        /// Ελέγχει και επιστρέφει true αν το όνομα name χρησιμοποιείται ήδη για άλλο γνώρισμα
        /// </summary>
        /// <param name="name">Η ονομασία του γνωρίσματος που ελέγχουμε</param>
        /// <param name="attr">Η αναφορά στο αντικείμενο του γνωρίσματος</param>
        public bool AttrExists(string name, Attr attr)
        {
            for (int i = 0; i < attrList.Count; i++)
                if (attrList[i].Name == name && attr != attrList[i]) return true; //το όνομα χρησιμοποιείται ήδη
            return false; //το όνομα δεν χρησιμοποιείται
        }

        /// <summary>
        /// Μέθοδος ελέγχου και προσθήκης νέας συναρτησιακής εξάρτησης στην FDList
        /// </summary>
        /// <param name="fd">Το αντικείμενο συναρτησιακής εξάρτησης fd θα ελεγχθεί αν υπάρχει κάποιο άλλο παρόμοιο με αυτό πριν καταχωρηθεί.</param>
        public bool FDCreate(FD fd)
        {
            //ελέγχεται αν η νέα συναρτησιακή εξάρτηση είναι παρόμοια με μια άλλη, κι αν ναι, επιστρέφεται η ένδειξη false
            if (FDExists(fd, -1)) return false;

            //το νέο αντικείμενο προστίθεται στην FDList
            fdList.Add(fd);

            //επιστρέφεται η ένδειξη true
            return true;
        }

        /// <summary>
        /// Ελέγχει και επιστρέφει true αν υπάρχει παρόμοια συναρτησιακή εξάρτηση
        /// </summary>
        /// <param name="fd">Το αντικείμενο της συναρτησιακής εξάρτησης που ελέγχουμε</param>
        /// <param name="id">Ο αύξοντας αριθμός της υπό επεξεργασία συναρτησιακής εξάρτησης</param>
        public bool FDExists(FD fd, int id)
        {
            for (int i = 0; i < fdList.Count; i++)
                if (fdList[i].ToString() == fd.ToString() && i != id) return true; //βρέθηκε παρόμοια συναρτησιακή εξάρτηση
            return false; //δεν υπάρχει παρόμοια συναρτησιακή εξάρτηση
        }
    }
}