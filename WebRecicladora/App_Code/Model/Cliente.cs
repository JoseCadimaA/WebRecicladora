using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cliente
/// </summary>
public class Cliente
{
    public int ClienteId { get; set; }
    public string CI { get; set; }
    public string NombreCompleto { get; set; }
    public bool EsVendedor { get; set; }
    public Cliente()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string EsVendedorForDsiplay
    {
        get
        {
            if (EsVendedor)
                return "Vendedor de Material";
            else
                return "Comprador de Material";
        }
    }
}