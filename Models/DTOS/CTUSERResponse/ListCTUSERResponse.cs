namespace WebAPI.Models.DTOS.CTUSERResponse;

public class ListCTUSERResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Lname { get; set; } = string.Empty;
    public string? Doctype { get; set; } = string.Empty;
}
