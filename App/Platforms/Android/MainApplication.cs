using Android.App;
using Android.Bluetooth;
using Android.Runtime;

namespace MAUI_Traffic_Light_Control;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
    }

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
