using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderDA.Entities
{
   public class Command
   {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       [Required]
       public string HowTo { get; set; }
       [Required]
       public string CommandLine { get; set; }
       [Required]
       public int ToolId {get; set;}
       public Tool Tool {get; set;}
   }
}