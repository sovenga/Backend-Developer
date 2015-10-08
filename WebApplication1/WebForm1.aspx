<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 146px">
    
        Enter Search Criteria<asp:TextBox ID="TextBox1" runat="server" Height="47px" style="margin-top: 27px" Width="204px"></asp:TextBox>
    
    </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Send to database" Width="127px" />
        </p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Create XML file" Width="129px" />
    </form>
</body>
</html>
