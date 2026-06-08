using Collection_Management_System.Models;
using Collection_Management_System.ViewModels;

namespace Collection_Management_System.Views
{
    public partial class ItemEditPage : ContentPage
    {
        private CollectionViewModel _viewModel;
        private CollectibleItem? _itemToEdit;

        public ItemEditPage(CollectionViewModel viewModel, CollectibleItem? item = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _itemToEdit = item;

            if (_itemToEdit != null)
            {
                Title = "Edit Item";
                NameEntry.Text = _itemToEdit.Name;
                DescriptionEditor.Text = _itemToEdit.Description;
                DeleteButton.IsVisible = true;
            }
            else
            {
                Title = "Add New Item";
                DeleteButton.IsVisible = false;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var description = DescriptionEditor.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                await DisplayAlert("Error", "Name cannot be empty", "OK");
                return;
            }

            if (_itemToEdit == null)
            {
                _viewModel.AddItem(name, description);
            }
            else
            {
                _viewModel.UpdateItem(_itemToEdit, name, description);
            }

            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_itemToEdit != null)
            {
                bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
                if (answer)
                {
                    _viewModel.DeleteItem(_itemToEdit);
                    await Navigation.PopAsync();
                }
            }
        }
    }
}
