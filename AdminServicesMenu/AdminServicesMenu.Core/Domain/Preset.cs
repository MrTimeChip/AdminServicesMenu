namespace AdminServicesMenu.Core.Domain;

public class Preset
{
    public required string Id { get; set; }
    
    public required Favorite[] Favorites { get; set; } = Array.Empty<Favorite>();
}