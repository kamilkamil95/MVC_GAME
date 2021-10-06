using System.ComponentModel.DataAnnotations;

namespace FullstackMVC.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string AdditionalStrength { get; set; }
        public int AdditionalDmg{ get; set; }
        public int AdditionalHp { get; set; }    
    }

}
