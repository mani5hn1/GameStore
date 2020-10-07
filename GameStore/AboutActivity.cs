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
using Xamarin.Essentials;

namespace GameStore
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        private Button _phoneButton;
        private Button _emailButton;
        private EditText _feedbackText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.about);
            // Create your application here
            FindViews();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _phoneButton.Click += _phoneButton_Click;
            _emailButton.Click += _emailButton_Click;
        }

        private async void _emailButton_Click(object sender, EventArgs e)
        {
            var message = new EmailMessage
            {
                Subject = "Feedback from GameStore",
                Body = _feedbackText.Text,
                To = new List<string> { "manishravji660@gmail.com" },
            };

          await Email.ComposeAsync(message);
        }

        private void _phoneButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse("tel:+1555779933"));
            intent.AddFlags(ActivityFlags.NewTask);
            StartActivity(intent);
        }

        private void FindViews()
        {
            _phoneButton = FindViewById<Button>(Resource.Id.phoneButton);
            _emailButton = FindViewById<Button>(Resource.Id.emailButton);
            _feedbackText = FindViewById<EditText>(Resource.Id.feedbackText);


        }
    }
}