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
    
    public partial class TimetableForAnimal
    {
        public int ID { get; set; }
        public Nullable<int> ID_Animal { get; set; }
        public string Description { get; set; }
        public Nullable<int> ID_Status { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Time { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Status Status { get; set; }
    }
}
