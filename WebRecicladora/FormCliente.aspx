<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FormCliente.aspx.cs" Inherits="FormCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="text-center">Registro de Cliente</h2>
    <br />

    <div class="row">
        <div class="col-md-4 offset-md-4">
            <asp:HyperLink runat="server" NavigateUrl="~/ListaCliente.aspx">Ver Listado Clientes</asp:HyperLink>
            <br />
            <div class="card card-success" runat="server" id="PanelUsuario">
                <div class="card-header">
                    <h3 class="card-title">Formulario Cliente</h3>
                </div>
                <div role="form">
                    <div class="card-body">
                        <div class="form-group">
                            <label for="CITextBox">CI</label>
                            <asp:TextBox runat="server" ID="CITextBox" placeholder="CI" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="NombreCompletoTextBox">Nombre Completo</label>
                            <asp:TextBox runat="server" ID="NombreCompletoTextBox" placeholder="Nombre Completo" CssClass="form-control" required="required"></asp:TextBox>
                        </div>

                        <div class="form-check">
                            <asp:CheckBox runat="server" ID="EsVendedorCheckBox" Text="Es vendedor de material" CssClass="form-check-input" />
                        </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success btn-block" />
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

    <asp:HiddenField runat="server" ID="ClienteIdHD"/>
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

