using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public string PaymentNo { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ReferenceNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreatePaymentDto
    {
        [Required(ErrorMessage = "Ödeme numarası gereklidir")]
        [Display(Name = "Ödeme Numarası")]
        public string PaymentNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ödeme tarihi gereklidir")]
        [Display(Name = "Ödeme Tarihi")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari Hesap")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır")]
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ödeme türü seçimi gereklidir")]
        [Display(Name = "Ödeme Türü")]
        public int PaymentTypeID { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Referans No")]
        public string? ReferenceNo { get; set; }
    }

    public class UpdatePaymentDto
    {
        [Required(ErrorMessage = "Ödeme tarihi gereklidir")]
        [Display(Name = "Ödeme Tarihi")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari Hesap")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır")]
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ödeme türü seçimi gereklidir")]
        [Display(Name = "Ödeme Türü")]
        public int PaymentTypeID { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Referans No")]
        public string? ReferenceNo { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }

    public class CollectionDto
    {
        public int CollectionID { get; set; }
        public string CollectionNo { get; set; } = string.Empty;
        public DateTime CollectionDate { get; set; }
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ReferenceNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateCollectionDto
    {
        [Required(ErrorMessage = "Tahsilat numarası gereklidir")]
        [Display(Name = "Tahsilat Numarası")]
        public string CollectionNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tahsilat tarihi gereklidir")]
        [Display(Name = "Tahsilat Tarihi")]
        public DateTime CollectionDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari Hesap")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır")]
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ödeme türü seçimi gereklidir")]
        [Display(Name = "Ödeme Türü")]
        public int PaymentTypeID { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Referans No")]
        public string? ReferenceNo { get; set; }
    }

    public class UpdateCollectionDto
    {
        [Required(ErrorMessage = "Tahsilat tarihi gereklidir")]
        [Display(Name = "Tahsilat Tarihi")]
        public DateTime CollectionDate { get; set; }

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari Hesap")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır")]
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ödeme türü seçimi gereklidir")]
        [Display(Name = "Ödeme Türü")]
        public int PaymentTypeID { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Referans No")]
        public string? ReferenceNo { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }

    public class PaymentTypeDto
    {
        public int PaymentTypeID { get; set; }
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreatePaymentTypeDto
    {
        [Required(ErrorMessage = "Tip kodu gereklidir")]
        [Display(Name = "Tip Kodu")]
        public string TypeCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tip adı gereklidir")]
        [Display(Name = "Tip Adı")]
        public string TypeName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }

    public class UpdatePaymentTypeDto
    {
        [Required(ErrorMessage = "Tip adı gereklidir")]
        [Display(Name = "Tip Adı")]
        public string TypeName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 