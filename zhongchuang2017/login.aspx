<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="zhongchuang2017.page.identity.login" %>

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
    <title>华南师范大学创业学院 入驻申报平台</title>
</head>
<body>
    <form id="form1" runat="server">
<div id="table">
    <div class="tableBack">
        <div class="title">
            <a href="Home.html">
                <div class="logo">
                    <img src="../img/system/home/logo.jpg" />
                    <h1>赛事GO</h1>
                </div>
            </a>
        </div>
        <div class="input">
            <p>登录</p><hr/>
            <div style="height:70px">
           <div style="margin-top:20px;height:auto;font-size: 1.5vw;color: white;"><asp:Label ID="Label1" runat="server" Text=" 用户名："></asp:Label> <asp:TextBox ID="username"  runat="server" TextMode="Email" OnTextChanged="username_TextChanged"></asp:TextBox></div> 
            <div style="margin-top:10px;height:auto;font-size: 1.5vw;color: white;">
                <asp:Label ID="Label2" runat="server" Text="密码：" ></asp:Label>
                <asp:TextBox ID="password" style="position:relative;left:12px" TextMode="Password" maxlength="32" runat="server" OnTextChanged="password_TextChanged" minlength="6">密码</asp:TextBox>

            </div>
             </div>
            <div style="margin-top:20px; font-size: 1vw;color: white;">
               <span id="checktext1"></span> 
            <span id="checktext2"></span>
            <span style="margin-left:20px;"><asp:CheckBox runat="server" CssClass="check"  id="remember" />记住密码</span>
            <span><a href="Resetpassword.html" >忘记密码？
            </a></span>
            </div>
          
        </div>
        <div class="next" >
            <asp:Button ID="log" runat="server" Text="登录" OnClick="log_Click" style="margin-left:10px;margin-top:10px;margin-bottom:20px;height:30px;width:100px;" BackColor="#4E78FF" BorderColor="#3333CC" BorderStyle="None" />
            <hr/>

        </div>
        <div style="font-size: 1vw;color: white;">
            <p>还没有账户？<a href="signup.aspx">点击注册</a></p>
            
        </div>
    </div>

</div>
    </form>
</body>
</html>
