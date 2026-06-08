using Collection_Management_System.Models;
using Collection_Management_System.ViewModels;

namespace Collection_Management_System.Views
{
    public partial class CollectionsPage : ContentPage
    {
        private MainViewModel _viewModel;

        public CollectionsPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;
        }

        private async void OnCollectionSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is UserCollection selectedCollection)
            {
                ((CollectionView)sender).SelectedItem = null;
                
                await Navigation.PushAsync(new CollectionItemsPage(selectedCollection));
            }
        }

        private void OnAddCollectionClicked(object sender, EventArgs e)
        {
            var name = NewCollectionEntry.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                _viewModel.AddCollectionCommand.Execute(name);
                NewCollectionEntry.Text = string.Empty;
            }
        }
    }
}
