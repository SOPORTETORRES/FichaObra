<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Prueba.aspx.vb" Inherits="Maqueta.Prueba" %>

<%@ Register Src="~/WebParts/PanelSuperior.ascx" TagPrefix="uc1" TagName="PanelSuperior" %>




<!DOCTYPE html>

  <!-- ===============================================-->
  <!--    Stylesheets-->
  <!-- ===============================================-->
  <link href="Complementos/css/theme.min.css" rel="stylesheet" id="style-default">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:PanelSuperior runat="server" ID="PanelSuperior" />
        </div>
    </form>
</body>

    <!-- ===============================================-->
    <!--    JavaScripts-->
    <!-- ===============================================-->
    <script src="Complementos/vendors/fontawesome/all.min.js"></script>
</html>
