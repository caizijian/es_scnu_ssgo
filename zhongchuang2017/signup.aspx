<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="zhongchuang2017.page.identity.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <style>
        *{
              margin: 0 0 0px 0;
             padding: 0;
         }
        #table{
    width: 30%;
    height: auto;
    margin: 5% 0 0 0;
    padding: 0;
    position: absolute;
    left: 35%;
}
#table .tableBack{
    width: 100%;
    background: #002d54;
    display: block;
    text-align: center;
    font-size: 1.25em;
}
#table .tableBack .title{
    width: 50%;
    height: 5%;
    padding: 1%;
    position: relative;
    text-align: center;
    margin: 0 auto;
    overflow: hidden;
    border-radius: 1vw;
    background: #4e78ff;
}
#table .tableBack .title .logo{
    display: inline-block;
    width: 80%;
    margin: auto 0;
    vertical-align: middle;
    height: auto;
    text-align: center;
}
#table .tableBack .title .logo img{
    width: 4vw;
    float: left;
    position: relative;
}
#table .tableBack .title .logo h1{
    font-family: "Microsoft YaHei";
    font-size: 2vw;
    color: #ffffff;
    float: left;
    width: 65%;
    line-height: 4vw;
    position: relative;
}
#table .tableBack .title a{
    display: block;
    line-height: 0;
}
#table .tableBack .input p{
    font-family: "微软雅黑 Light";
    font-size: 1.5vw;
    color: #ffffff;
    margin: 1vw auto 0.5vw auto;
}
        body{
         background: #002d54;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="table">
    <div class="tableBack">
        <div class="title">
            <a href="Home.html">
                <div class="logo">
                    <img src="../img/system/home/loge.jpg" />
                    <h1>赛事GO</h1>
                </div>
            </a>
        </div>
        <div class="input">
            <p>注册</p><hr/>
            <div style="font-size:30px; height:130px">
           <div style="margin-top:20px;height:auto;font-size: 1vw;color: white;"><asp:Label ID="Label1" runat="server" Text=" 您的邮箱："></asp:Label> <asp:TextBox ID="username"  runat="server" TextMode="Email" ></asp:TextBox></div> 
            <div style="margin-top:10px;height:auto;font-size: 1vw;color: white;"><asp:Label ID="Label2" runat="server" Text="登录密码：" ></asp:Label><asp:TextBox ID="password" TextMode="Password" maxlength="32" runat="server"  minlength="6"></asp:TextBox></div>
            <div style="margin-top:10px;height:auto;font-size: 1vw;color: white;"><asp:Label ID="Label3" runat="server" Text="确认密码："></asp:Label><asp:TextBox ID="password1" TextMode="Password" maxlength="32" runat="server"  minlength="6"></asp:TextBox></div>
                 </div>

            <div style="font-size: 1vw;color: white;">
            <span>
                <asp:CheckBox ID="checkb" CssClass="checkb" checked="true" runat="server" />
                我已阅读并同意<a href="#">《赛事GO服务条款》</a>
            </span><span id="checktext4"></span>
            </div>
        </div>
        <div class="next">
            <asp:Button ID="next" runat="server" Text="注册" OnClick="next_Click" />
            <hr/>

        </div>
        <div style="font-size: 1vw;color: white;">
            <p>已经有账户？<a href="login.aspx">点击登陆</a></p>
            
        </div>
    </div>

</div>
    </form>
</body>
</html>
