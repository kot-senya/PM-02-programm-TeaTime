//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeaTime
{
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        public int idRecord { get; set; }
        public int idEvent { get; set; }
        public int idMember { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Member Member { get; set; }
    }
}
