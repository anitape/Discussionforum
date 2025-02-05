using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class PostTopic
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AuthorUserId { get; set; }
        
    }
}
