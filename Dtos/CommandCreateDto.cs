using System.ComponentModel.DataAnnotations;
using Micro.CommandsService.Models;

namespace Micro.CommandsService.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}