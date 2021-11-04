using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderData.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Tool : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Command> Commands {get; set;} = new List<Command>();
    }
}