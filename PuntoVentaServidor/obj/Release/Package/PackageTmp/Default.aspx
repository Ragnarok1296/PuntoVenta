<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PuntoVentaServidor.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Servidor Punto de venta</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />

</head>
<body class="background">
    <form runat="server">
        <asp:ScriptManager runat="server">
                <Scripts>
                    <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                    <%--Framework Scripts--%>
                    <asp:ScriptReference Name="MsAjaxBundle" />
                    <asp:ScriptReference Name="jquery" />
                    <asp:ScriptReference Name="bootstrap" />
                    <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                    <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                    <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                    <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                    <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                    <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                    <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                    <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                    <asp:ScriptReference Name="WebFormsBundle" />
                    <%--Site Scripts--%>
                </Scripts>
        </asp:ScriptManager>

        <div class="container body-content">

            <div class="row">
                <div class="col-md-5 jumbotron MargenDiv">
                    <h2>Proveedores</h2>
                    <h3>WSDL de proveedores</h3>
                    <a href="/WebService/WSProveedores.asmx" class="btn btn-primary btn-lg">Ir a &raquo;</a>
                </div>

                <div class="col-md-5 jumbotron  MargenDiv">
                    <h2>Productos</h2>
                    <h3>WSDL de productos</h3>
                    <a href="/WebService/WSProductos.asmx" class="btn btn-primary btn-lg">Ir a &raquo;</a>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5 jumbotron MargenDiv">
                    <h2>Empleados</h2>
                    <h3>WSDL de empleados</h3></p>
                    <a href="/WebService/WSEmpleados.asmx" class="btn btn-primary btn-lg">Ir a &raquo;</a>
                </div>

                <div class="col-md-5 jumbotron  MargenDiv">
                    <h2>Ventas</h2>
                    <p><h3>WSDL de ventas</h3></p>
                    <a href="/WebService/WSVentas.asmx" class="btn btn-primary btn-lg">Ir a &raquo;</a>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
