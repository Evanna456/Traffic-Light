namespace MAUI_Traffic_Light_Control;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using MAUI_Traffic_Light_Control.Views;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();

#if WINDOWS

        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            const int WindowWidth = 320;
            const int WindowHeight = 320;
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Title = "Totally Not Malware";
            appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
            appWindow.Changed += onWindowChanged;

            void onWindowChanged(AppWindow appWindow , AppWindowChangedEventArgs args)
            {
              if(args.DidSizeChange)
              {
               if(appWindow.Size.Width < WindowWidth || appWindow.Size.Height < WindowHeight){
                 appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
               }
              }
            }
         });
#endif

        MainPage = new AppShell();
        MainPage = new NavigationPage(new Index());
    }
}
