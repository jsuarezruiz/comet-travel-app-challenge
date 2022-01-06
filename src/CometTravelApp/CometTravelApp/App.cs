using Microsoft.Maui.Hosting;

namespace CometTravelApp;
public class App : CometApp
{
	[Body]
	View view() => new HomeView();

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseCometApp<App>()
			.ConfigureFonts(fonts => {
				fonts.AddFont("rockolf.ttf", "Rockolf");
				fonts.AddFont("rockolf-bold.ttf", "Rockolf Bold");
				fonts.AddFont("rockoultraflf.ttf", "Rockoultraflf");
				fonts.AddFont("rockoultraflf-bold.ttf", "Rockoultraflf Bold");
				fonts.AddFont("MaterialIcons-Regular.ttf", "Material");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		//-:cnd
#if DEBUG
			builder.EnableHotReload();
#endif
		//+:cnd
		return builder.Build();
	}
}
