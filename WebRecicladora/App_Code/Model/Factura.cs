using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Factura
/// </summary>
public class Factura
{
    public int FacturaId { get; set; }
    public int ClienteId { get; set; }
    public string NombreCliente { get; set; }    
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaRegistro { get; set; }
    public decimal SubTotal { get; set; }
    public bool EsVenta { get; set; }
    public bool Anulada { get; set; }
    public int UsuarioAnulacionId { get; set; }
    public string NombreUsuarioAulacion { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public Factura()
    {        
    }

}