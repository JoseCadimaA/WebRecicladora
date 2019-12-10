using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Almacen
/// </summary>
public class Almacen
{
    public int AlmacenId { get; set; }
    public string Descripcion { get; set; }
    public decimal CapacidadKG { get; set; }
    public int ProductoId { get; set; }
    public string Producto { get; set; }
    public decimal RestanteKG { get; set; }
    public Almacen()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string ProductoForDisplay
    {
        get
        {
            return string.IsNullOrEmpty(Producto) ? "-" : Producto;
        }
    }

    public string CapacidadForDisplay
    {
        get
        {
            return CapacidadKG + " Kg.";
        }
    }

    public string RestanteForDisplay
    {
        get
        {
            return RestanteKG + " Kg.";
        }
    }
}