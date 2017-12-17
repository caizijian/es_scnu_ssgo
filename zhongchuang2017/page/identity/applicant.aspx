<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="applicant.aspx.cs" Inherits="zhongchuang2017.page.identity.applicant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnenter" runat="server" Text="报名" OnClick="MENUBTNCLICK" />
        <asp:Button ID="btnupload" runat="server" Text="上传资料" OnClick="MENUBTNCLICK"/>
        <asp:Button ID="btnnotice" runat="server" Text="查看通知" OnClick="MENUBTNCLICK"/>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Button ID="btnapplication" runat="server" Text="申请表" OnClick="TABLEBTNCLICK"/>
                <asp:Button ID="btninfo" runat="server" Text="基本信息表" OnClick="TABLEBTNCLICK"/>
                <asp:MultiView ID="MultiView2" runat="server">
                    <asp:View ID="application" runat="server">
                        <asp:Label runat="server" Text="团队名称："></asp:Label>
                        <asp:TextBox ID="teamname" runat="server"></asp:TextBox>
                        <asp:Label runat="server" Text="团队负责人："></asp:Label>
                        <asp:TextBox ID="teamleader" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="手机号码："></asp:Label>
                        <asp:TextBox ID="tel" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="邮箱："></asp:Label>
                        <asp:TextBox ID="email" runat="server" AutoCompleteType="Email" TextMode="Email"></asp:TextBox>
                        <asp:Label  runat="server" Text="负责人所在学院："></asp:Label>
                        <asp:TextBox ID="school" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="专业："></asp:Label>
                        <asp:TextBox ID="subject" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="年级："></asp:Label>
                        <asp:TextBox ID="grade" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="团队人数："></asp:Label>
                        <asp:TextBox ID="num" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="项目类型："></asp:Label>
                        <asp:DropDownList ID="type" runat="server"></asp:DropDownList>
                        <asp:Label  runat="server" Text="项目简介："></asp:Label>
                        <asp:TextBox ID="information" runat="server" MaxLength="200"></asp:TextBox>
                        <asp:Label  runat="server" Text="目前所获奖项："></asp:Label>
                        <asp:TextBox ID="award" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="是否工商注册："></asp:Label>
                        <asp:DropDownList ID="isregister" runat="server" >
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label  runat="server" Text="项目运营情况："></asp:Label>
                        <asp:TextBox ID="situatioin" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="未来运营计划："></asp:Label>
                        <asp:TextBox ID="plan" runat="server"></asp:TextBox>
                        <asp:Label  runat="server" Text="希望创院提供的服务："></asp:Label>
                        <asp:TextBox ID="server" runat="server"></asp:TextBox>
                        <asp:Button ID="submit" runat="server" Text="提交" OnClick="submit_Click" />
                    </asp:View>
                    <asp:View ID="infotable" runat="server">
                        <asp:Label runat="server" Text="暂无"></asp:Label>
                    </asp:View>
                </asp:MultiView>
                
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Label  runat="server" Text="商业计划书："></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" accept=".zip"/>
                <asp:Button ID="btnuploadBP" runat="server" Text="提交" OnClick="btnuploadBP_Click" />
                <asp:Label ID="tips1" runat="server" Text="" style="width:100px"></asp:Label>

                <asp:Label  runat="server" Text="其他补充材料："></asp:Label>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:Button ID="btnuploadOTHER" runat="server" Text="提交" OnClick="btnuploadOTHER_Click" />
                <asp:Label ID="tips2" runat="server" Text=""></asp:Label>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:Button ID="notice" runat="server" Text="通知" OnClick="NOTICEBTNCLICK"/>
                <asp:Button ID="workplace" runat="server" Text="工作间分布图" OnClick="NOTICEBTNCLICK"/>
                <asp:MultiView ID="MultiView3" runat="server">
                    <asp:View ID="noticeshow" runat="server">
                        <a>tongzhi</a>
                    </asp:View>
                    <asp:View ID="workplaceshow" runat="server">
                        <a>gongzuojian</a>
                    </asp:View>

                </asp:MultiView> 

            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
