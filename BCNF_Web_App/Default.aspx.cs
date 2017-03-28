using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Normalization; // κάνει διαθέσιμες με αυτόν τον τρόπο τις κλάσεις που έφτιαξα.

namespace BCNF_Web_App
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            // κακός χειρισμός.
            Attr attr1 = new Attr("A", "string");
     
            // Καλύτερα με λίστες. Λίστα με γνωρίσματα
            List<Attr> attrList = new List<Attr>();
            attrList.Add(new Attr("B" , "string"));//0
            attrList.Add(new Attr("C", "string"));//1
            attrList.Add(new Attr("D", "string"));//2
            attrList.Add(new Attr("E", "string"));//3
            attrList.Add(new Attr("F", "string"));//4
            attrList.Add(new Attr("G", "string"));//5
            attrList.Add(new Attr("H", "string"));//6

            // Λίστα με συναρτησιακές εξαρτήσεις.
            // List<FD> fdList = new List<FD>();
            //fdList.Add(new FD());
            // B,C --> A,D
            FD fd1 = new FD(); 
            fd1.AddLeft(attrList[0]);
            fd1.AddLeft(attrList[1]);

            fd1.AddRight(attr1);
            fd1.AddRight(attrList[2]);

            // E --> F,H
            FD fd2 = new FD(); 
            fd2.AddLeft(attrList[3]);

            fd2.AddRight(attrList[4]);
            fd2.AddRight(attrList[6]);

            // F --> G,H
            FD fd3 = new FD();
            fd3.AddLeft(attrList[4]);

            fd3.AddRight(attrList[5]);
            fd3.AddRight(attrList[6]);

            Label1.Text = fd1.ToString();
            Label2.Text = fd2.ToString();
            Label3.Text = fd3.ToString();

            result_tb.Text = "";

        }


        protected void AddAttributeBtnClick(object sender, ImageClickEventArgs e)
        {
            //Button clickedButton = (Button)/*sender*/;
            result_tb.Text += input_tb.Text;
            result_tb.Text += ", ";
        }

        protected void input_tb_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnNewNameSchema(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only alert Message');", true);

            Session["NewSchemaName"] = tbxNewSchemaName.Text.ToString();
            try
            {
                Server.Transfer("Second.aspx", true);
            }
            catch (Exception ex)
            {
                throw new HttpException("blabla");
            }
            

            
        }

    }
}