using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Models
{
    public class ApplicationUserModel : IdentityUser
    {

        [Display(Name = "Character")]
        public int? CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual CharacterModel Character { get; set; } 


    }
}
