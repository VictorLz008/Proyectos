<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroAsistencia.aspx.cs" Inherits="WebHorarios.RegistroAsistencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            <h2>Insertar Registro Asistencia</h2>
            <asp:TextBox ID="TextBox0" runat="server" Enabled="False"></asp:TextBox>

            <!--Insertar-->
            <asp:Label ID="Label1" runat="server" Text="Fecha: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Horario "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="29px" Width="231px">
            </asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Text="Tema: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Total Alumnos: "></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Observaciones "></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Insertar Docente" OnClick="Button1_Click" />

            <!--Mostrar-->
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" CellPadding="3" GridLines="None" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>

            <!--Modificar-->
            <h2>Modificar Docente</h2>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

            <asp:Label ID="Label4" runat="server" Text="Fecha: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Horario "></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" Height="29px" Width="231px">
            </asp:DropDownList>
            <asp:Label ID="Label6" runat="server" Text="Tema: "></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Total Alumnos: "></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:Label ID="Label10" runat="server" Text="Observaciones "></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>

            <asp:Button ID="Button2" runat="server" Text="Modificar Docente" OnClick="Button2_Click" />

            <!-- Modal -->
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
        </div>

    </form>
</body>
</html>