using System.Collections.ObjectModel;

namespace FirstMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel = new RobotViewModel();
            BindingContext = viewModel;

            viewModel.AlertRequested += OnViewModelAlertRequested;
        }

        private async void OnViewModelAlertRequested(object sender, AlertMessageEventArgs e)
        {
            await DisplayAlert(e.Title, e.Message, e.Cancel);
        }
    }

}