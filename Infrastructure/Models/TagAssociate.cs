using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class TagAssociate
    {
        [Key]
        public int TagAssociateId { get; set; }
        [Required]
        public int TagId{ get; set; }
        [ForeignKey("TagId")]
        public Tag? Tag { get; set; }

        
        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
        public Topic? Topic { get; set; }

    }
}
