//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainReservation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fare
    {
        public int Serial_No { get; set; }
        public decimal Train_No { get; set; }
        public double First_AC { get; set; }
        public double SencodAC { get; set; }
        public double Sleeper { get; set; }
    
        public virtual Train_Details Train_Details { get; set; }
    }
}