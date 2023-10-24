namespace Hotel.Models;

public sealed class NewVisitorRequest
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Sex { get; set; }

    public int PhoneNumber { get; set; }
}
