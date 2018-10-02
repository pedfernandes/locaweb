using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;


/// <summary>
/// Summary description for ClienteDAO
/// </summary>
public class ClienteDAO
{
    Database banco = Database.Open("ConexaoBanco");
    public int Gravar(Cliente obj)
    {
        int sucesso;
        if (obj.ClienteID == 0)
        {
            var sql = "Insert Into Cliente(nome,cpf,endereco,telefone,email,dividaSaldo)values(@0,@1,@2,@3,@4,@5)";
            sucesso = banco.Execute(sql, obj.Nome, obj.Cpf,obj.Endereco,obj.Telefone, obj.Email,obj.DividaSaldo);

            

        }
        else
        {
            var sql = "Update Cliente Set nome=@0, cpf=@1, endereco=@2, telefone=@3, email=@4, dividaSaldo@5 Where clienteID=@6";
            sucesso = banco.Execute(sql, obj.Nome, obj.Cpf, obj.Endereco, obj.Telefone, obj.Email, obj.DividaSaldo, obj.ClienteID);
        }

        banco.Close();
        return sucesso;
    }


    public IList<Cliente> ListaClientes()
    {
        IList<Cliente> lista = new List<Cliente>();
        var sql = "Select * From Cliente";
        var resultado = banco.Query(sql);
        if (resultado.Count() > 0)
        {
            Cliente objCliente;
            foreach (var item in resultado)
            {
                objCliente = new Cliente
                {
                    ClienteID = item.clienteID,
                    Nome = item.nome,                    
                    Cpf = item.cpf,
                    Endereco = item.endereco,
                    Telefone = item.telefone,
                    Email = item.email,
                    DividaSaldo = Convert.ToDouble(item.dividaSaldo)
                };
                lista.Add(objCliente);
            }
            banco.Close();
        }
        else
        {
            banco.Close();
            return null;
        }
        return lista;
    }

    public Cliente Buscar(int clienteID)
    {
        var sql = "Select * From Cliente Where clienteID = @0";
        var resultado = banco.QuerySingle(sql, clienteID);
        Cliente objCliente = new Cliente
        {
            ClienteID = resultado.clienteID,
            Nome = resultado.nome,
            Cpf = resultado.cpf,
            Endereco = resultado.endereco,
            Telefone = resultado.telefone,
            Email = resultado.email,
            DividaSaldo = Convert.ToDouble(resultado.dividaSaldo)
        };
        banco.Close();
        return objCliente;
    }
    public void Excluir(int clienteID)
    {
        var sql = "Delete from Cliente where clienteID=@0";
        banco.Execute(sql, clienteID);
        banco.Close();
    }

    
}