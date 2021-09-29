using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Models
{
    public class MonsterTypeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Display Order for Monster Name must be grater than 0")]    
        public int DisplayOrder { get; set; }

    }
}
