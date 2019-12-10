using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Producto
/// </summary>
public class Producto
{
    public int ProductoId { get; set; }
    public string Descripcion { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }

    public Producto()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}