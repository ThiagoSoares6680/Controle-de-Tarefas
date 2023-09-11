using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTarefas.Models;

namespace ControleTarefas.Data
{
    public class ControleTarefasContext : DbContext
    {
        public ControleTarefasContext (DbContextOptions<ControleTarefasContext> options)
            : base(options)
        {
        }

        public DbSet<ControleTarefas.Models.TarefasModel> TarefasModel { get; set; } = default!;
    }
}
