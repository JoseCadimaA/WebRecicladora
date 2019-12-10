<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FormAlmacen.aspx.cs" Inherits="FormAlmacen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="text-center">Registro de Almacen</h2>
    <br />

    <div class="row">
        <div class="col-md-4 offset-md-4">
            <asp:HyperLink runat="server" NavigateUrl="~/ListaAlmacen.aspx">Ver Listado de Almacenes</asp:HyperLink>
            <br />
            <div class="card card-dark">
                <div class="card-header">
                    <h3 class="card-title">Formulario Almacen</h3>
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
                                    <label for="CapacidadTextBox">Capacidad KG</label>
                                    <asp:TextBox runat="server" ID="CapacidadTextBox" placeholder="KG" CssClass="form-control" required="required" Style="width: 100px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="DisponibleTextBox">Disponible KG</label>
                                    <asp:TextBox runat="server" ID="DisponibleTextBox" placeholder="KG" CssClass="form-control" Style="width: 100px" Enabled="false" Text="0"></asp:TextBox>    
                                </div>
                                
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="ProductosList">Producto</label>
                            <asp:DropDownList runat="server" OnDataBound="ProductosList_DataBound" CssClass="form-control" ID="ProductosList" DataSourceID="ProductoObjectDataSource" DataTextField="descripcion" DataValueField="productoId">                                
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ProductoObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaProductos" TypeName="ProductoDSTableAdapters.ProductoTableAdapter"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-dark btn-block" />
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

    <asp:HiddenField runat="server" ID="AlmacenIdHD" />
    <asp:HiddenField runat="server" ID="LastCapacidadKGHD" />
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

