<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rater.aspx.cs" Inherits="zhongchuang2017.page.identity.rater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="showdownload" runat="server" Text="下载" OnClick="MENUBTNCLICK"/>
        <asp:Button ID="showrater" runat="server" Text="投票" OnClick="MENUBTNCLICK"/>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">

            </asp:View>
            <asp:View ID="View2" runat="server">

            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
