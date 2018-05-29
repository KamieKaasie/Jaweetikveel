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

namespace Test
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Menu);

            var btnIngre = FindViewById<Button>(Resource.Id.btnIngre);
            var btnCock = FindViewById<Button>(Resource.Id.btnCock);
            var btnFavo = FindViewById<Button>(Resource.Id.btnFavo);

            btnIngre.Click += delegate
            {

            };

            btnCock.Click += delegate
            {
                StartActivity(typeof(Cocktails));
            };

            btnFavo.Click += delegate
            {

            };
        }
    }
}