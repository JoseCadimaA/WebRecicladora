using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FacturaDetalle
/// </summary>
public class FacturaDetalle
{
    public int DetalleId { get; set; }
    public int FacturaId { get; set; }
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; }
    public decimal PesoKG { get; set; }
    public decimal Monto { get; set; }
    public FacturaDetalle()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}