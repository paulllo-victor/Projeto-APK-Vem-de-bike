using SQLite;

namespace Aplicativo.Models
{
    [Table("ModelGrupo")]
    public class ModelGrupo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string nome { get; set; }
        [NotNull]
        public string horarioSaida { get; set; }
        [NotNull]
        public string localSaida { get; set; }
        [NotNull]
        public string descricaoGrupo { get; set; }

        public int idUsuario { get; set; }
        public bool participantes { get; set; }

        public ModelGrupo()
        {
            this.nome = "";
            this.horarioSaida = "";
            this.localSaida = "";
            this.descricaoGrupo = "";
            this.participantes = false;

        }
    }
}
