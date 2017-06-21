using Android.App;
using Android.Widget;
using Android.OS;

using System;
using Android.Content;

namespace Send_Email
{
    [Activity(Label = "Send Email", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var edtTo = FindViewById<EditText>(Resource.Id.edtTo);
            var edtSub = FindViewById<EditText>(Resource.Id.edtSubject);
            var edtMessage = FindViewById<EditText>(Resource.Id.edtMessage);
            var btnSend = FindViewById<Button>(Resource.Id.btnSend);


            btnSend.Click += (s, e) =>
            {
                Intent email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, new string[] { edtTo.Text.ToString() });
                email.PutExtra(Intent.ExtraSubject, edtSub.Text.ToString());
                email.PutExtra(Intent.ExtraText, edtMessage.Text.ToString());
                email.SetType("message/rfc822");
                StartActivity(Intent.CreateChooser(email, "Send Email Via"));
            };
            
        }
    }
}

