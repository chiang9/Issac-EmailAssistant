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
    using System.ComponentModel.DataAnnotations;
    public partial class PersonalTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonalTemplate()
        {
            this.SubjectQuestion1 = new HashSet<SubjectQuestion1>();
            this.TemplateQuestions = new HashSet<TemplateQuestion1>();
        }
    
        public int PTemplateID { get; set; }
        public string Context { get; set; }
        [Required]
        public string TemplateDescription { get; set; }
        public Nullable<int> UserID { get; set; }
        [Required]
        public string SubjectContent { get; set; }
        [Required]
        public string TemplateTitle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectQuestion1> SubjectQuestion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemplateQuestion1> TemplateQuestions { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
