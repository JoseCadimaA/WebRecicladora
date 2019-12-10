<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FormCompra.aspx.cs" Inherits="FormCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="text-center">Registro de Compra</h2>
    <br />

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <asp:HyperLink runat="server" NavigateUrl="~/ListaCompras.aspx">Ver Listado de Compras</asp:HyperLink>
            <br />
            <div class="card card-secondary">
                <div class="card-header">
                    <h3 class="card-title">Formulario Compra</h3>
                </div>
                <div role="form">
                    <div class="card-body">
                        <div class="form-group">
                            <label for="ClienteList">Cliente</label>
                            <asp:DropDownList runat="server" OnDataBound="ClienteList_DataBound" CssClass="form-control" ID="ClienteList" DataSourceID="ClienteObjectDataSource" DataTextField="nombreCompleto" DataValueField="clienteId"></asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ClienteObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaClientesCompradores" TypeName="ClienteBLL"></asp:ObjectDataSource>
                        </div>
                        <div class="form-group">
                            <label for="DescripcionTextBox">Descripción</label>
                            <asp:TextBox runat="server" ID="DescripcionTextBox" placeholder="Descripción" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="SubTotalTextBox">Sub Total</label>
                            <asp:TextBox runat="server" ID="SubTotalTextBox" placeholder="$ SubTotal" CssClass="form-control" required="required" Style="width: 100px" Text="0" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="form-group" runat="server" id="PanelDetalle" visible="false">
                            <h4 class="text-center">Detalle de Compra</h4>
                            <asp:LinkButton runat="server" ID="btnAddProducto" OnClick="btnAddProducto_Click" Style="margin-right: 15px">Nueva Producto</asp:LinkButton>
                            <div class="table-responsive">
                                <asp:GridView ID="GridProducto" runat="server"
                                    OnRowCommand="GridProducto_RowCommand"
                                    AutoGenerateColumns="false"
                                    CssClass="table"
                                    GridLines="None" DataKeyNames="ProductoId" DataSourceID="FacturaDetalleObjectDataSource">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="DeleteButton" runat="server"
                                                    CommandName="Eliminar"
                                                    OnClientClick="return confirm('Esta seguro que desea eliminar el detalle?')"
                                                    CommandArgument='<%# Eval("ProductoId") %>'>
                                <i class="fas fa-trash"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NombreProducto" HeaderText="Producto" SortExpression="NombreProducto"></asp:BoundField>
                                        <asp:BoundField DataField="PesoKG" HeaderText="Peso KG."></asp:BoundField>
                                        <asp:BoundField DataField="Monto" HeaderText="Monto Pago"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>


                                <asp:ObjectDataSource runat="server" ID="FacturaDetalleObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetFacturaDetalleByFactID" TypeName="FacturaDetalleDSTableAdapters.FacturaDetalleTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="FacturaIdHD" PropertyName="Value" DefaultValue="0" Name="intFacturaId" Type="Int32"></asp:ControlParameter>
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>


                        </div>

                        <div class="row" id="PanelBtnGuardar" runat="server" visible="true">
                            <div class="col-md-6 form-group" runat="server">
                                <asp:Button runat="server" ID="btnGuardar" Text="Insertar" OnClick="btnGuardar_Click" CssClass="btn btn-secondary btn-block" />
                            </div>
                            <div class="col-md-6 form-group" runat="server">
                                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-default btn-block" />
                            </div>
                        </div>
                        <div class="row" id="PanelBtnTerminar" runat="server" visible="false">
                            <div class="col-md-6 form-group" runat="server">
                                <asp:Button runat="server" ID="btnTerminar" Text="Terminar" OnClick="btnTerminar_Click" CssClass="btn btn-secondary btn-block" />
                            </div>
                            <div class="col-md-6 form-group" runat="server">
                                <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-default btn-block" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalDetalle">
        <div class="modal-dialog">
            <div class="modal-content bg-secondary">
                <div class="modal-header">
                    <h4 class="modal-title">Detalle</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="ProductosList">Producto</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ProductosList" AutoPostBack="true" DataSourceID="ProductoObjectDataSource"
                            DataTextField="descripcion" DataValueField="productoId" OnSelectedIndexChanged="ProductosList_SelectedIndexChanged"
                            OnDataBound="ProductosList_DataBound">
                        </asp:DropDownList>
                        <asp:ObjectDataSource runat="server" ID="ProductoObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaProductos" TypeName="ProductoDSTableAdapters.ProductoTableAdapter"></asp:ObjectDataSource>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="PrecioTextBox">Precio x KG</label>
                                <asp:TextBox runat="server" ID="PrecioTextBox" placeholder="valor x KG" CssClass="form-control" Style="width: 100px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="PesoKGTextBox">KG</label>
                                <asp:TextBox runat="server" ID="PesoKGTextBox" placeholder="KG" CssClass="form-control" Style="width: 100px"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer justify-content-between">
                    <asp:Button runat="server" ID="btnCancelarDetalle" OnClick="btnCancelarDetalle_Click" Text="Cancelar" CssClass="btn btn-outline-light" />
                    <asp:Button runat="server" ID="btnGuardarDetalle" OnClick="btnGuardarDetalle_Click" Text="Guardar" CssClass="btn btn-outline-light" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <asp:HiddenField runat="server" ID="FacturaIdHD" />
    <asp:HiddenField runat="server" ID="ShowModalHD" />
    <!-- SweetAlert2 -->
    <script src="plugins/sweetalert2/sweetalert2.min.js"></script>
    <script src="plugins/jquery/jquery.min.js"></script>
    <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript">

        (function () {
            if ($("#<%= ShowModalHD.ClientID %>").val() == 'true') {
                $("#modalDetalle").modal("show");
            } else {
                $("#modalDetalle").modal("hide");
            }

        })();

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

