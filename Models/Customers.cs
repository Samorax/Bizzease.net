using System;
using System.Collections.Generic;

namespace WebApplication_Webease_.Models
{

    public class Customer
    {
        public int CustomersId { get; set; }
        public string Name { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public double TotalChargedAmount { get; set; }
        public double TotalPaidAmount { get; set; }
        public double TotalOwedAmount { get; set; }
        public serviceTypes? Subscription { get; set; }
    }

    public class Service
    {
        public int ServicesId { get; set; }
        public serviceTypes? Type { get; set; }
        public string ProjectName { get; set; }
        public string  Description { get; set; }
        public IEnumerable<Invoice> Invoice { get; set; }
        public double AmountOwed { get; set; }
        public double AmountCharged { get; set; }
        public double AmountPaid { get; set; }
        public virtual Customer CustomersId { get; set; }
    }

    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoicedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Service ServiceDescription { get; set; }
        public Service ServiceAmount { get; set; }
        public InvoiceStatus? Status { get; set; }
        public virtual Customer CustomersId { get; set; }
        public virtual Service ServicesId { get; set; }
    }

    public enum serviceTypes
    {
        MobileDevelopment,
        Webdevelopment,
        BookkeepingAndAccounting,
        BusinessConsulting

    }

    public enum InvoiceStatus
    {
        cleared,uncleared
    }
        
}
