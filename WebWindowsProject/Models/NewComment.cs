using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebWindowsProject.Models
{
    public class NewComment
    {
        [Required]
        public string Title { get; set; }
    }
}
