using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zhongchuang2017.page.identity
{
    public partial class applicant : System.Web.UI.Page
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
                MultiView2.SetActiveView(application);
            }
            else if(b.ID == "btnupload")
            {
                //激活View2  
                MultiView1.SetActiveView(View2);
            }
            else 
            {
                //激活View3 
                MultiView1.SetActiveView(View3);
                MultiView3.SetActiveView(noticeshow);
            }
        }
        protected void TABLEBTNCLICK(object sender, EventArgs e)
        {
            //获取被触发的Button对象  
            Button b = (Button)sender;
            if (b.ID == "btnapplication")
            {
                //激活application  
                MultiView2.SetActiveView(application);
            }
            else
            {
                //激活info
                MultiView2.SetActiveView(infotable);
            }
        }

        protected void NOTICEBTNCLICK(object sender, EventArgs e)
        {
            //获取被触发的Button对象  
            Button b = (Button)sender;
            if (b.ID == "notice")
            {
                //激活 通知内容
                MultiView3.SetActiveView(noticeshow);
            }
            else
            {
                //激活 工作间分布内容
                MultiView3.SetActiveView(workplaceshow);
            }
        }

    }
}