//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Circus.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Taskk
    {
        public int ID { get; set; }
        public Nullable<int> ID_ServiceStaff { get; set; }
        public string Description { get; set; }
        public Nullable<int> ID_Done { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    
        public virtual Worker Worker { get; set; }
        public virtual Status Status { get; set; }
    }
}
