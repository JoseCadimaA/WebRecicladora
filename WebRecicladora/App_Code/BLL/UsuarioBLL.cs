using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuarioBLL
/// </summary>
public class UsuarioBLL
{
    private static Usuario FillReccord(UsuarioDS.UsuarioRow row )
    {
        Usuario obj = new Usuario() {
            UsuarioId = row.usuarioId, 
            UserName = row.userName, 
            contrasena = row.contrasena, 
            NombreCompleto = row.nombreCompleto,
            EsAdmin = row.esAdmin
        };

        return obj;
    }

    public static List<Usuario> GetListaUsuarios()
    {
        List<Usuario> theList = new List<Usuario>();
        Usuario theData = null;

        try
        {
            UsuarioDSTableAdapters.UsuarioTableAdapter localAdapter = new UsuarioDSTableAdapters.UsuarioTableAdapter();
            UsuarioDS.UsuarioDataTable table = localAdapter.GetListaUsuario();

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

    public static Usuario GetUsuarioById(int usuarioId)
    {        
        Usuario theData = null;

        try
        {
            UsuarioDSTableAdapters.UsuarioTableAdapter localAdapter = new UsuarioDSTableAdapters.UsuarioTableAdapter();
            UsuarioDS.UsuarioDataTable table = localAdapter.GetUsuarioById(usuarioId);

            if (table != null && table.Rows.Count > 0)
            {
                UsuarioDS.UsuarioRow row = table[0];
                theData = FillReccord(row);
            }
            
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theData;
    }

    public static Usuario GetUsuarioByUserName(string userName, string contrasena)
    {
        Usuario theData = null;

        try
        {
            UsuarioDSTableAdapters.UsuarioTableAdapter localAdapter = new UsuarioDSTableAdapters.UsuarioTableAdapter();
            UsuarioDS.UsuarioDataTable table = localAdapter.GetUsuarioByUserName(userName, contrasena);

            if (table != null && table.Rows.Count > 0)
            {
                UsuarioDS.UsuarioRow row = table[0];
                theData = FillReccord(row);
            }

        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }

        return theData;
    }

    public static void DeleteUsuario(int usuarioId)
    {
        try
        {
            UsuarioDSTableAdapters.UsuarioTableAdapter localAdapter = new UsuarioDSTableAdapters.UsuarioTableAdapter();
            localAdapter.DeleteUsuario(usuarioId);
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void InsertUsuario(Usuario theData)
    {
        try
        {
            int? usuarioId = 0;

            UsuarioDSTableAdapters.UsuarioTableAdapter localAdapter = new UsuarioDSTableAdapters.UsuarioTableAdapter();
            localAdapter.InsertUsuario(theData.UserName, theData.contrasena, theData.NombreCompleto, theData.EsAdmin, ref usuarioId);

            if (usuarioId.Value <= 0)
            {
                throw new ArgumentException("Error al registrar usuario.");
            }
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

    public static void UpdateUsuario(Usuario theData)
    {
        try
        {            
            UsuarioDSTableAdapters.UsuarioTableAdapter localAdapter = new UsuarioDSTableAdapters.UsuarioTableAdapter();
            localAdapter.UpdateUsuario(theData.UserName, theData.contrasena, theData.NombreCompleto, theData.EsAdmin, theData.UsuarioId);            
        }
        catch (Exception q)
        {
            throw new ArgumentException(q.Message, q);
        }
    }

}