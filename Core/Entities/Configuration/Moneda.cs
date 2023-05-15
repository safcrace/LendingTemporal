namespace Core.Entities.Configuration;

public class Moneda : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
}