using CometTravelApp.Models;
using CometTravelApp.Services;
using System.Collections.ObjectModel;

namespace CometTravelApp;

public class HomeView : View
{
    [State]
    readonly Destinations destinations = new();

    [Body]
    View body()
        => new VStack {
            ProfileView(),
            SearchView(),
            RecommendedDestinationsView(),
            TopDestinationsView()
        }
        .Background(Color.FromArgb("#F9FAFC"))
        .Padding(30);

    View ProfileView() => new HStack
    {
        new Image(()=>"profile.png")
            .ClipShape(new Ellipse())
            .Frame(alignment: Alignment.Center),
        new VStack(Comet.HorizontalAlignment.Leading) {
            new Text(()=> "Welcome")
                .FontFamily("Rockolf")
                .FontSize(14),
            new Text(()=> "Arya Wijaya")
                .TextColor(Colors.Black)
                .FontFamily("Rockolf Bold")
                .FontSize(18)
                .FontWeight(FontWeight.Bold),
        }
        .FillHorizontal()
        .Margin(left: 12),
        new VStack(Comet.HorizontalAlignment.Trailing) {
            new Image(()=>"bell.png")
                .Frame(height: 48, width: 48, alignment: Alignment.Center)
                .Aspect(Aspect.AspectFit)
                .Margin(right: 12)
        }
    };

    View SearchView()
    {
        return new HStack
        {
            new SearchBar()
                .Background(Colors.White)
                .ClipShape(new RoundedRectangle(12))
                .Placeholder(()=>"Search Destination")
                .Margin(right: 12),
            new ZStack
            {
                new Image()
            }
            .Background(Color.FromArgb("#31ACF8"))
            .Frame(height: 48, width: 48)
            .ClipShape(new RoundedRectangle(18))
        }
        .Margin(new Thickness(0, 12));
    }

    View RecommendedDestinationsView()
    {
        var horizontalRecommendedStack = new HStack();

        foreach (Destination destination in destinations.Recommended)
        {
            horizontalRecommendedStack.Add(
                new ZStack
                {
                    new Image(destination.Image)
                        .Aspect(Aspect.AspectFill)
                        .ClipShape(new RoundedRectangle(36)),
                    new VStack {
                        new Text(destination.Name)
                            .TextColor(Colors.White)
                            .FontFamily("Rockolf Bold")
                            .FontSize(18)
                            .FontWeight(FontWeight.Bold),
                        new Text(destination.Place)
                            .TextColor(Colors.White)
                            .FontFamily("Rockolf")
                            .FontSize(14),
                    }
                    .Frame(alignment: Alignment.BottomTrailing)
                    .Padding(new Thickness(12, 0, 0, 24))
                }
                .Frame(height: 250, width: 200)
            );
        }

        return new VStack
        {
            new Text(()=> "Recommended")
                .TextColor(Colors.Black)
                .FontFamily("Rockolf Bold")
                .FontSize(20)
                .FontWeight(FontWeight.Bold)
                .Margin(new Thickness(0, 6)),
            new ScrollView(Orientation.Horizontal) { 
                horizontalRecommendedStack 
            }
        };
    }

    View TopDestinationsView()
    {
        var horizontalTopStack = new HStack()
            .Frame(height: 60);

        foreach (Destination destination in destinations.Top)
        {
            horizontalTopStack.Add(new ZStack
            {
                new Image(destination.Image)       
                    .Aspect(Aspect.AspectFill)
                    .ClipShape(new RoundedRectangle(24))
                    .Frame(height: 60, width: 60, alignment: Alignment.Center),
            });
        }

        return new VStack
        {
            new Text(()=> "Top Destinations")
                .TextColor(Colors.Black)
                .FontFamily("Rockolf Bold")
                .FontSize(16)
                .FontWeight(FontWeight.Bold)
                .Margin(new Thickness(0, 6)),
            horizontalTopStack
        };
    }

    public class Destinations : BindingObject
    {
        public Destinations()
        {
            Recommended = new ObservableCollection<Destination>(DestinationService.Instance.RecommendedDestinations);
            Top = new ObservableCollection<Destination>(DestinationService.Instance.TopDestinations);
        }

        public ObservableCollection<Destination> Recommended
        {
            get => GetProperty<ObservableCollection<Destination>>();
            set => SetProperty(value);
        }

        public ObservableCollection<Destination> Top
        {
            get => GetProperty<ObservableCollection<Destination>>();
            set => SetProperty(value);
        }
    }
}

