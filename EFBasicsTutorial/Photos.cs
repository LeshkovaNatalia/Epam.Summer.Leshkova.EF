//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFBasicsTutorial
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photos
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ThumbPath { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    
        public virtual CategoryPhotoes CategoryPhotoes { get; set; }
        public virtual Users Users { get; set; }
    }
}
