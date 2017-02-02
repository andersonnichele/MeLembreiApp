using System;
using System.IO;
using Xamarin.Forms;
using MeLembreiApp.Droid;

[assembly: Dependency(typeof(ArquivoHelper))]
namespace MeLembreiApp.Droid
{
    public class ArquivoHelper : IArquivoHelper
    {
        public string GetCaminhoLocal(string nomeArquivo)
        {
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(caminho, nomeArquivo);
        }
    }
}