using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace zhongchuang2017.page.identity
{
    public partial class applicant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                if (Session["uid"]==null)
                    Server.Transfer("../../login.aspx");
                submit.Attributes["OnClick"] = "return confirm('本表只允许提交一次!是否确认提交？')";
            }
           
           // isregister.Items.FindByValue("0").Selected = true;

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

        protected void submit_Click(object sender, EventArgs e)
        {
            int id = (int)Session["uid"];
            //Response.Write("<script>alert('本表只允许提交一次!是否确认提交？')</script>");

            if (check())
            {
                string str = "Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select id from info where id='" + id + "' ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds, "gg");//查询结果填充数据集     
                if (ds == null || ds.Tables.Count == 0 || (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))
                {
                    string strcmd1;
                    //在基本信息表中插入
                    strcmd1 = "insert into info (id,teamname,teamleader,tel,email,school,subject,grade,";
                    strcmd1 += "number,type,information,award,isregister,situation,plan,server)";
                    strcmd1 += "VALUES ('" + id + " ','" + teamname.Text.Trim() + " ','" + teamleader.Text.Trim() + " ','" + tel.Text.Trim() + " ','" + email.Text.Trim() + " ','" + school.Text.Trim() + " ','" + subject.Text.Trim() + " ','" + grade.Text.Trim() + " ','" + num.Text.Trim() + " ','" + 1 + " ','" + information.Text.Trim() + " ','" + award.Text.Trim() + " ','" + isregister.SelectedValue.ToString() + " ','" + situatioin.Text.Trim() + " ','" + plan.Text.Trim() + " ','" + server.Text.Trim() + "')";
                    MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script>alert('提交成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('您已提交过一次信息！不可重复提交！')</script>");
                }
            }
        }

        //判断是否符合格式要求
        //bug 弹窗太多，后将改用空间的显示与隐藏
        //CZJ 392067117@qq.com 2017/08/22
        protected bool check()
        {
            if (teamname.Text == "")
            {
                Response.Write("<script>alert('团队名称不能为空!')</script>");
                return false;
            }
            if (teamleader.Text == "")
            {
                Response.Write("<script>alert('团队负责人不能为空!')</script>");
                return false;
            }
            if (tel.Text == "")
            {
                Response.Write("<script>alert('手机号码不能为空!')</script>");
                return false;
            }
            if (email.Text == "")
            {
                Response.Write("<script>alert('邮箱不能为空!')</script>");
                return false;
            }
            if (school.Text == "")
            {
                Response.Write("<script>alert('学院不能为空!')</script>");
                return false;
            }
            if (subject.Text == "")
            {
                Response.Write("<script>alert('专业不能为空!')</script>");
                return false;
            }
            if (grade.Text == "")
            {
                Response.Write("<script>alert('年级不能为空!')</script>");
                return false;
            }
            if ( num.Text == "")
            {
                Response.Write("<script>alert('人数不能为空!')</script>");
                return false;
            }
            //if ( type.Text == "")
            //{
            //    Response.Write("<script>alert('类型不能为空!')</script>");
            //    return false;
            //}
            if ( information.Text == "")
            {
                Response.Write("<script>alert('简介不能为空!')</script>");
                return false;
            }
            if (award.Text == "")
            {
                Response.Write("<script>alert('已获奖项不能为空!')</script>");
                return false;
            }
            //if ( isregister.Text == "")
            //{
            //    Response.Write("<script>alert('是否注册不能为空!')</script>");
            //    return false;
            //}
            if (situatioin.Text == "")
            {
                Response.Write("<script>alert('项目运营情况不能为空!')</script>");
                return false;
            }
            if ( plan.Text == "")
            {
                Response.Write("<script>alert('未来计划不能为空!')</script>");
                return false;
            }
            return true;
        }

        protected void btnuploadBP_Click(object sender, EventArgs e)
        {
            try
            {
                //检测是否已选择文件
                if (FileUpload1.PostedFile.FileName == "")
                {
                    tips1.Text = "要上传的文件不允许为空！";
                    return;
                }
                //限制文件上传的大小
                else if (FileUpload1.PostedFile.ContentLength > (4194304))
                {
                    tips1.Text = "文件超过20M！";
                    return;
                }
                //上传文件
                else
                {
                    // String u_id = Session["uid"].ToString();
                    // String competition_id = Session["competition_id"].ToString();

                    //测试使用
                    int uid = (int)Session["uid"];
                   // string uid = "001";

                    //取得文件的扩展名,并转换成小写
                    string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();


                    string filepath = "../../file/BP/";

                    //如果不存在就创建file文件夹
                    if (Directory.Exists(Server.MapPath(filepath)) == false)
                    {
                        Directory.CreateDirectory(Server.MapPath(filepath));
                    }
                    //  string filepath = FileUpload1.PostedFile.FileName;
                    //   string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    //这是存到服务器上的虚拟路径
                    string virpath = filepath + uid + "-BP.zip";
                    //转换成服务器上的物理路径
                    string serverpath = Server.MapPath(virpath);// + filename;
                    FileUpload1.PostedFile.SaveAs(serverpath);
                    tips1.Text = "上传成功！";
                }
            }
            catch (Exception error)
            {
                tips1.Text = "处理发生错误！原因：" + error.ToString();
            }
        }

        protected void btnuploadOTHER_Click(object sender, EventArgs e)
        {
            try
            {
                //检测是否已选择文件
                if (FileUpload2.PostedFile.FileName == "")
                {
                    tips2.Text = "要上传的文件不允许为空！";
                    return;
                }
                //限制文件上传的大小
                else if (FileUpload1.PostedFile.ContentLength > (4194304))
                {
                    tips2.Text = "文件超过20M！";
                    return;
                }
                //上传文件
                else
                {
                    // String u_id = Session["uid"].ToString();
                    // String competition_id = Session["competition_id"].ToString();

                    //测试使用
                    int uid = (int)Session["uid"];
                    // string uid = "001";

                    //取得文件的扩展名,并转换成小写
                    string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();

                    string filepath = "../../file/OTH/";

                    //如果不存在就创建file文件夹
                    if (Directory.Exists(Server.MapPath(filepath)) == false)
                    {
                        Directory.CreateDirectory(Server.MapPath(filepath));
                    }
                    //  string filepath = FileUpload1.PostedFile.FileName;
                    //   string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    //这是存到服务器上的虚拟路径
                    string virpath = filepath + uid + "-OTHER.zip";
                    //转换成服务器上的物理路径
                    string serverpath = Server.MapPath(virpath);// + filename;
                    FileUpload2.PostedFile.SaveAs(serverpath);
                    tips2.Text = "上传成功！";
                }
            }
            catch (Exception error)
            {
                tips2.Text = "处理发生错误！原因：" + error.ToString();
            }
        }
    }
}