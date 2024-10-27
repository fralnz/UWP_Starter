using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UserRegistry.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace UserRegistry.Views
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class Chiamate_HTTP : Page
    {
        HttpClient httpClient = new();
        public Chiamate_HTTP()
        {
            this.InitializeComponent();
        }

        private  async void BtnHttpGetComments_Click(object sender, RoutedEventArgs e)
        {
            CommentsLoadingRing.IsActive = true;
            await Task.Delay(3000);
            var comments = await httpClient.GetFromJsonAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments");
            CommentListView.ItemsSource = comments;
            CommentsLoadingRing.IsActive = false;
        }
    }
}
