//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Isaac.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TemplateQuestion1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TemplateQuestion1()
        {
            this.PersonalTemplates = new HashSet<PersonalTemplate>();
        }
    
        public int PQuestionID { get; set; }
        public string PQuestionContent { get; set; }
        public Nullable<int> UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalTemplate> PersonalTemplates { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
