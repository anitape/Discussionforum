using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]public int TopicId { get; set; }
		//[ForeignKey("TopicId")]
        //ANITA used this ForeignKey bcs of ERROR
		[ForeignKey("TopicIdForReply")]

        public Topic? Topic { get; set; }
        [Required] public string? Content { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        [Required] public DateTime UpdatedOn { get; set; }
        [Required] public string ReplyUserId { get; set; }
        [ForeignKey("ReplyUserId")]
        public ForumUser? User { get; set; }
    }
}
