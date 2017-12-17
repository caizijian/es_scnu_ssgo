using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace zhongchuang2017.page.identity
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void next_Click(object sender, EventArgs e)
        {
            //注册功能
            //CZJ 392067117@qq.com 2017/08/22
            if (check())
            {
                //判断是否符合格式要求
                string str = "Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select id from user where username='" + username.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds, "gg");//查询结果填充数据集     
                if (ds == null || ds.Tables.Count == 0 || (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))
                {
                    string strcmd1;
                    //在用户表中插入
                    strcmd1 = "insert into user (username,password,type) VALUES ('" + username.Text.Trim() + " ','" + password.Text.Trim() + "','" + 1 + "')";
                    MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
                    cmd1.ExecuteNonQuery();
                    //初始化主办方表中的用户信息
                   int id = global.Login(username.Text.Trim(), password.Text.Trim());
                  
                   Session["uid"] = id;
                   MySqlCommand cmd2 = new MySqlCommand(strcmd1, con);
                   cmd2.ExecuteNonQuery();
                   Response.Write("<script>alert('注册成功！')</script>");
                   Response.Redirect("login.aspx", false);
                }
                else
                {
                    Response.Write("<script>alert('用户名已存在！')</script>");
                }
            }
        }

        //判断是否符合格式要求
        //bug 弹窗太多，后将改用空间的显示与隐藏
        //CZJ 392067117@qq.com 2017/08/22
        protected bool check()
        {
            bool flag = true; ;
            if (username.Text == "")
            {
                Response.Write("<script>alert('用户名不能为空!')</script>");
                flag = false;
            }
            if (password.Text == "")
            {
                Response.Write("<script>alert('密码不能为空!')</script>");
                flag = false;
            }
            if (password.Text == "")
            {
                Response.Write("<script>alert('密码不能为空!')</script>");
                flag = false;
            }
            if (password.Text != password1.Text)
            {
                Response.Write("<script>alert('两次密码不一致!')</script>");
                flag = false;
            }
            if (checkb.Checked == false)
            {
                Response.Write("<script>alert('请同意《赛事GO服务条款》后重试！')</script>");
                flag = false;
            }

            return flag;
        }
    }
}