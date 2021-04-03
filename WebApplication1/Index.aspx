<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>商品名稱</td>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>
            </tr>
            <tr>
                <td>重量</td>
                <td>
                    <asp:TextBox runat="server" ID="txtWeight"></asp:TextBox></td>
            </tr>
            <tr>
                <td>長</td>
                <td>
                    <asp:TextBox runat="server" ID="txtLength"></asp:TextBox></td>
            </tr>
            <tr>
                <td>寬</td>
                <td>
                    <asp:TextBox runat="server" ID="txtWidth"></asp:TextBox></td>
            </tr>
            <tr>
                <td>高</td>
                <td>
                    <asp:TextBox runat="server" ID="txtHeight"></asp:TextBox></td>
            </tr>
            <tr>
                <td>物流商</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLogistics">
                        <asp:ListItem Text="黑貓" value="1"></asp:ListItem>
                        <asp:ListItem Text="新竹貨運" value="2"></asp:ListItem>
                        <asp:ListItem Text="郵局" value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button runat="server" ID="btnCalculator"
                    Text="計算運費"
                    OnClick="btnCalculator_Click" />
        <hr/>
        計算結果:<br/>
        物流商:<asp:Label runat="server" id="lblLogistics"></asp:Label><br/>
        運費:<asp:Label runat="server" id="lblFee"></asp:Label>
    </div>
</form>
</body>
</html>