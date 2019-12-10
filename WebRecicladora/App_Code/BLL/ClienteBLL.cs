using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClienteBLL
/// </summary>
[System.ComponentModel.DataObject]
public class ClienteBLL
{
    private static Cliente FillReccord(ClienteDS.ClienteRow row)
    {
        Cliente obj = new Cliente()
        {
            ClienteId = row.clienteId,
            CI = row.IsciNull() ? "" : row.ci,
            NombreCompleto = row.nombreCompleto,
            EsVendedor = row.esVendedor
        };

        return obj;
    }

    public static List<Cliente> GetListaClientesTodos()
    {
        List<Cliente> theList = new List<Cliente>();
        Cliente theData = null;

        try
        {
            ClienteDSTableAdapters.ClienteTableAdapter localAdapter = new ClienteDSTableAdapters.ClienteTableAdapter();
            ClienteDS.ClienteDataTable table = localAdapter.GetListaClientes();

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

    public static List<Cliente> GetListaClientesCompradores()
    {
        List<Cliente> theList = new List<Cliente>();
        Cliente theData = null;

        try
        {
            ClienteDSTableAdapters.ClienteTableAdapter localAdapter = new ClienteDSTableAdapters.ClienteTableAdapter();
            ClienteDS.ClienteDataTable table = localAdapter.GetListaClientes();

            if (table != null && table.Rows.Count > 0)
            {
                foreach (var row in table)
                {
                    theData = FillReccord(row);
                    if (!theData.EsVendedor)
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

    public static List<Cliente> GetListaClientesVendedores()
    {
        List<Cliente> theList = new List<Cliente>();
        Cliente theData = null;

        try
        {
            ClienteDSTableAdapters.ClienteTableAdapter localAdapter = new ClienteDSTableAdapters.ClienteTableAdapter();
            ClienteDS.ClienteDataTable table = localAdapter.GetListaClientes();

            if (table != null && table.Rows.Count > 0)
            {
                foreach (var row in table)
                {
                    theData = FillReccord(row);
                    if (theData.EsVendedor)
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

    public static Cliente GetClienteById(int ClienteId)
    {
        Cliente theData = null;

        try
        {
            ClienteDSTableAdapters.ClienteTableAdapter localAdapter = new ClienteDSTableAdapters.ClienteTableAdapter();
            ClienteDS.ClienteDataTable table = localAdapter.GetClienteById(ClienteId);

            if (table != null && table.Rows.Count > 0)
            {
                ClienteDS.ClienteRow row = table[0];
                theData = FillReccord(row);
            }

        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theData;
    }

    public static void DeleteCliente(int ClienteId)
    {
        try
        {
            ClienteDSTableAdapters.ClienteTableAdapter localAdapter = new ClienteDSTableAdapters.ClienteTableAdapter();
            localAdapter.DeleteCliente(ClienteId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void InsertCliente(Cliente theData)
    {
        try
        {
            int? clienteId = 0;

            ClienteDSTableAdapters.ClienteTableAdapter localAdapter = new ClienteDSTableAdapters.ClienteTableAdapter();
            localAdapter.InsertCliente(theData.CI, theData.NombreCompleto, theData.EsVendedor, ref clienteId);

            if (clienteId.Value <= 0)
            {
                throw new ArgumentException("Error al registrar Cliente.");
            }
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void UpdateCliente(Cliente theData)
    {
        try
        {
            ClienteDSTableAdapters.ClienteTableAdapter localAdapter = new ClienteDSTableAdapters.ClienteTableAdapter();
            localAdapter.UpdateCliente(theData.CI, theData.NombreCompleto, theData.EsVendedor, theData.ClienteId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }
}