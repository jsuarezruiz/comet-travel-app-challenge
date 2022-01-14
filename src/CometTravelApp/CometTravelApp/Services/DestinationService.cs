using CometTravelApp.Models;
using System.Collections.Generic;

namespace CometTravelApp.Services;
public class DestinationService
{
    static DestinationService _instance;

    public static DestinationService Instance => _instance ??= new DestinationService();
    internal List<GalleryItem> Gallery => new List<GalleryItem> {
                new GalleryItem { Id = 1, Image = "destination1.jpg" },
                new GalleryItem { Id = 2, Image = "destination2.jpg" },
                new GalleryItem { Id = 3, Image = "destination3.jpg" },
                new GalleryItem { Id = 4, Image = "destination4.jpg" }
            };

    public List<Destination> RecommendedDestinations => new List<Destination> {
                new Destination { Name = "Japan Temple", Place = "Osaka Street, Japan", Image = "destination1.jpg", Price = 120, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
                new Destination { Name = "Torii Gate", Place = "Tokyo Street, Japan", Image = "destination2.jpg", Price = 90, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
                new Destination { Name = "Japan Street", Place = "Japan", Image = "destination3.jpg", Price = 60, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
                new Destination { Name = "Japan Street", Place = "Japan", Image = "destination4.jpg", Price = 120, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
            };

    public List<Destination> TopDestinations => new List<Destination> {
                new Destination { Name = "Japan Street", Place = "Japan", Image = "destination3.jpg", Price = 60, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
                new Destination { Name = "Japan Street", Place = "Japan", Image = "destination4.jpg", Price = 120, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
                new Destination { Name = "Japan Temple", Place = "Osaka Street, Japan", Image = "destination1.jpg", Price = 120, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
                new Destination { Name = "Torii Gate", Place = "Tokyo Street, Japan", Image = "destination2.jpg", Price = 90, About = "Modern destination, with sky landspace, Simple Building, and perfect for photos.", Gallery = Gallery },
            };
}
