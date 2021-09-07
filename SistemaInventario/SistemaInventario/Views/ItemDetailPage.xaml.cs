using SistemaInventario.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SistemaInventario.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}