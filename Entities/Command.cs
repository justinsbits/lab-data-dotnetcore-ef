using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderData.Entities
{
   public class Command : BaseEntity
    {
       [Required]
       public string HowTo { get; set; }
       [Required]
       public string CommandLine { get; set; }
       [Required]
       public int ToolId {get; set;}
       public Tool Tool {get; set;}
   }
}