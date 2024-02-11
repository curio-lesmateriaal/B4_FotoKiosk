using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace FotoKioskApp
{
    public static class DebugHelper
    {
        // Gebruik deze methode in een pagina om een popup met bericht te laten zien.
        //
        // Bijvoorbeeld:
        //         await DebugHelper.ShowDialog(this, "Hello World");
        //
        // Geef als eerste parameter "this" mee, waar dat een verwijzing naar de huidige pagina is.
        public static async Task ShowDialog(Page page, string text)
        {
            if (page == null)
            {
                throw new ArgumentNullException("De eerste parameter `page` mag niet NULL zijn. Gebruik `this` vanuit een pagina om de huidige pagina te verwijzen.");
            }

            var dialog = new ContentDialog
            {
                XamlRoot = page.XamlRoot,
                Title = "Debug",
                Content = text,
                CloseButtonText = "Ok"
            };

            try
            {
                await dialog.ShowAsync();
            } catch (ArgumentException)
            {
                // Deze methode werkt niet in de constructor van de pagina, noch in de 'Activated' event handler.
                // Gebruik deze methode op zijn vroegst in de 'Loaded' event handler van de pagina.
                throw new Exception("Deze `ShowDialog` methode kan op zijn vroegst worden aangeroepen in de Loaded event handler van de pagina.");
            }
        }

        // Gebruik deze methode om één popup met alle items uit een List te laten zien:
        public static async Task ShowList(Page page, IEnumerable<object> list)
        {
            string text = "";
            if (list == null)
            {
                text = "List passed was NULL";
            }
            else if (list is IEnumerable<StorageFile>)
            {
                foreach (StorageFile item in list)
                {
                    text += item.Path + "\n";
                }
            }
            else if (list is IEnumerable<StorageFolder>)
            {
                foreach (StorageFolder item in list)
                {
                    text += item.Path + "\n";
                }
            }
            else if (list is IEnumerable<StorageFile>)
            {
                foreach (StorageFile item in list)
                {
                    text += item.Path + "\n";
                }
            }
            else
            {
                foreach (var item in list)
                {
                    text += item.ToString();
                }
            }

            await ShowDialog(page, text);
        }

        // Gebruik deze methode om één popup met alle bestanden in een folder te laten zien:
        public static async Task ShowFolder(Page page, StorageFolder folder)
        {
            string text = folder.Path + "\n";
            foreach (var item in await folder.GetFilesAsync())
            {
                text += "  \\" + item.Name + "\n";
            }

            await ShowDialog(page, text);
        }
    }
}
