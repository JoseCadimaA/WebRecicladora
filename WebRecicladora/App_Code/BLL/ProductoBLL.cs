using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductoBLL
/// </summary>
public class ProductoBLL
{
    private static Producto FillReccord(ProductoDS.ProductoRow row)
    {
        Producto obj = new Producto()
        {
            ProductoId = row.productoId, 
            Descripcion = row.descripcion, 
            PrecioCompra = row.precioCompra, 
            PrecioVenta = row.precioVenta
        };

        return obj;
    }

    public static List<Producto> GetListaProducto()
    {
        List<Producto> theList = new List<Producto>();
        Producto theData = null;

        try
        {
            ProductoDSTableAdapters.ProductoTableAdapter localAdapter = new ProductoDSTableAdapters.ProductoTableAdapter();
            ProductoDS.ProductoDataTable table = localAdapter.GetListaProductos();

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

    public static Producto GetProductoById(int ProductoId)
    {
        Producto theData = null;

        try
        {
            ProductoDSTableAdapters.ProductoTableAdapter localAdapter = new ProductoDSTableAdapters.ProductoTableAdapter();
            ProductoDS.ProductoDataTable table = localAdapter.GetProductoById(ProductoId);

            if (table != null && table.Rows.Count > 0)
            {
                ProductoDS.ProductoRow row = table[0];
                theData = FillReccord(row);
            }

        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theData;
    }

    public static void DeleteProducto(int ProductoId)
    {
        try
        {
            ProductoDSTableAdapters.ProductoTableAdapter localAdapter = new ProductoDSTableAdapters.ProductoTableAdapter();
            localAdapter.DeleteProducto(ProductoId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void InsertProducto(Producto theData)
    {
        try
        {
            int? productoId = 0;

            ProductoDSTableAdapters.ProductoTableAdapter localAdapter = new ProductoDSTableAdapters.ProductoTableAdapter();
            localAdapter.InsertProducto(theData.Descripcion, theData.PrecioCompra, theData.PrecioVenta, ref productoId);

            if (productoId.Value <= 0)
            {
                throw new ArgumentException("Error al registrar Producto.");
            }
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void UpdateProducto(Producto theData)
    {
        try
        {
            ProductoDSTableAdapters.ProductoTableAdapter localAdapter = new ProductoDSTableAdapters.ProductoTableAdapter();
            localAdapter.UpdateProducto(theData.Descripcion, theData.PrecioCompra, theData.PrecioVenta, theData.ProductoId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }
}