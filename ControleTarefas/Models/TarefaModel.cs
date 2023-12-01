using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTarefas.Models
{
    [Table("Tarefas")]
    public class TarefasModel
    {

        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tarefa { get; set; } = string.Empty;
        public int StatusTarefa { get; set; } = 0;
    }
}
