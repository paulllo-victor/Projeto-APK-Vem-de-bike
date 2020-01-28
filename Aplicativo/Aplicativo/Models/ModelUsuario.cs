using SQLite;
using System;

namespace Aplicativo.Models
{
    [Table("ModelUsuario")]
    public class ModelUsuario
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public String login { get; set; }
        [NotNull]
        public String senha { get; set; }

        public ModelUsuario()
        {
            this.id = 0;
            this.login = "";
            this.senha = "";
        }

    }
}
