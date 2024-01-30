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
                // if all data is entered, pass to new robot & add to robots collection
                Robot newRobot = new Robot(NameEntryText, SelectedType, (int)Math.Round(SliderValue)*2);
                Robots.Add(newRobot);

                // empty all fields
                NameEntryText = string.Empty;
                SelectedType = null;
                SliderValue = 0;
            }
            else
            {
                // else send alert
                OnAlertRequested("Information manquante", "Veuillez renseigner le nom, le type et la taille du robot", "OK");
            }
        }

        // function to modify existing robot's name
        private void ChangeName()
        {
            if (Robots.Any())
            {
                // if there are robots in collection, take last one
                var lastRobot = Robots.Last();
                if (!string.IsNullOrWhiteSpace(NameEntryText))
                {
                    // if new name is in input, register it and clear all inputs
                    lastRobot.Name = NameEntryText;
                    NameEntryText = string.Empty;
                    SelectedType = null;
                    SliderValue = 0;
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
        
        // function to trigger an alert
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


}
