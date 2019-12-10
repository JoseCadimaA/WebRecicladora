<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaCliente.aspx.cs" Inherits="ListaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h2 class="text-center">Listado de Clientes</h2>
    <br />
    <div class="row">
        <div class="col-md-8 offset-md-2">
            <asp:LinkButton runat="server" ID="btnAddNuevo" OnClick="btnAddNuevo_Click" Style="margin-right: 15px">Nuevo Cliente</asp:LinkButton>
            <asp:LinkButton runat="server" ID="btnTodos" OnClick="btnTodos_Click" Style="margin-right: 15px">Ver Todos</asp:LinkButton>
            <asp:LinkButton runat="server" ID="btnCompradores" OnClick="btnCompradores_Click" Style="margin-right: 15px">Ver Compradores</asp:LinkButton>
            <asp:LinkButton runat="server" ID="btnVendedores" OnClick="btnVendedores_Click" Style="margin-right: 15px">Ver Vendedores</asp:LinkButton>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="GridCliente" runat="server"
                    OnRowCommand="GridCliente_RowCommand"
                    AutoGenerateColumns="false"
                    CssClass="table"
                    GridLines="None" DataKeyNames="ClienteId">
                    <Columns>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server"
                                    CommandName="Editar"
                                    CommandArgument='<%# Eval("ClienteId") %>'>
                                <i class="fas fa-pencil-alt"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton" runat="server"
                                    CommandName="Eliminar"
                                    OnClientClick="return confirm('Esta seguro que desea eliminar el Cliente?')"
                                    CommandArgument='<%# Eval("ClienteId") %>'>
                                <i class="fas fa-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CI" HeaderText="CI" SortExpression="CI"></asp:BoundField>
                        <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" SortExpression="NombreCompleto"></asp:BoundField>
                        <asp:BoundField DataField="EsVendedorForDsiplay" HeaderText="Tipo Cliente"></asp:BoundField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="VistaHD" />

    <!-- SweetAlert2 -->
    <script src="plugins/sweetalert2/sweetalert2.min.js"></script>
    <script type="text/javascript">
        function ShowMensaje(tipo, texto) {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            });
            Toast.fire({
                type: tipo,
                title: texto
            });
        }

    </script>
</asp:Content>

