using System;
using System.ComponentModel.DataAnnotations;

namespace kwet_service.Models
{
    public class KweetModel
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Content { get; set; }

        [Required] public string Username { get; set; }
        [Required] public Guid UserId { get; set; }
    }
}