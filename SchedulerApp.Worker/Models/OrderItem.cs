using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Models;
public class OrderItem
{
    public Guid ID { get; set; }
    public Guid OrderID { get; set; }
    public int SeqNo { get; set; }
    public int ItmSeqNo { get; set; }
    public Guid ItemID { get; set; }
    public Guid KitID { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription1 { get; set; }
    public string ItemDescriptionExtended { get; set; }
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal GrossAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public decimal QtyPicked { get; set; }
    public decimal QtyInvoiced { get; set; }
    public decimal QtyShipped { get; set; }
    public decimal QtyCancelled { get; set; }
    public decimal QtyReturned { get; set; }
    public decimal InstallTime { get; set; }
    public string UOMCode { get; set; }
    public string CustomField1 { get; set; }
    public string CustomField2 { get; set; }
    public string CustomField3 { get; set; }
    public string IsBulkQty { get; set; }
    public int StatusCode { get; set; }
    public string Remark { get; set; }
    public Guid OrgID { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid LastUpdatedBy { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public bool HasPackage { get; set; }
    public string ItemTypeCode { get; set; }
    public Guid TaxID { get; set; }
    public decimal TaxRate { get; set; }
    public string DiscountTypeCode { get; set; }
    public decimal DiscountRate { get; set; }
    public decimal CostPrice { get; set; }
    public string Comment { get; set; }
    public decimal UnitPriceAfterDiscount { get; set; }
    public decimal RetailPrice { get; set; }
    public Guid ConfigDiscountID { get; set; }
    public string DiscountCode { get; set; }
    public bool IsSerial { get; set; }
    public decimal Amount { get; set; }
    public bool AllowDiscount { get; set; }
    public Guid RefOrderItemID { get; set; }
}
