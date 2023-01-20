<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Maqueta.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LOGIN</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin :auto; width: 50%; border: 3px solid orange; padding: 10px;">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
            <br />
            <asp:TextBox ID="txtUsuario" runat="server" Text="ADM"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <br />
            <asp:TextBox ID="txtPass" runat="server" Text="q.w.e.r.t.y"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" />
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
