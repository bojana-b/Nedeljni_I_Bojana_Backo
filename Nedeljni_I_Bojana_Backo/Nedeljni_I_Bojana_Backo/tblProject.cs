//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni_I_Bojana_Backo
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProject
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ClientName { get; set; }
        public System.DateTime ContractDate { get; set; }
        public string ContractManager { get; set; }
        public System.DateTime ProjectStartDate { get; set; }
        public System.DateTime ProjectDeadline { get; set; }
        public int HourlyRate { get; set; }
        public string Realisation { get; set; }
        public int ManagerID { get; set; }
    
        public virtual tblManager tblManager { get; set; }
    }
}
