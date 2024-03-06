<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAsignaturas.aspx.cs" Inherits="WebHorarios.WebFormAsignaturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <script>
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
    <form id="form1" runat="server">
        <div>
            Insertar Asignatura

            <asp:TextBox ID="TextBox1" runat="server" Width="230px"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Nombre Asignatura: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Horas: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Cuatrimestre: "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Descripción: "></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Insertar" Width="131px" OnClick="Button1_Click" />

            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>


            <asp:Label ID="Label5" runat="server" Text="Id: "></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Nombre Asignatura: "></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Horas: "></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Cuatrimestre: "></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Descripción: "></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Modificar" Width="131px" OnClick="Button2_Click" />



        </div>

        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Modal Header</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="LB" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
