using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FacturaDetalleBLL
/// </summary>
public class FacturaDetalleBLL
{
    private static FacturaDetalle FillRecord(FacturaDetalleDS.FacturaDetalleRow row)
    {
        FacturaDetalle theData = new FacturaDetalle()
        {
            DetalleId = row.detalleId,
            FacturaId = row.facturaId,
            ProductoId = row.productoId,
            NombreProducto = row.nombreProducto,
            PesoKG = row.pesoKg,
            Monto = row.monto
        };

        return theData;
    }

    public static List<FacturaDetalle> GetListFacturaDetalle(int facturaID)
    {
        List<FacturaDetalle> theList = new List<FacturaDetalle>();
        FacturaDetalle theData = null;
        try
        {
            FacturaDetalleDSTableAdapters.FacturaDetalleTableAdapter localAdapter = new FacturaDetalleDSTableAdapters.FacturaDetalleTableAdapter();
            FacturaDetalleDS.FacturaDetalleDataTable table = localAdapter.GetFacturaDetalleByFactID(facturaID);

            if (table != null && table.Rows.Count > 0)
            {
                foreach (var row in table)
                {
                    theData = FillRecord(row);
                    theList.Add(theData);
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

        return theList;        
    }

    public static void DeleteFacturaDetalle(int detalleId)
    {
        try
        {
            FacturaDetalleDSTableAdapters.FacturaDetalleTableAdapter localAdapter = new FacturaDetalleDSTableAdapters.FacturaDetalleTableAdapter();
            localAdapter.DeleteFacturaDetalle(detalleId);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public static int InsertFacturaDetalle(FacturaDetalle theData)
    {
        int? detalleId = 0;
        try
        {
            FacturaDetalleDSTableAdapters.FacturaDetalleTableAdapter localAdapter = new FacturaDetalleDSTableAdapters.FacturaDetalleTableAdapter();
            localAdapter.InsertFacturaDetalle(theData.FacturaId, theData.ProductoId, theData.PesoKG, theData.Monto, ref detalleId);
        }
        catch (Exception)
        {

            throw;
        }

        return detalleId.Value;
    }
}