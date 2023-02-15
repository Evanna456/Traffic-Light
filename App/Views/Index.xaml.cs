using MAUI_Traffic_Light_Control.ViewModels;

namespace MAUI_Traffic_Light_Control.Views;

public partial class Index : ContentPage
{
    public Index()
    {
        InitializeComponent();
        BindingContext = new IndexViewModel();
    }
}