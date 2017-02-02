using MeLembreiApp.Models;
using System;

using Xamarin.Forms;

namespace MeLembreiApp.Views
{
    public partial class LembretePage : ContentPage
    {
        public LembretePage()
        {
            InitializeComponent();

            Title = "Lembrete";
        }

        async void OnSalvarClicked(object sender, EventArgs e)
        {
            var lembrete = (Lembrete)BindingContext;
            await App.LembreteDatabase.SalvarLembreteAsync(lembrete);
            await Navigation.PopAsync();
        }

        async void OnDeletarClicked(object sender, EventArgs e)
        {
            var lembrete = (Lembrete)BindingContext;
            await App.LembreteDatabase.DeletarLembreteAsync(lembrete);
            await Navigation.PopAsync();
        }

        async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var lembrete = (Lembrete)BindingContext;

            if(lembrete.Id == 0)
            {
                btnCancelar.IsVisible = false;
            }
        }
    }
}
