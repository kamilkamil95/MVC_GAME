using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Models
{
    public class CharacterModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CharacterName { get; set; }
        public string Image { get; set; }
        public string Job { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public int Dmg { get; set; }
        public int Level { get; set; }
        public int GoldenCoins { get; set; }
        public string AccountNameOwner { get; set; }
        public List<ItemModel> InventoryItemsId { get; set; }

      
    }

}
