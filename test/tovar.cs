//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    using System;
    using System.Collections.Generic;
    
    public partial class tovar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tovar()
        {
            this.order = new HashSet<order>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public int kolvo { get; set; }
        public int price { get; set; }
        public Nullable<int> idcategory { get; set; }
        public int idpostavshik { get; set; }
        public string edizmer { get; set; }
        public string dopinfo { get; set; }
        public string photo { get; set; }
    
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }
        public virtual postavshiki postavshiki { get; set; }
    }
}
