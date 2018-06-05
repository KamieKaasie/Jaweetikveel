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
    [Activity(Label = "CreateAccount")]
    public class CreateAccount : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CreateAccount);

            var image1 = FindViewById<ImageView>(Resource.Id.imageView1);
            var edtUser = FindViewById<EditText>(Resource.Id.edTxtUserName);
            var edtPass = FindViewById<EditText>(Resource.Id.edTxtPassword);
            var edtConf = FindViewById<EditText>(Resource.Id.edTxtConfPassword);
            var btnCreate = FindViewById<Button>(Resource.Id.btnCreateAccount);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbUser.db3");

            btnCreate.Click += delegate
            {
                var db = new SQLiteConnection(dbPath);
                var table = db.Table<LogIn>();

                if (edtUser.Text == "")
                {
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Error");
                    alertDialog.SetMessage("Invalid Username");
                    alertDialog.SetNeutralButton("OK", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
                else if(edtPass.Text == "")
                {
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Error");
                    alertDialog.SetMessage("Invalid Password");
                    alertDialog.SetNeutralButton("OK", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
                else if(edtPass.Text != edtConf.Text)
                {
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Error");
                    alertDialog.SetMessage("Passwords are not the same");
                    alertDialog.SetNeutralButton("OK", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
                else
                {
                    Boolean allow = true;

                    foreach (var item in table)
                    {
                        if(item.UserName == edtUser.Text)
                        {
                            allow = false;
                            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetTitle("Error");
                            alertDialog.SetMessage("Username is already in use");
                            alertDialog.SetNeutralButton("OK", delegate
                            {
                                alertDialog.Dispose();
                            });
                            alertDialog.Show();
                        }
                    }

                    if (allow)
                    {
                        LogIn newLogIn = new LogIn();
                        newLogIn.UserName = edtUser.Text;
                        newLogIn.Password = edtPass.Text;
                        db.Insert(newLogIn);
                        StartActivity(typeof(MainActivity));
                    }
                }
            };
        }
    }
}