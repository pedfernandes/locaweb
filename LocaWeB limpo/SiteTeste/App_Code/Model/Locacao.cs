using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Locacao
/// </summary>
public class Locacao
    
{
    
    public int CodLocacao { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataEntrega { get; set; }

    public double TotalCusto { get; set; }

    public Cliente ObjCliente { get; set; }

    public Veiculo ObjVeiculo { get; set; }



}