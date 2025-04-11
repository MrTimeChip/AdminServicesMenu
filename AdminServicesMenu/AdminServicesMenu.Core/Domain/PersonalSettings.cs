namespace AdminServicesMenu.Core.Domain;

public class PersonalSettings
{
    public string Id { get; set; } = null!;
    public Favorite[] Favorites { get; set; } = Array.Empty<Favorite>();
    public DateTime ModifiedAt { get; set; }
}