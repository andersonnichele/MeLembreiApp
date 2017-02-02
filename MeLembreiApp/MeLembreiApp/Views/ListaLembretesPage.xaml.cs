using MeLembreiApp.Models;
using System;

using Xamarin.Forms;

namespace MeLembreiApp.Views
{
    public partial class ListaLembretesPage : ContentPage
    {
        public ListaLembretesPage()
        {
            InitializeComponent();

            Title = "Lista Lembretes";
        }

        async void OnCriarLembrete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LembretePage
            {
                BindingContext = new Lembrete { Id = 0, DataLimite = DateTime.Now }
            });
        }

        async void OnListLembreteSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new LembretePage
            {
                BindingContext = e.SelectedItem as Lembrete
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstViewlembretes.ItemsSource = await App.LembreteDatabase.TodosLembretesAsync();

        }
    }
}