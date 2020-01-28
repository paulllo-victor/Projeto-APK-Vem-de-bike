using Aplicativo.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Aplicativo.Services
{
    class ServicesBdParticipantes
    {
        SQLiteConnection conn;
        public string statusMessage { get; set; }
        public ServicesBdParticipantes(string bdpath)
        {
            if (bdpath == null) bdpath = App.DbPath;
            conn = new SQLiteConnection(bdpath); //define o banco 
            conn.CreateTable<ModelParticipantes>(); // cria o banco de dados da aplicacao
        }
        public void inserirParticipante(int idGrupo, string nome)
        {
            string conv = Convert.ToString(idGrupo);
            ModelParticipantes pa = new ModelParticipantes();
            pa.idGrupo = conv;
            pa.nomeUsuario = nome;
            conn.Insert(pa);
        }
        public List<ModelParticipantes> listarParticipantes(string id)
        {
            List<ModelParticipantes> listaParticipantes = new List<ModelParticipantes>();
            try
            {
                var resp = from po in conn.Table<ModelParticipantes>()
                           where po.idGrupo.ToLower().Contains(id.ToLower())
                           select po;
                listaParticipantes = resp.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("erro: {0}", e.Message));
            }
            return listaParticipantes;
        }
        public bool verificarUsuario(string nome, string id)
        {
            bool conf = false;
            var dados = conn.Table<ModelParticipantes>().Where(x => x.nomeUsuario == nome && x.idGrupo == id).FirstOrDefault();
            if (dados != null)
            {
                conf = true;
            }
            return conf;
        }
    }
}
