using System.Net.Http;
using System.Web;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        HttpClient client;
        List<Calcolo> Cronologia;
        public MainPage()
        {
            InitializeComponent();
            client = new HttpClient();
            Cronologia = new List<Calcolo>();
            BindingContext = this;
        }
        private void OnAddToExpression(object sender, System.EventArgs e)
        {
            lblExpressionContainer.Text += (sender as Button).Text;
        }
        private async void OnGetResults(object sender, System.EventArgs e)
        {
            string result = "";
            string expr = HttpUtility.UrlEncode($"{lblExpressionContainer.Text}");
            var response = await client.GetAsync($"https://api.mathjs.org/v4/?expr={expr}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsStringAsync();
            Cronologia.Add(new Calcolo { Expression = lblExpressionContainer.Text , Result = result});
            lblExpressionContainer.Text = result;
        }
        private void OnDeleteOne(object sender, System.EventArgs e)
        {
            if (lblExpressionContainer.Text == "")
                return;
            lblExpressionContainer.Text = lblExpressionContainer.Text.Remove(lblExpressionContainer.Text.Length - 1);
        }
        private void OnDeleteAll(object sender, System.EventArgs e)
        {
            lblExpressionContainer.Text = "";
        }
        private async void GoToChronology(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ChronologyPage(Cronologia));
        }
    }
}
