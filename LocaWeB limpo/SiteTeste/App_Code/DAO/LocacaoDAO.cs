using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for ClienteDAO
/// </summary>
public class LocacaoDAO
{
    Database banco = Database.Open("ConexaoBanco");
    public int Gravar(Locacao obj)
    {
        int sucesso;
        if (obj.CodLocacao == 0)
        {
            var sql = "Insert Into Cliente(dataInicio, dataEntrega, totalCusto, clienteID, veiculoID)values(@0,@1,@2,@3,@4)";
            sucesso = banco.Execute(sql, obj.DataInicio, obj.DataEntrega, obj.TotalCusto, obj.ObjCliente.ClienteID, obj.ObjVeiculo.VeiculoID);
        }
        else
        {
            var sql = "Update Locacao Set dataInicio=@0, dataEntrega=@1, totalCusto=@2, clienteID=@3, veiculoID@4,  Where codLocacao=@5";
            sucesso = banco.Execute(sql, obj.DataInicio, obj.DataEntrega, obj.TotalCusto, obj.ObjCliente.ClienteID, obj.ObjVeiculo.VeiculoID, obj.CodLocacao);
        }

        banco.Close();
        return sucesso;
    }


    public IList<Locacao> ListaLocacoes()
    {
        IList<Locacao> lista = new List<Locacao>();
        var sql = "Select * From Locacao";
        var resultado = banco.Query(sql);
        if (resultado.Count() > 0)
        {
            Locacao objLocacao;
            foreach (var item in resultado)
            {
                objLocacao = new Locacao

                {
                    CodLocacao = item.codLocacao,
                    DataInicio = item.dataInicio,
                    DataEntrega = item.dataEntrega,
                    TotalCusto = Convert.ToDouble(item.totalCusto),
                    ObjCliente = new ClienteDAO().Buscar((int) item.clienteID),
                    ObjVeiculo = new VeiculoDAO().Buscar((int) item.veiculoID)
                    
                    
                };
                lista.Add(objLocacao);
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

    public Locacao Buscar(int codLocacao)
    {
        var sql = "Select * From Locacao Where codLocacao = @0";
        var resultado = banco.QuerySingle(sql, codLocacao);
        Locacao objLocacao = new Locacao
        {
            CodLocacao = resultado.codLocacao,
            DataInicio = resultado.dataInicio,
            DataEntrega = resultado.dataEntrega,
            TotalCusto = Convert.ToDouble(resultado.totalCusto),
            ObjCliente = resultado.clienteID,
            ObjVeiculo = resultado.veiculoID
        };
        banco.Close();
        return objLocacao;
    }
    public void Excluir(int codLocacao)
    {
        var sql = "Delete from Locacao where codLocacao=@0";
        banco.Execute(sql, codLocacao);
        banco.Close();
    }


}