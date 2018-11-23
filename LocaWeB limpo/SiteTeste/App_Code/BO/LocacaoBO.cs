using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VeiculoBO
/// </summary>
public class LocacaoBO
{
    public bool Gravar(Locacao obj)
    {
        if (obj.ObjCliente.Nome != string.Empty && obj.ObjCliente.Cpf != string.Empty)
        {
            int sucesso = new LocacaoDAO().Gravar(obj);
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
    public IList<Locacao> ListaLocacoes()
    {
        return new LocacaoDAO().ListaLocacoes();
    }
    public Locacao Buscar(int codLocacao)
    {
        return new LocacaoDAO().Buscar(codLocacao);
    }
    public void Excluir(int codLocacao)
    {
        new LocacaoDAO().Excluir(codLocacao);

    }
}