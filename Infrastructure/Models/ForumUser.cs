using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ForumUser: IdentityUser
    {


        [Required]
        [DisplayName("Screen Name")]
        public string? ScreenName { get; set; }
        [Required]
        [DisplayName("Created on")]
        public DateTime CreatedDate { get; set; }


    }
}
