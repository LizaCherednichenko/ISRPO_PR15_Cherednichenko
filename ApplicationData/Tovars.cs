//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISRPO_PR15_Cherednichenko.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tovars
    {
        public int idTovar { get; set; }
        public string nameTovar { get; set; }
        public string type { get; set; }
        public int idColour { get; set; }
        public int idMather { get; set; }
        public decimal cena { get; set; }
        public string opisanie { get; set; }
    
        public virtual Colour Colour { get; set; }
        public virtual Matherial Matherial { get; set; }
    }
}