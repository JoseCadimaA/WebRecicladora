﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaVentas.aspx.cs" Inherits="ListaVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="text-center">Listado de Ventas Facturadas</h2>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:LinkButton runat="server" ID="btnAddNuevo" OnClick="btnAddNuevo_Click" Style="margin-right: 15px">Nueva Venta</asp:LinkButton>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="GridVenta" runat="server"
                    OnRowCommand="GridVenta_RowCommand"
                    AutoGenerateColumns="false"
                    CssClass="table"
                    GridLines="None" DataSourceID="FacturaObjectDataSource">
                    <Columns>
                        <asp:TemplateField HeaderText="Ver">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server"
                                    CommandName="Ver"
                                    CommandArgument='<%# Eval("FacturaId") %>'>
                                <i class="fas fa-eye"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton" runat="server"
                                    CommandName="Eliminar"
                                    OnClientClick="return confirm('Esta seguro que desea Eliminar la factura?')"
                                    CommandArgument='<%# Eval("FacturaId") %>'>
                                <i class="fas fa-ban"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                                                                       
                        <asp:BoundField DataField="NombreCliente" HeaderText="NombreCliente" SortExpression="NombreCliente"></asp:BoundField>                        
                        <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" SortExpression="NombreUsuario"></asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"></asp:BoundField>
                        <asp:BoundField DataField="FechaRegistro" HeaderText="FechaRegistro" SortExpression="FechaRegistro"></asp:BoundField>
                        <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" SortExpression="SubTotal"></asp:BoundField>                        
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="FacturaObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListaFacturaVenta" TypeName="FacturaBLL"></asp:ObjectDataSource>
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

