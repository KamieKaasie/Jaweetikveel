using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;

namespace Test
{
    [Activity(Label = "Cocktails")]
    public class Cocktails : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Cocktails);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbUser.db3");
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Cocktail>();
            Cocktail sex_on_the_beach = new Cocktail();
            sex_on_the_beach.Id = 1;
            sex_on_the_beach.Name = "Sex on the ";
            sex_on_the_beach.Desc = "De Sex on the Beach is een heerlijke zomerse cocktail die gemaakt is van vodka, perziktree likeur, sinaasappelsap en cranberrysap.";
            sex_on_the_beach.Instr = "stap 1: 30ml vodka in glas, stap 2: 15ml perzik liqeur in glas, stap 3: 60ml sinaasappelsap in glas, stap 4: vul cranberrysap toe tot rand glas";

        }
    }
}