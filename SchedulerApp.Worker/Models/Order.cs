using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Models;
public class Order
{
    public Guid ID { get; set; }
    public Guid LocationID { get; set; }
    public Guid EstablishmentID { get; set; }
    public Guid BillToEstablishmentID { get; set; }
    public string OrderNo { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderTypeCode { get; set; }
    public DateTime ExpDelDate { get; set; }
    public string ShipViaCode { get; set; }
    public string PaymentTermCode { get; set; }
    public string CustomerPONo { get; set; }
    public string CustomerPONoOri { get; set; }
    public bool AllowBackOrder { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal FreightCharges { get; set; }
    public decimal AddCharges { get; set; }
    public decimal NetAmount { get; set; }
    public decimal BalanceToCollect { get; set; }
    public string FOB { get; set; }
    public string SRFNo { get; set; }
    public string CustName { get; set; }
    public string CustAddrLine1 { get; set; }
    public string CustAddrLine2 { get; set; }
    public string CustAddrLine3 { get; set; }
    public string CustAddrPostalCode { get; set; }
    public string CustAddrCountryCode { get; set; }
    public string CustContactPerson { get; set; }
    public string CustContactNo { get; set; }
    public string CustEmail { get; set; }
    public string ShipTo { get; set; }
    public string ShipToAddrLine1 { get; set; }
    public string ShipToAddrLine2 { get; set; }
    public string ShipToAddrLine3 { get; set; }
    public string ShipToAddrPostalCode { get; set; }
    public string ShipToAddrCountryCode { get; set; }
    public string ShipToEmail { get; set; }
    public string ShipToContactNo { get; set; }
    public Guid EmployeeID { get; set; }
    public string DeliveryInstruction1 { get; set; }
    public string DeliveryInstruction2 { get; set; }
    public string DeliveryInstruction3 { get; set; }
    public string DeliveryInstruction4 { get; set; }
    public string DeliveryInstruction5 { get; set; }
    public string DeliveryInstruction6 { get; set; }
    public string PreferredDeliveryTime { get; set; }
    public DateTime CancellationDate { get; set; }
    public string CustomerDeliveryNo { get; set; }
    public string TmpOrderTypeCode { get; set; }
    public Guid TmpShipToLocationID { get; set; }
    public string CurrCode { get; set; }
    public Guid TaxID { get; set; }
    public DateTime DeliveryBeforeDate { get; set; }
    public DateTime PromiseDate { get; set; }
    public string PaymentModeCode { get; set; }
    public string ChannelCode { get; set; }
    public string Comment { get; set; }
    public string CustomOrdTypeCode { get; set; }
    public string CustomField1 { get; set; }
    public string CustomField2 { get; set; }
    public string CustomField3 { get; set; }
    public int StatusCode { get; set; }
    public string Remark { get; set; }
    public Guid OrgID { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid LastUpdatedBy { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public decimal ExRate { get; set; }
    public decimal GrossAmount { get; set; }
    public Guid QuoteID { get; set; }
    public string QuoteNo { get; set; }
    public decimal WorkingOtherGrossAmount { get; set; }
    public decimal TaxRate { get; set; }
    public string TypeCode { get; set; }
    public Guid RefOrderID { get; set; }
}
