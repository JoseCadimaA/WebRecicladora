<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaAlmacen.aspx.cs" Inherits="ListaAlmacen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h2 class="text-center">Listado de Almacenes</h2>
    <br />
    <div class="row">
        <div class="col-md-8 offset-md-2">
            <asp:LinkButton runat="server" ID="btnAddNuevo" OnClick="btnAddNuevo_Click" Style="margin-right: 15px">Nuevo Almacen</asp:LinkButton>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="GridAlmacen" runat="server"
                    OnRowCommand="GridAlmacen_RowCommand"
                    AutoGenerateColumns="false"
                    CssClass="table"
                    GridLines="None" DataKeyNames="AlmacenId" DataSourceID="AlmacenObjectDataSource">
                    <Columns>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server"
                                    CommandName="Editar"
                                    CommandArgument='<%# Eval("AlmacenId") %>'>
                                <i class="fas fa-pencil-alt"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton" runat="server"
                                    CommandName="Eliminar"
                                    OnClientClick="return confirm('Esta seguro que desea eliminar el Almacen?')"
                                    CommandArgument='<%# Eval("AlmacenId") %>'>
                                <i class="fas fa-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"></asp:BoundField>
                        <asp:BoundField DataField="CapacidadForDisplay" HeaderText="Capacidad KG."></asp:BoundField>
                        <asp:BoundField DataField="RestanteForDisplay" HeaderText="Disponible KG."></asp:BoundField>
                        <asp:BoundField DataField="ProductoForDisplay" HeaderText="Producto" SortExpression="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>

                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource runat="server" ID="AlmacenObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaAlmacen" TypeName="AlmacenBLL"></asp:ObjectDataSource>
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

