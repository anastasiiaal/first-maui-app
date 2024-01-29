using System.Collections.ObjectModel;

namespace FirstMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new RobotViewModel();
        }


    //    private ObservableCollection<Robot> robots;
    //    public ObservableCollection<Robot> Robots { 
    //        get { return robots; }
    //        set { robots = value; OnPropertyChanged(); }
    //    }

    //    public MainPage()
    //    {
    //        InitializeComponent();

    //        Robots = new ObservableCollection<Robot>();
    //        this.BindingContext = this;
    //    }

    //    private void createRobot(object sender, EventArgs e)
    //    {
    //        string name = nameEntry.Text; 
    //        string type = (string)typePicker.SelectedItem;
    //        int size = (int)Math.Round(slider.Value);

    //        if (!string.IsNullOrWhiteSpace(name) && type != null && size > 0)
    //        {
    //            Robot newRobot = new Robot(name, type, size);
    //            Robots.Add(newRobot);

    //            nameEntry.Text = string.Empty;
    //            typePicker.SelectedItem = null;
    //            slider.Value = 0;
    //        }
    //        else
    //        {
    //            DisplayAlert("Information manquante", "Veuillez renseigner le nom, le type et la taille du robot", "OK");
    //        }
    //    }

    //    private void changeName(object sender, EventArgs e)
    //    {
    //        if (Robots.Any())
    //        {
    //            var lastRobot = Robots.Last();
    //            string name = nameEntry.Text;
    //            if (!string.IsNullOrWhiteSpace(name))
    //            {
    //                lastRobot.Name = name;
    //                nameEntry.Text = string.Empty;
    //            }
    //            else
    //            {
    //                DisplayAlert("Information manquante", "Veuillez renseigner le nouveau nom du robot 🤖", "OK");
    //            }
    //        } 
    //        else
    //        {
    //            DisplayAlert("Information manquante", "Pas de robots dans la collection 🗿", "Okay");
    //        }
    //    }

    }
}