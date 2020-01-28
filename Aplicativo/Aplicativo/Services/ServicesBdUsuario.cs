using Aplicativo.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Aplicativo.Services
{
    public class ServicesBdUsuario
    {
        SQLiteConnection conn;
        public string statusMessage { get; set; }
        public ServicesBdUsuario(string bdpath)
        {
            if (bdpath == null) bdpath = App.DbPath;
            conn = new SQLiteConnection(bdpath); //define o banco 
            conn.CreateTable<ModelUsuario>(); // cria o banco de dados da aplicacao
        }

        public void InserirUsuario(ModelUsuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.login))
                    throw new Exception("Login do usuario não informado");
                if (string.IsNullOrEmpty(usuario.senha))
                    throw new Exception("Senha do usuario não informado");

                int result = conn.Insert(usuario);
                if (result != 0)
                {
                    this.statusMessage = string.Format("{0} registros adicionados: [Usuario: {1}]", result, usuario.login);
                }
                else
                {
                    this.statusMessage = string.Format("0 registros adicionados: informe o login e senha do usuario");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<ModelUsuario> listarUsuario()
        {
            List<ModelUsuario> lista = new List<ModelUsuario>();
            try
            {
                lista = conn.Table<ModelUsuario>().ToList();
                this.statusMessage = "Listagens dos usuarios";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public ModelUsuario wrere(string loginUsuario, string senhaUsuario)
        {
            bool conf = false;
            var dados = conn.Table<ModelUsuario>().Where(x => x.login == loginUsuario && x.senha == senhaUsuario).FirstOrDefault();
            if (dados != null)
            {
                conf = true;
            }
            return dados;
        }
        public void Atualizar(ModelUsuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.login))
                    throw new Exception("Login do usuario não informado");
                if (string.IsNullOrEmpty(usuario.senha))
                    throw new Exception("Senha do usuario não informado");
                if (usuario.id <= 0)
                    throw new Exception("Id do usuario não informado");

                int result = conn.Update(usuario);
                this.statusMessage = string.Format("{0), registros Alterado", result);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("erro {0}", e.Message));
            }
        }
        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelUsuario>().Delete(x => x.id == id); //expressão logica!!                
                this.statusMessage = string.Format("{0), registros deletado", result);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("erro {0}", e.Message));
            }
        }
    }
}
