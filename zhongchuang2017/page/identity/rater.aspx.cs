using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zhongchuang2017.page.identity
{
    public partial class rater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MENUBTNCLICK(object sender, EventArgs e)
        {
            //获取被触发的Button对象  
            Button b = (Button)sender;
            if (b.ID == "btnenter")
            {
                //激活View1  
                MultiView1.SetActiveView(View1);
            }
            else
            {
                //激活View2  
                MultiView1.SetActiveView(View2);
            }
        }
    }
}