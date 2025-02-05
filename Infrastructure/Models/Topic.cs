using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Topic
    {
        [Key] public int TopicId { get; set; }
        [Required] public string? Title { get; set; }
        [Required] public string? Description { get; set; }
        public string AuthorUserId { get; set; }
        [ForeignKey("AuthorUserId")]
        public ForumUser? user { get; set; } 




    }
}
