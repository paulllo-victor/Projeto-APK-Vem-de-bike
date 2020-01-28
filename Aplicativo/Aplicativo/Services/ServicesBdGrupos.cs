using Aplicativo.Models;
using SQLite;
using System;
using System.Collections.Generic;
namespace Aplicativo.Services
{
    public class ServicesBdGrupos
    {
        SQLiteConnection conn;
        public string statusMessageGrupo { get; set; }

        public ServicesBdGrupos(string bdpath)
        {
            if (bdpath == null) bdpath = App.DbPath;
            conn = new SQLiteConnection(bdpath); //define o banco 
            conn.CreateTable<ModelGrupo>();// cria o banco de dados da aplicacao          
        }
        public void inserirGrupo(ModelGrupo grupo, ModelUsuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(grupo.nome))
                    throw new Exception("Informe o nome do Grupo");
                if (string.IsNullOrEmpty(grupo.horarioSaida))
                    throw new Exception("Informe o horario de saída do grupo");
                if (string.IsNullOrEmpty(grupo.localSaida))
                    throw new Exception("Informe o local de saída do grupo");
                if (string.IsNullOrEmpty(grupo.descricaoGrupo))
                    throw new Exception("Informe a descricao do grupo");
                grupo.idUsuario = usuario.id;

                int result = conn.Insert(grupo);
                if (result != 0)
                {
                    this.statusMessageGrupo = string.Format("{0} registros adicionados: [Grupo: {1}]", result, grupo.nome);
                }
                else
                {
                    this.statusMessageGrupo = string.Format("0 registros adicionados: dados estão faltando!! Verifique o cadastro novamente!!");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public List<ModelGrupo> listarGrupos()
        {
            List<ModelGrupo> listaGrupos = new List<ModelGrupo>();
            try
            {
                listaGrupos = conn.Table<ModelGrupo>().ToList();
                this.statusMessageGrupo = "Listagem dos Grupos";
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return listaGrupos;
        }
        public void AtualizarGrupo(ModelGrupo grupo)
        {
            try
            {
                if (string.IsNullOrEmpty(grupo.nome))
                    throw new Exception("Informe o nome do Grupo");
                if (string.IsNullOrEmpty(grupo.horarioSaida))
                    throw new Exception("Informe o horario de saída do grupo");
                if (string.IsNullOrEmpty(grupo.localSaida))
                    throw new Exception("Informe o local de saída do grupo");
                if (string.IsNullOrEmpty(grupo.descricaoGrupo))
                    throw new Exception("Informe a descricao do grupo");
                if (grupo.id <= 0)
                    throw new Exception("Id do grupo não informado");

                int result = conn.Update(grupo);
                this.statusMessageGrupo = string.Format("{0), registros Alterado", result);

            }
            catch (Exception e)
            {
                // throw new Exception(string.Format("erro {0}", e.Message));
            }
        }
        public void ExcluirGrupo(int id)
        {
            try
            {
                int result = conn.Table<ModelGrupo>().Delete(x => x.id == id);
                this.statusMessageGrupo = string.Format("{0} grupo deletado", result);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("erro {0}", e.Message));
            }
        }
        public List<ModelGrupo> localizar(string nome)
        {
            List<ModelGrupo> lista = new List<ModelGrupo>();
            try
            {
                var resp = from p in conn.Table<ModelGrupo>()
                           where p.nome.ToLower().Contains(nome.ToLower())
                           select p;
                lista = resp.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(string.Format("erro: {0}", e.Message));
            }
            return lista;
        }
        public ModelGrupo getGrupo(int id)
        {
            ModelGrupo gp = new ModelGrupo();
            try
            {
                gp = conn.Table<ModelGrupo>().First(g => g.id == id);
                this.statusMessageGrupo = "Encontrou o grupo";
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("erro: {0} ", e.Message));
            }
            return gp;
        }
        public bool adicionarParticipantes(string nome, int id)
        {
            bool conf = false;
            string idGrupo = Convert.ToString(id);
            ServicesBdParticipantes bdParticipantes = new ServicesBdParticipantes(App.DbPath);
            if (!bdParticipantes.verificarUsuario(nome, idGrupo))
            {
                bdParticipantes.inserirParticipante(id, nome);
                conf = true;
            }

            return conf;

        }
        public List<ModelGrupo> localizarGrupoUsuario(ModelUsuario usuarioLogado)
        {
            List<ModelGrupo> listaGrupoCriadosPeloUsuario = new List<ModelGrupo>();

            try
            {
                var gruposUsuario = from p in conn.Table<ModelGrupo>()
                                    where p.id == usuarioLogado.id
                                    select p;
                listaGrupoCriadosPeloUsuario = gruposUsuario.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro: {0}", e.Message));
            }
            return listaGrupoCriadosPeloUsuario;
        }
    }
}
