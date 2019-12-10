using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
    public int UsuarioId { get; set; }
    public string UserName { get; set; }
    public string contrasena { get; set; }
    public string NombreCompleto { get; set; }
    public bool EsAdmin { get; set; }

    
    public Usuario()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}