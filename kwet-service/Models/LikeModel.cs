using System;
using System.ComponentModel.DataAnnotations;

namespace kwet_service.Models
{
    public class LikeModel
    {
        [Required] public string Username { get; set; }
        [Required] public Guid UserId { get; set; }
    }
}