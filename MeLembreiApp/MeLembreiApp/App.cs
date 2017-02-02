using MeLembreiApp.Persistencia;
using Xamarin.Forms;
using MeLembreiApp.Views;

namespace MeLembreiApp
{
    public class App : Application
    {
        static LembreteDatabase lembreteDatabase;


        public App()
        {
            var nav = new NavigationPage(new ListaLembretesPage());

            MainPage = nav;
        }

        public static LembreteDatabase LembreteDatabase
        {
            get
            {
                if (lembreteDatabase == null)
                {
                    lembreteDatabase = new LembreteDatabase(DependencyService.Get<IArquivoHelper>().GetCaminhoLocal("LembretesSQLite.db3"));
                }
                return lembreteDatabase;
            }
        }
    }
}
