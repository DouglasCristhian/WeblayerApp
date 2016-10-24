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
using Android.Webkit;
using WeblayerApp.Activities;

namespace WeblayerApp.Fragments
{
    [Activity(Label = "webview")]
    public class Webview : WebViewClient
    {

        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {

            Intent intent = new Intent();
            intent.SetClass(Application.Context, typeof(Activity_WebView));
            intent.SetFlags(ActivityFlags.NewTask);
            intent.PutExtra("url", url);
            Application.Context.StartActivity(intent);

            return true;

        }

        
    }
}