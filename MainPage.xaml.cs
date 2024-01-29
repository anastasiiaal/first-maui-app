namespace FirstMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void createRobot(object sender, EventArgs e)
        {
            string name = nameEntry.Text; 
            string type = (string)typePicker.SelectedItem;
            int size = (int)Math.Round(slider.Value);

            if (!string.IsNullOrWhiteSpace(name) && type != null && size > 0)
            {
                Robot newRobot = new Robot(name, type, size);

                Label robotLabel = new Label
                {
                    Text = $"Nouveau robot nom: {newRobot.Name} \nType de Robot: {newRobot.Type} \nTaille de Robot: {newRobot.Size}",
                    HorizontalOptions = LayoutOptions.Center,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), // Set a predefined size for the font
                    Margin = 10,
                };

                robotsStackLayout.Children.Add(robotLabel);

                // Optionally clear the inputs
                nameEntry.Text = string.Empty;
                typePicker.SelectedItem = null;
                slider.Value = 0;
            }
            else
            {
                DisplayAlert("Information manquante", "Veuillez renseigner le nom, le type et la taille du robot.", "OK");
            }
        }
    }
}