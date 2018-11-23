using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VeiculoBO
/// </summary>
public class VeiculoBO
{
    public bool Gravar(Veiculo obj)
    {
        if (obj.Modelo != string.Empty && obj.Categoria != string.Empty )
        {
            int sucesso = new VeiculoDAO().Gravar(obj);
            if (sucesso != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public IList<Veiculo> ListaVeiculos()
    {
        return new VeiculoDAO().ListaVeiculos();
    }
    public Veiculo Buscar(int veiculoID)
    {
        return new VeiculoDAO().Buscar(veiculoID);
    }
    public void Excluir(int veiculoID)
    {
        new VeiculoDAO().Excluir(veiculoID);

    }
}