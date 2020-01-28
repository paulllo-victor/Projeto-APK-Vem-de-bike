using SQLite;

namespace Aplicativo.Models
{
    [Table("ModelParticipantes")]
    class ModelParticipantes
    {
        [NotNull]
        public string idGrupo { get; set; }

        [NotNull]
        public string nomeUsuario { get; set; }
        public ModelParticipantes()
        {

            this.nomeUsuario = "";
        }
    }
}
