<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Calculator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="ExpressionText" runat="server" Height="50px" Width="440px"></asp:TextBox>
            <br />
            <asp:TextBox ID="CurrNumberText" runat="server" Height="50px" Width="440px"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonCE" runat="server" Text="CE" OnClick="CEButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonC" runat="server" Text="C" OnClick="CButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonDEL" runat="server" Text="DEL" OnClick="ButtonDEL_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonDIV" runat="server" Text="/" OnClick="OpButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="7" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="Button8" runat="server" Text="8" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="Button9" runat="server" Text="9" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonMUL" runat="server" Text="*" OnClick="OpButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="4" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="Button5" runat="server" Text="5" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="Button6" runat="server" Text="6" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonMIN" runat="server" Text="-" OnClick="OpButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="1" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="Button2" runat="server" Text="2" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="Button3" runat="server" Text="3" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonPLUS" runat="server" Text="+" OnClick="OpButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <br />
            <%--<asp:Button ID="Button17" runat="server" Text="+/-" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />--%>
            <asp:Button ID="Button0" runat="server" Text="0" OnClick="NumButton_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="true" BorderColor="#cccccc" BackColor="#111111" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonDOT" runat="server" Text="." OnClick="ButtonDOT_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
            <asp:Button ID="ButtonEQU" runat="server" Text="=" OnClick="ButtonEQU_Click" Height="80px" Width="110px" Font-Size="Large" Font-Bold="false" BorderColor="#cccccc" BackColor="#666666" BorderWidth="2px" ForeColor="White" />
        </div>
    </form>
</body>
</html>
