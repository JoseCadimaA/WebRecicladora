<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaProducto.aspx.cs" Inherits="ListaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2 class="text-center">Listado de Productos</h2>
    <br />
    <div class="row">
        <div class="col-md-8 offset-md-2">
            <asp:LinkButton runat="server" ID="btnAddNuevo" OnClick="btnAddNuevo_Click" Style="margin-right: 15px">Nuevo Producto</asp:LinkButton>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="GridProducto" runat="server"
                    OnRowCommand="GridProducto_RowCommand"
                    AutoGenerateColumns="false"
                    CssClass="table"
                    GridLines="None" DataKeyNames="ProductoId" DataSourceID="ProductoObjectDataSource">
                    <Columns>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server"
                                    CommandName="Editar"
                                    CommandArgument='<%# Eval("ProductoId") %>'>
                                <i class="fas fa-pencil-alt"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton" runat="server"
                                    CommandName="Eliminar"
                                    OnClientClick="return confirm('Esta seguro que desea eliminar el Producto?')"
                                    CommandArgument='<%# Eval("ProductoId") %>'>
                                <i class="fas fa-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"></asp:BoundField>
                        <asp:BoundField DataField="PrecioCompra" HeaderText="PrecioCompra" SortExpression="PrecioCompra"></asp:BoundField>
                        <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" SortExpression="PrecioVenta"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="ProductoObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaProductos" TypeName="ProductoDSTableAdapters.ProductoTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
    </div>

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

