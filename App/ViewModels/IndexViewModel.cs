using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Traffic_Light_Control.Models;
using System.IO.Ports;
using System.Threading.Tasks;

namespace MAUI_Traffic_Light_Control.ViewModels
{
    public class IndexViewModel : ObservableObject
    {
        public IndexViewModel() { 
        IndexModel = new Models.IndexModel();
        SaveCommand = new RelayCommand(OnSaveCommand);
        }
        public Models.IndexModel IndexModel { get; set; }
        public ICommand SaveCommand { get; set; }
        private async void OnSaveCommand()
        {
            string redlight_duration = "setred" + IndexModel.RedLightDuration;
            string yellowlight_duration = "setylw" + IndexModel.YellowLightDuration;
            string greenlight_duration = "setgrn" + IndexModel.GreenLightDuration;

            try
            {
                SerialPort _serialPort = new SerialPort("COM1", 4800, Parity.None, 8, StopBits.One);
                if (_serialPort.IsOpen == false)
                {
                    _serialPort.Open();
                }
                _serialPort.Write(redlight_duration);
                await Task.Delay(2000);
                _serialPort.Write(yellowlight_duration);
                await Task.Delay(2000);
                _serialPort.Write(greenlight_duration);
                await Task.Delay(1000);
                _serialPort.Close();
                Application.Current.MainPage.DisplayAlert("Success", "Configuration Saved", "OK");
            }
            catch (Exception x)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Something went Wrong.", "OK");
            }
        }
    }


}
