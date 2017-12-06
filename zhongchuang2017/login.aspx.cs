using System;

namespace zhongchuang2017.page.identity
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //检查是否不符合格式要求
        //返回bool
        //bug 弹窗过多，稍后用控件显示隐藏来优化
        //CZJ 392067117@qq.com 2017/08/22
        protected bool check(string username, string password)
        {
            bool flag = true;
            if (username == "")
            {
                Response.Write("<script>alert('用户名不能为空')</script>");
                flag = false;
            }
            if (password == "")
            {
                Response.Write("<script>alert('密码不能为空')</script>");
                flag = false;
            }
            return flag;
        }

        //登录按钮响应函数
        //返回bool
        //CZJ 392067117@qq.com 2017/08/22
        protected void log_Click(object sender, EventArgs e)
        {
            if (check(username.Text, password.Text))
            {
                int id = global.Login(username.Text, password.Text);
                //判断返回值id
                //0为账号密码不匹配，否则id为用户id
                //CZJ 392067117@qq.com 2017/08/22
                if (id == 0)
                {
                    Response.Write("<script>alert('帐号或密码错误')</script>");//提示错误
                    return;
                }

                if (global.Usertype(id) == 1)
                {
                    Server.Transfer("~/indentity/applicant.aspx");
                }
                else if (global.Usertype(id) == 2)
                {
                    Server.Transfer("Home.html");
                }
                else if (global.Usertype(id) == 3)
                {
                    Server.Transfer("Home.html");
                }
                else
                {
                    Response.Write("<script>alert('出错啦！赶快联系客服！')</script>");
                }
                Response.Write("<script>alert('登录成功！')</script>");
                

            }
        }

        //记住密码
        //cookie记住密码
        //CZJ 392067117@qq.com 2017/08/22
        protected void username_TextChanged(object sender, EventArgs e)
        {
            if (Request.Cookies["userName"] != null)
            {
                if (Request.Cookies["userName"].Value.Equals(username.Text.Trim()))
                {
                    password.Attributes["value"] = Request.Cookies["passWord"].Value;
                }
            }
        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}