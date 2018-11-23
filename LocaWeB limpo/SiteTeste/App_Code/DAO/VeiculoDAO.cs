using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for VeiculoDAO
/// </summary>
public class VeiculoDAO
{
    Database banco = Database.Open("ConexaoBanco");
    public int Gravar(Veiculo obj)
    {
        int sucesso;
        if (obj.VeiculoID == 0)
        {
            var sql = "Insert Into Veiculo(modelo, descricao, ano, km, precoDiaria, categoria, status)values(@0,@1,@2,@3,@4,@5,@6)";
            sucesso = banco.Execute(sql, obj.Modelo, obj.Descricao, obj.AnoFabricacao,obj.Km, obj.PrecoDiaria,obj.Categoria, obj.Status);
        }
        else
        {
            var sql = "Update Veiculo Set modelo=@0, descricao=@1, ano=@2, km=@3, precoDiaria=@4, categoria@5, status@6 Where VeiculoID=@7";
            sucesso = banco.Execute(sql, obj.Modelo, obj.Descricao, obj.AnoFabricacao, obj.Km, obj.PrecoDiaria, obj.Categoria, obj.Status, obj.VeiculoID);
        }

        banco.Close();
        return sucesso;
    }


    public IList<Veiculo> ListaVeiculos()
    {
        IList<Veiculo> lista = new List<Veiculo>();
        var sql = "Select * From Veiculo";
        var resultado = banco.Query(sql);
        if (resultado.Count() > 0)
        {
            Veiculo objVeiculo;
            foreach (var item in resultado)
            {
                objVeiculo = new Veiculo
                {
                    VeiculoID = item.veiculoID,
                    Modelo = item.modelo,
                    Descricao = item.descricao,
                    AnoFabricacao = item.ano,                   
                   
                    Categoria = item.categoria
                };
                lista.Add(objVeiculo);
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

    public Veiculo Buscar(int veiculoID)
    {
        var sql = "Select * From Veiculo Where veiculoID = @0";
        var resultado = banco.QuerySingle(sql, veiculoID);
        Veiculo objVeiculo = new Veiculo
        {
            VeiculoID = resultado.veiculoID,
            Modelo = resultado.modelo,
            Descricao = resultado.descricao,
            AnoFabricacao = resultado.ano,
            PrecoDiaria = Convert.ToDouble(resultado.precoDiaria),
            Categoria = resultado.categoria,
        };
        banco.Close();
        return objVeiculo;
    }
    public void Excluir(int VeiculoID)
    {
        var sql = "Delete from Veiculo where VeiculoID=@0";
        banco.Execute(sql, VeiculoID);
        banco.Close();
    }
}