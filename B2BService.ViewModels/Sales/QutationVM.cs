using B2BService.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Sales
{
    public class QutationVM
    {
        public QuotationMaster QuotationMaster { get; set; }
        public List<QuotationDetails> QuotationDetails { get; set; }
    }

    public class QutationUserVM {
        public int QuotationId { get; set; }
        public int UserId { get; set; }
    }

    public class SupplierUserVM
    {
        public int SupplierId { get; set; }
        public int UserId { get; set; }
    }

    public class UpdatePOS
    {
        public int PoId { get; set; }
        public int status { get; set; }
    }


    public class QuotationMasterVM
    {
        public int Id { get; set; }
        public string QNumber { get; set; }
        public int CustomerName { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal Tax { get; set; }
        public decimal Additions { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetTotal { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public List<QuotationDetailsVM> Details { get; set; }
    }

    public class QuotationDetailsVM
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int SupplierName { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Additions { get; set; }
        public decimal Deductions { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
    }


    public class SupplierOrderHeaderVM 
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal Tax { get; set; }
        public decimal Additions { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetTotal { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        ///  1-Active
        ///  2-approved
        ///  3-ReadyToDeliver
        ///  4-IdDispaced
        ///  5-IsDeliveredToCus
        ///  6-Close(after CustomerConfirms)
        /// </summary>
        public bool Status { get; set; }
    }


    public class QuotationHistoryVM
    {
        public QuotationMasterVM QuotationMasterVM { get; set; }
        public int status { get; set; }
    }


    public class QuotationMasterVMForView
    {
        public int Id { get; set; }
        public string QNumber { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal Subtotal { get; set; }
        public decimal NetTotal { get; set; }
        public string Remarks { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        
    }


    public class QuotationDetailsVMForView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public DateTime DeliveryDate { get; set; }

    }

    public class QuotationWarrantyVMForView
    {
        public int Id { get; set; }
        public int WarrentyID { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Duration in months
        /// </summary>
        public int Duration { get; set; }
        public decimal PriceForadditionalYear { get; set; }

    }

    public class WarrantyChangeProfile
    {
        public int Id { get; set; }
        public int WarrentyID { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string UserId { get; set; }
    }



}
