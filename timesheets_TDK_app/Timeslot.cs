//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace timesheets_TDK_app
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timeslot
    {
        public int TimeslotId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public double HoursCaptured { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
