//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfrastructureService.Repository.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMSMessage
    {
        public System.Guid RowID { get; set; }
        public System.Guid AppID { get; set; }
        public string ReceiveMobile { get; set; }
        public string SendMessage { get; set; }
        public string ServiceReturn { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
        public Nullable<System.DateTime> ExpiredDate { get; set; }
        public int Status { get; set; }
    
        public virtual AppInfo AppInfo { get; set; }
    }
}