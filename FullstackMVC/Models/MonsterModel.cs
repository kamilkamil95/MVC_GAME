using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Models
{
    public class MonsterModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Hp { get; set; }
        public int DmgMin { get; set; }
        public int DmgMax { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }

        [Display(Name="Monster Type")]
        public int MonsterModelId { get; set; }
        [ForeignKey("MonsterModelId")]
        public virtual MonsterTypeModel MonsterTypeModel { get; set; }

        [Display(Name = "Map")]
        public int MapModelId { get; set; }
        [ForeignKey("MapModelId")]
        public virtual MapModel MapModel { get; set; }
    }
}
