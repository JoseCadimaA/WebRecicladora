using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FacturaBLL
/// </summary>
[System.ComponentModel.DataObject]
public class FacturaBLL
{
    private static Factura FillReccord(FacturaDS.FacturaRow row)
    {
        Factura obj = new Factura()
        {
            FacturaId = row.facturaId, 
            ClienteId = row.IsclienteIdNull() ? 0 : row.clienteId, 
            NombreCliente = row.IsnombreClienteNull() ? "" : row.nombreCliente, 
            UsuarioId = row.usuarioId, 
            NombreUsuario = row.nombreUsuario, 
            Descripcion = row.descripcion, 
            FechaRegistro = row.fechaRegistro, 
            SubTotal = row.subTotal, 
            EsVenta = row.esVenta
        };

        return obj;
    }

    public static List<Factura> GetListaFacturaCompra()
    {
        List<Factura> theList = new List<Factura>();
        Factura theData = null;

        try
        {
            FacturaDSTableAdapters.FacturaTableAdapter localAdapter = new FacturaDSTableAdapters.FacturaTableAdapter();
            FacturaDS.FacturaDataTable table = localAdapter.GetListaFacturas(false);

            if (table != null && table.Rows.Count > 0)
            {
                foreach (var row in table)
                {
                    theData = FillReccord(row);
                    theList.Add(theData);
                }
            }
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theList;
    }

    public static List<Factura> GetListaFacturaVenta()
    {
        List<Factura> theList = new List<Factura>();
        Factura theData = null;

        try
        {
            FacturaDSTableAdapters.FacturaTableAdapter localAdapter = new FacturaDSTableAdapters.FacturaTableAdapter();
            FacturaDS.FacturaDataTable table = localAdapter.GetListaFacturas(true);

            if (table != null && table.Rows.Count > 0)
            {
                foreach (var row in table)
                {
                    theData = FillReccord(row);
                    theList.Add(theData);
                }
            }
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theList;
    }

    public static Factura GetFacturaById(int FacturaId)
    {
        Factura theData = null;

        try
        {
            FacturaDSTableAdapters.FacturaTableAdapter localAdapter = new FacturaDSTableAdapters.FacturaTableAdapter();
            FacturaDS.FacturaDataTable table = localAdapter.GetFacturaById(FacturaId);

            if (table != null && table.Rows.Count > 0)
            {
                FacturaDS.FacturaRow row = table[0];
                theData = FillReccord(row);
            }

        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theData;
    }

    public static void DeleteFactura(int FacturaId)
    {
        try
        {
            FacturaDSTableAdapters.FacturaTableAdapter localAdapter = new FacturaDSTableAdapters.FacturaTableAdapter();
            localAdapter.DeleteFactura(FacturaId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static int InsertFactura(Factura theData)
    {
        int? FacturaId = 0;
        try
        {           
            FacturaDSTableAdapters.FacturaTableAdapter localAdapter = new FacturaDSTableAdapters.FacturaTableAdapter();
            localAdapter.InsertFactura(theData.ClienteId, theData.UsuarioId, theData.Descripcion, theData.EsVenta, ref FacturaId); 

            if (FacturaId.Value <= 0)
            {
                throw new ArgumentException("Error al registrar Factura.");
            }
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return FacturaId.Value;
    }    
}