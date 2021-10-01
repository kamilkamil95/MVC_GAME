using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Models
{
    public class MonsterVM
    {
       public MonsterModel Monster { get; set; }
       public IEnumerable<SelectListItem> MonsterTypeSelectList { get; set; }
       public IEnumerable<SelectListItem> MapSelectList { get; set; }
        

    }
}
