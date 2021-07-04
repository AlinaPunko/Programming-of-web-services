<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab4_WebForm._Default"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="x" />
            <asp:TextBox runat="server" ID="y" />
            <asp:Button runat="server" ID="add" OnClick="Add_Click" Text="Add" />
            <asp:TextBox runat="server" ID="result1" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="s" />
            <asp:Button runat="server" ID="concat" OnClick="Concat_Click" Text="Concat" />
            <asp:TextBox runat="server" ID="result2" />
            <br />
            <br />
            <br />
            <asp:TextBox runat="server" ID="s1" />
            <asp:TextBox runat="server" ID="s2" />
            &nbsp;<br />
            <asp:TextBox runat="server" ID="k1" />
            <asp:TextBox runat="server" ID="k2" />
            <asp:Button runat="server" ID="sum" OnClick="Sum_Click" Text="Sum" />
            &nbsp;<asp:TextBox runat="server" ID="s3" Width="148px" />
            <asp:TextBox runat="server" ID="k3" />
            <asp:TextBox runat="server" ID="f3" />
            <br />
            <asp:TextBox runat="server" ID="f1" />
            <asp:TextBox runat="server" ID="f2" />
        </div>
    </form>
</body>
</html>
