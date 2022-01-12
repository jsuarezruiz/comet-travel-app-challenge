using CometTravelApp.Models;
using CometTravelApp.Services;
using System.Collections.ObjectModel;

namespace CometTravelApp;

public class HomeView : View
{
    [State]
    readonly Destinations destinations = new();

    [Body]
    View body() => new ScrollView {
        new VStack(Comet.HorizontalAlignment.Leading) {
            ProfileView(),
            SearchView(),
            RecommendedDestinationsView(),
            TopDestinationsView()
        }
        .Background(Color.FromArgb("#F9FAFC"))
        .Padding(30)
     };

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
                .Color(Colors.Black)
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
    }.FitVertical();

    View SearchView() => new HStack
        {
            new SearchBar()
                .Background(Colors.White)
                .ClipShape(new RoundedRectangle(12))
                .Placeholder(()=>"Search Destination")
                .Margin(right: 12),
            /*
            // TODO: Fix IconImageSource issue.
            new ZStack
            {
                new Image()
            }
            .Background(Color.FromArgb("#31ACF8"))
            .Frame(height: 48, width: 48)
            .ClipShape(new RoundedRectangle(18))
            */
        }
        .Margin(new Thickness(0, 12));

    View RecommendedDestinationsView() => new VStack
        {
            new Text(()=> "Recommended")
                .Color(Colors.Black)
                .FontFamily("Rockolf Bold")
                .FontSize(20)
                .FontWeight(FontWeight.Bold)
                .Margin(new Thickness(0, 6)),
            new ScrollView(Orientation.Horizontal) {
                new HStack
                {
                     destinations.Recommended.Select(destination => new ZStack
                {
                    // Destination Background Image
                    new Image(destination.Image)
                        .Aspect(Aspect.AspectFill)
                        .ClipShape(new RoundedRectangle(36)),
                    new VStack(Comet.HorizontalAlignment.Leading) {
                        new VStack
                        {
                            new Text(() => $"{destination.Price:C}  ")
                                .Color(Colors.White)
                                .FitHorizontal()
                                .FontSize(14)
                                .FontFamily("Rockolf Bold")
                                .FontSize(14)
                                .FontWeight(FontWeight.Bold),
                        }.FitHorizontal().Frame(alignment: Alignment.Trailing)
                            .Background(Color.FromArgb("#67AEE9"))
                            .ClipShape(new RoundedRectangle(12))
                            .Padding(6)
                            .Margin(12), 

                        new Spacer(),
                        new Text(destination.Name)
                            .Color(Colors.White)
                            .FontFamily("Rockolf Bold")
                            .FontSize(18)
                            .FontWeight(FontWeight.Bold)
                            .Shadow(radius: 6),
                        new Text(destination.Place)
                            .Color(Colors.White)
                            .FontFamily("Rockolf")
                            .FontSize(14),
                    }
                    .Padding(new Thickness(16, 0, 0, 16))
                })
                }.Frame(height: 250, width: 200)
            }
        };
    View TopDestinationsView() => new VStack
        {
            new Text(()=> "Top Destinations")
                .Color(Colors.Black)
                .FontFamily("Rockolf Bold")
                .FontSize(16)
                .FontWeight(FontWeight.Bold)
                .Margin(new Thickness(0, 6)),

            new ScrollView(Orientation.Horizontal) {
                 new HStack{
                destinations.Top.Select(destination => new Image(destination.Image)
                    .Aspect(Aspect.AspectFill)
                    .ClipShape(new RoundedRectangle(24))
                    .Frame(height: 60, width: 60, alignment: Alignment.Center)

                )}.Frame(height: 60)
            }
        };

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

