<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FormUsuario.aspx.cs" Inherits="FormUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h2 class="text-center">Listado de Usuario</h2>
    <br />
    <asp:LinkButton runat="server" ID="btnAddUsuario" OnClick="btnAddUsuario_Click">Registrar nuevo Usuario</asp:LinkButton>
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="table-responsive">
                <asp:GridView ID="GridUsuario" runat="server"
                    OnRowCommand="GridUsuario_RowCommand"
                    AutoGenerateColumns="false"
                    CssClass="table"
                    GridLines="None" DataKeyNames="usuarioId" DataSourceID="UsuarioObjectDataSource">
                    <Columns>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server"
                                    CommandName="Editar"
                                    CommandArgument='<%# Eval("UsuarioId") %>'>
                                <i class="fas fa-pencil-alt"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton" runat="server"
                                    CommandName="Eliminar"
                                    OnClientClick="return confirm('Esta seguro que desea eliminar el Usuario?')"
                                    CommandArgument='<%# Eval("UsuarioId") %>'>
                                <i class="fas fa-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="userName" HeaderText="User Name" SortExpression="userName"></asp:BoundField>
                        <asp:BoundField DataField="nombreCompleto" HeaderText="Nombre Completo" SortExpression="nombreCompleto"></asp:BoundField>
                        <asp:CheckBoxField DataField="esAdmin" HeaderText="Es Admin" SortExpression="esAdmin"></asp:CheckBoxField>
                    </Columns>
                    <Columns>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="UsuarioObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaUsuario" TypeName="UsuarioDSTableAdapters.UsuarioTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card card-primary" runat="server" id="PanelUsuario" visible="false">
                <div class="card-header">
                    <h3 class="card-title">Registro de Usuarios</h3>
                </div>
                <div role="form">
                    <div class="card-body">
                        <div class="form-group">
                            <label for="UserNameTextBox">User Name</label>
                            <asp:TextBox runat="server" ID="UserNameTextBox" placeholder="UserName" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="ContrasenaTextBox">Contraseña</label>
                            <asp:TextBox runat="server" ID="ContrasenaTextBox" placeholder="Password" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="NombreCompletoTextBox">Nombre Completo</label>
                            <asp:TextBox runat="server" ID="NombreCompletoTextBox" placeholder="Nombre Completo" CssClass="form-control" ></asp:TextBox>
                        </div>

                        <div class="form-check">
                            <asp:CheckBox runat="server" ID="EsAdminCheckBox" Text="Es Administrador" CssClass="form-check-input" />
                        </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                        <asp:Button runat="server" ID="btnGuardarUsuario" Text="Guardar" OnClick="btnGuardarUsuario_Click" CssClass="btn btn-primary" />
                        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="UsuarioIdHiddenField"/>

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

