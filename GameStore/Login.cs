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

namespace GameStore
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        EditText usernametxt;
        EditText passwordtxt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            // Create your application here  

            usernametxt = FindViewById<EditText>(Resource.Id.textusername);
            passwordtxt = FindViewById<EditText>(Resource.Id.textpassword);

        }

    }
}