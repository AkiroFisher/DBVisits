//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBVisits.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Корабли
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Корабли()
        {
            this.Посещения = new HashSet<Посещения>();
        }
    
        public int Код_корабля { get; set; }
        public string Название_корабля { get; set; }
        public int Водоизмещение { get; set; }
        public string Порт_приписки { get; set; }
        public string Капитан { get; set; }
        public string Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Посещения> Посещения { get; set; }
    }
}
