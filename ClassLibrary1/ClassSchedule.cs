//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassSchedule()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
        }
    
        public int Class_Schedule_Id { get; set; }
        public Nullable<int> Professor_Id { get; set; }
        public Nullable<int> Course_Id { get; set; }
        public string Room { get; set; }
        public System.TimeSpan From_Time { get; set; }
        public System.TimeSpan To_Time { get; set; }
        public string Days { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Professor Professor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
