<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FormProducto.aspx.cs" Inherits="FormProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h2 class="text-center">Registro de Producto</h2>
    <br />

    <div class="row">
        <div class="col-md-4 offset-md-4">
            <asp:HyperLink runat="server" NavigateUrl="~/ListaProducto.aspx">Ver Listado de Productos</asp:HyperLink>
            <br />
            <div class="card card-warning">
                <div class="card-header">
                    <h3 class="card-title">Formulario Producto</h3>
                </div>
                <div role="form">
                    <div class="card-body">
                        <div class="form-group">
                            <label for="DescripcionTextBox">Descripción</label>
                            <asp:TextBox runat="server" ID="DescripcionTextBox" placeholder="Descripción" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="PrecioCompraTextBox">Precio Compra</label>
                                    <asp:TextBox runat="server" ID="PrecioCompraTextBox" placeholder="$ Compra" CssClass="form-control" required="required" Style="width: 100px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="PrecioVentaTextBox">PrecioVenta</label>
                                    <asp:TextBox runat="server" ID="PrecioVentaTextBox" placeholder="$ Venta" CssClass="form-control" required="required" Style="width: 100px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-warning btn-block" />
                            </div>
                            <div class="col-md-6">
                                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary btn-block" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="ProductoIdHD" />
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

