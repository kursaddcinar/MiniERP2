namespace MiniERP.API.DTOs
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public string PaymentNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class CreatePaymentDto
    {
        public string PaymentNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string? Description { get; set; }
    }

    public class UpdatePaymentDto
    {
        public int CariID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = "COMPLETED";
    }

    public class CollectionDto
    {
        public int CollectionID { get; set; }
        public string CollectionNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public DateTime CollectionDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class CreateCollectionDto
    {
        public string CollectionNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public DateTime CollectionDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateCollectionDto
    {
        public int CariID { get; set; }
        public DateTime CollectionDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = "COMPLETED";
    }

    public class PaymentTypeDto
    {
        public int PaymentTypeID { get; set; }
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PaymentCount { get; set; }
        public int CollectionCount { get; set; }
    }

    public class CreatePaymentTypeDto
    {
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class UpdatePaymentTypeDto
    {
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class PaymentSummaryDto
    {
        public int TotalPayments { get; set; }
        public decimal TotalPaymentAmount { get; set; }
        public int TotalCollections { get; set; }
        public decimal TotalCollectionAmount { get; set; }
        public decimal NetCashFlow { get; set; }
        public int PendingPayments { get; set; }
        public int PendingCollections { get; set; }
        public decimal PendingPaymentAmount { get; set; }
        public decimal PendingCollectionAmount { get; set; }
    }

    public class CashFlowDto
    {
        public DateTime Date { get; set; }
        public decimal Incoming { get; set; }
        public decimal Outgoing { get; set; }
        public decimal NetFlow { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class CashFlowReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal TotalIncoming { get; set; }
        public decimal TotalOutgoing { get; set; }
        public decimal NetCashFlow { get; set; }
        public List<CashFlowDto> CashFlows { get; set; } = new List<CashFlowDto>();
    }
} 