using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using DatePicker = Xamarin.Forms.DatePicker;
using Entry = Xamarin.Forms.Entry;
using Picker = Xamarin.Forms.Picker;
using TimePicker = Xamarin.Forms.TimePicker;

namespace GridElement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Osnova : ContentPage
    {
        Picker pick;
        Editor edit;
        DatePicker date;
        Entry entr;
        Frame frm;
        TimePicker time;
        Label lbl;
        public Osnova()
        {
            InitializeComponent();
            Grid grd = new Grid();
            Picker pick;
            //------------------------------------------------------------
            //Колонны
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            grd.ColumnDefinitions.Add(colDef1);
            grd.ColumnDefinitions.Add(colDef2);
            //Ряды
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            grd.RowDefinitions.Add(rowDef1);
            grd.RowDefinitions.Add(rowDef2);
            grd.RowDefinitions.Add(rowDef3);

            
            //-------------------------------------------------------------
            //Datepicker
            date = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-10),
                MaximumDate = DateTime.Now.AddDays(+10),
            };
            date.DateSelected += Date_DateSelected;
            grd.Children.Add(date, 0, 1);
            //Picker
            pick = new Picker
            {
                Title = "Choose language"
            };
            pick.Items.Add("C#");
            pick.Items.Add("Python");
            pick.Items.Add("C++");
            pick.Items.Add("BisualBasic");
            pick.Items.Add("Java");
            pick.SelectedIndexChanged += Pick_SelectedIndexChanged;
            grd.Children.Add(pick, 0, 0);
            //Editor
            edit = new Editor { Placeholder = "Choose language \nIn left column" };
            grd.Children.Add(edit, 1, 0);

            //Entry
            entr = new Entry
            {
                Text = "Choose date",
            };
            grd.Children.Add(entr, 1, 1);
            //Frame
            frm = new Frame { BackgroundColor = Color.LightGray };
            {

            };
            grd.Children.Add(frm, 0, 2);
            Grid.SetColumnSpan(frm, 2);

            //Timepicker СИНХРОНИЗИРОВАННОЕ ВРЕМЯ!!! -------------------------------------------------------------------------------------------------
            /* time = new TimePicker
             {
                 Time = new TimeSpan(18, 0, 0),
                 Time = new TimeSpan (DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        };
            grd.Children.Add(time, 1, 1);
            */
            Content = grd;
        }

        private void Date_DateSelected(object sender, DateChangedEventArgs e)
        {
            entr.Text = "Your date:\n"+e.NewDate.ToString("G");
        }

        private void Pick_SelectedIndexChanged(object sender, EventArgs e)
        {
            edit.Text = "Thank you"; //+ pick.Items[pick.SelectedIndex];
        }
    }
}
