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
    [Activity(Label = "LoggIn")]
    public class LoggIn : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LogIn);

            var edUsNam = FindViewById<EditText>(Resource.Id.edTxtUsNam);
            var edUsPass = FindViewById<EditText>(Resource.Id.edTxtPass);
            var btnLog = FindViewById<Button>(Resource.Id.btnLoIn);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbUser.db3");

            btnLog.Click += delegate
            {
                var db = new SQLiteConnection(dbPath);
                var table = db.Table<LogIn>();

                if (edUsNam.Text == "")
                {
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Error");
                    alertDialog.SetMessage("Username can not be empty");
                    alertDialog.SetNeutralButton("OK", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
                else if(edUsPass.Text == "")
                {
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Error");
                    alertDialog.SetMessage("Password can not be empty");
                    alertDialog.SetNeutralButton("OK", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
                else
                {
                    Boolean allowance = false;

                    foreach(var item in table)
                    {
                        if(edUsNam.Text == item.UserName && edUsPass.Text == item.Password)
                        {
                            allowance = true;
                        }
                    }

                    if (allowance)
                    {
                        StartActivity(typeof(Menu));
                    }
                    else
                    {
                        AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                        alertDialog.SetTitle("Error");
                        alertDialog.SetMessage("Incorrect Username or Password");
                        alertDialog.SetNeutralButton("OK", delegate
                        {
                            alertDialog.Dispose();
                        });
                        alertDialog.Show();
                    }
                }
            };
        }
    }
}