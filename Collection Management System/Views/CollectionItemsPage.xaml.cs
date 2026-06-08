using Collection_Management_System.Models;
using Collection_Management_System.ViewModels;

namespace Collection_Management_System.Views
{
    public partial class CollectionItemsPage : ContentPage
    {
        private CollectionViewModel _viewModel;

        public CollectionItemsPage(UserCollection collection)
        {
            InitializeComponent();
            _viewModel = new CollectionViewModel(collection);
            BindingContext = _viewModel;
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is CollectibleItem selectedItem)
            {
                ((CollectionView)sender).SelectedItem = null;
                await Navigation.PushAsync(new ItemEditPage(_viewModel, selectedItem));
            }
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemEditPage(_viewModel));
        }
    }
}
