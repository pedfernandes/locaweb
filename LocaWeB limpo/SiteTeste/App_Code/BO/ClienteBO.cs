using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClienteBO
/// </summary>
public class ClienteBO
{
    public bool Gravar(Cliente obj)
    {
        if (obj.Nome != string.Empty && obj.Cpf != string.Empty)
        {
            int sucesso = new ClienteDAO().Gravar(obj);
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
    public IList<Cliente> ListaClientes()
    {
        return new ClienteDAO().ListaClientes();
    }
    public Cliente Buscar(int clienteID)
    {
        return new ClienteDAO().Buscar(clienteID);
    }
    public void Excluir(int clienteID)
    {
        new ClienteDAO().Excluir(clienteID);  

    }
}