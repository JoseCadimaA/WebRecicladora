using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlmacenBLL
/// </summary>
[System.ComponentModel.DataObject]
public class AlmacenBLL
{
    private static Almacen FillReccord(AlmacenDS.AlmacenRow row)
    {
        Almacen obj = new Almacen()
        {
            AlmacenId = row.almacenId, 
            Descripcion = row.descripcion, 
            CapacidadKG = row.capacidadKG, 
            ProductoId = row.IsproductoIdNull() ? 0 : row.productoId, 
            Producto = row.IsnombreProductoNull () ? "" : row.nombreProducto,
            RestanteKG = row.IsrestanteKGNull() ? 0 : row.restanteKG
        };

        return obj;
    }

    public static List<Almacen> GetListaAlmacen()
    {
        List<Almacen> theList = new List<Almacen>();
        Almacen theData = null;

        try
        {
            AlmacenDSTableAdapters.AlmacenTableAdapter localAdapter = new AlmacenDSTableAdapters.AlmacenTableAdapter();
            AlmacenDS.AlmacenDataTable table = localAdapter.GetListaAlmacen();

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

    public static Almacen GetAlmacenById(int AlmacenId)
    {
        Almacen theData = null;

        try
        {
            AlmacenDSTableAdapters.AlmacenTableAdapter localAdapter = new AlmacenDSTableAdapters.AlmacenTableAdapter();
            AlmacenDS.AlmacenDataTable table = localAdapter.GetAlmacenById(AlmacenId);

            if (table != null && table.Rows.Count > 0)
            {
                AlmacenDS.AlmacenRow row = table[0];
                theData = FillReccord(row);
            }

        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theData;
    }

    public static void DeleteAlmacen(int AlmacenId)
    {
        try
        {
            AlmacenDSTableAdapters.AlmacenTableAdapter localAdapter = new AlmacenDSTableAdapters.AlmacenTableAdapter();
            localAdapter.DeleteAlmacen(AlmacenId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void InsertAlmacen(Almacen theData)
    {
        try
        {
            int? almacenId = 0;

            AlmacenDSTableAdapters.AlmacenTableAdapter localAdapter = new AlmacenDSTableAdapters.AlmacenTableAdapter();
            localAdapter.InsertAlmacen(theData.Descripcion, theData.CapacidadKG, theData.ProductoId, ref almacenId);

            if (almacenId.Value <= 0)
            {
                throw new ArgumentException("Error al registrar Almacen.");
            }
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void UpdateAlmacen(Almacen theData)
    {
        try
        {
            AlmacenDSTableAdapters.AlmacenTableAdapter localAdapter = new AlmacenDSTableAdapters.AlmacenTableAdapter();
            localAdapter.UpdateAlmacen(theData.Descripcion, theData.CapacidadKG, theData.RestanteKG, theData.ProductoId, theData.AlmacenId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }
}