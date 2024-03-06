<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDocentes.aspx.cs" Inherits="WebHorario.WebFormDocentes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Insertar Docente</h2>
            <asp:TextBox ID="TextBox0" runat="server"></asp:TextBox>

            <!--Insertar-->
            <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Apellido Paterno: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Apellido Materno: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Insertar Docente" OnClick="Button1_Click" />

            <!--Mostrar-->
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <!--Modificar-->
            <h2>Modificar Docente</h2>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>


            <asp:Label ID="Label4" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Apellido Paterno: "></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Apellido Materno: "></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>

            <asp:Button ID="Button2" runat="server" Text="Modificar Docente" OnClick="Button2_Click" />


        </div>
    </form>
</body>
</html>
