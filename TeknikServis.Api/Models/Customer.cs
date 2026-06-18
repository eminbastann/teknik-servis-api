namespace TeknikServis.Api.Models;

public class Customer
{
    public int Id { get; set; }

    public CustomerType CustomerType { get; set; } = CustomerType.RealPerson;

    public string? FullName { get; set; }

    public string? CompanyName { get; set; }

    public string Phone { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? NationalIdentityNumber { get; set; }

    public string? TaxOffice { get; set; }

    public string? TaxNumber { get; set; }

    public string? address2 { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<CustomerContact> Contacts { get; set; } = new List<CustomerContact>();
}