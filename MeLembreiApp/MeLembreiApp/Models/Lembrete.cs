using SQLite;
using System;

namespace MeLembreiApp.Models
{
    public class Lembrete
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), NotNull]
        public string Titulo { get; set; }

        [MaxLength(255)]
        public string Detalhes { get; set; }

        [NotNull]
        public DateTime DataLimite { get; set; }

        [Ignore]
        public string DataFormatada { get
            {
                return DataLimite.ToString("dd/MM/yyyy");
            }
        }

        [NotNull]
        public bool Concluido { get; set; }
    }
}
