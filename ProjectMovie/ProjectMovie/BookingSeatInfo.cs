//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectMovie
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingSeatInfo
    {
        public BookingSeatInfo()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int Bookseat_id { get; set; }
        public int Bk_SeatNo { get; set; }
        public string Bk_SeatName { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}