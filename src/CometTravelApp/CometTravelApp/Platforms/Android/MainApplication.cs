using Android.App;
using Android.Runtime;
using Microsoft.Maui.Hosting;

namespace CometTravelApp;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)	: base(handle, ownership)
	{
        Microsoft.Maui.Handlers.WindowHandler.Mapper.Add("Toolbar", (h, w) =>
        {
            var appbarLayout = h.PlatformView.FindViewById<Android.Views.ViewGroup>(Microsoft.Maui.Resource.Id.navigationlayout_appbar);
            appbarLayout.RemoveAllViews();
        });
    }
	protected override MauiApp CreateMauiApp() => App.CreateMauiApp();
}