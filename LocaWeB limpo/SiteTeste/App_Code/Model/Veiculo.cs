using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Veiculo
/// </summary>
public class Veiculo
{
    public int VeiculoID { get; set; }

    public string Modelo { get; set; }

    public string Descricao { get; set; }

    public DateTime AnoFabricacao { get; set; }

    public int Km { get; set; }

    public double PrecoDiaria { get; set; }

    public string Categoria { get; set; }

    public string Status { get; set; }


}