using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstMauiApp
{
    public class RobotViewModel : INotifyPropertyChanged
    {
        public event EventHandler<AlertMessageEventArgs> AlertRequested;
        public ObservableCollection<Robot> Robots { get; }

        public ICommand AddRobotCommand { get; }
        public ICommand UpdateLastRobotNameCommand { get; }

        private string _nameEntryText;
        public string NameEntryText
        {
            get => _nameEntryText;
            set
            {
                _nameEntryText = value;
                OnPropertyChanged();
            }
        }

        private string _selectedType;
        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }

        private double _sliderValue;
        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                OnPropertyChanged();
            }
        }

        public RobotViewModel()
        {
            Robots = new ObservableCollection<Robot>();
            AddRobotCommand = new Command(CreateRobot);
            UpdateLastRobotNameCommand = new Command(ChangeName);
        }

        private void CreateRobot()
        {
            if (!string.IsNullOrWhiteSpace(NameEntryText) && !string.IsNullOrWhiteSpace(SelectedType) && SliderValue > 0)
            {
                Robot newRobot = new Robot(NameEntryText, SelectedType, (int)Math.Round(SliderValue));
                Robots.Add(newRobot);

                NameEntryText = string.Empty;
                SelectedType = null;
                SliderValue = 0;
            }
            else
            {
                OnAlertRequested("Information manquante", "Veuillez renseigner le nom, le type et la taille du robot", "OK");
            }
        }

        private void ChangeName()
        {
            if (Robots.Any())
            {
                var lastRobot = Robots.Last();
                if (!string.IsNullOrWhiteSpace(NameEntryText))
                {
                    lastRobot.Name = NameEntryText;
                    NameEntryText = string.Empty;
                }
                else
                {
                    OnAlertRequested("Information manquante", "Veuillez renseigner le nouveau nom du robot 🤖", "OK");
                }
            }
            else
            {
                OnAlertRequested("Information manquante", "Pas de robots dans la collection 🗿", "Okay");
            }
        }
        /* pour provoquer une alerte */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnAlertRequested(string title, string message, string cancel)
        {
            AlertRequested?.Invoke(this, new AlertMessageEventArgs(title, message, cancel));
        }

    }

    public class AlertMessageEventArgs : EventArgs
    {
        public string Title { get; }
        public string Message { get; }
        public string Cancel { get; }

        public AlertMessageEventArgs(string title, string message, string cancel)
        {
            Title = title;
            Message = message;
            Cancel = cancel;
        }
    }
}
