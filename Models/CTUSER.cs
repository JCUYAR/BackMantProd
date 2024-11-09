namespace WebAPI.Models;

public partial class CTUSER
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Lname { get; set; } = string.Empty;
    public string? Doctype { get; set; } = string.Empty;
    public string? Docnum { get; set; } = string.Empty;
    public string? Nationality { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public DateTime? Borndate { get; set; }
    public string? Gender { get; set; } = string.Empty;

}
