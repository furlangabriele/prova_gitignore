using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChronologyPage : ContentPage
    {
        public List<Calcolo> Cronologia { get; private set; }
        public ChronologyPage(List<Calcolo> cronologia)
        {
            InitializeComponent();
            Cronologia = cronologia;
            BindingContext = this;
        }
        private async void OnDeleteObject(object sender, EventArgs e)
        {
            var toDelete = collectionViewChronology.SelectedItem as Calcolo;
            Cronologia.Remove(toDelete);
            await Navigation.PushAsync(new ChronologyPage(Cronologia));
            Navigation.RemovePage(this);
        }
    }
}