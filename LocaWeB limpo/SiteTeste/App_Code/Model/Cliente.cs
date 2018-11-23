using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cliente
/// </summary>
public class Cliente
{

    public int ClienteID { get; set; }
    public string Nome { get; set; }

    public string Cpf { get; set; }

    public string Endereco { get; set; }

    public string Telefone { get; set; }

    public string Email { get; set; }

    public double DividaSaldo { get; set; }

    public Locacao ObjLocacao { get; set; }


}