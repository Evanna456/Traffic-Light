using CommunityToolkit.Mvvm.ComponentModel;

using System.IO.Ports;

namespace MAUI_Traffic_Light_Control.Models
{
    public class IndexModel : ObservableObject
    {
        private string isPowerToggled = "True";
        private string redLightDuration;
        private string yellowLightDuration;
        private string greenLightDuration;
        public string IsPowerToggled
        {
            get { return isPowerToggled; }
            set { SetProperty(ref isPowerToggled, value); OnPowerSwitchCommand(); }
        }

        public string RedLightDuration
        {
            get { return redLightDuration; }
            set { SetProperty(ref redLightDuration, value); }
        }

        public string YellowLightDuration
        {
            get { return yellowLightDuration; }
            set { SetProperty(ref yellowLightDuration, value); }
        }

        public string GreenLightDuration
        {
            get { return greenLightDuration; }
            set { SetProperty(ref greenLightDuration, value); }
        }

        private void OnPowerSwitchCommand()
        {
         try{
            SerialPort _serialPort = new SerialPort("COM1", 4800, Parity.None, 8, StopBits.One);
            if (_serialPort.IsOpen == false)
            {
                _serialPort.Open();
            }
            if(isPowerToggled == "False") {
            _serialPort.Write("off");
            Application.Current.MainPage.DisplayAlert("Success", "Device is turned Off.", "OK");
            }else if(isPowerToggled == "True") {
            _serialPort.Write("on");
            Application.Current.MainPage.DisplayAlert("Success", "Device is turned On.", "OK");
             }
            _serialPort.Close();
            }catch (Exception x){
              Application.Current.MainPage.DisplayAlert("Error", "Something went Wrong.", "OK");
            }
        }
    }
}