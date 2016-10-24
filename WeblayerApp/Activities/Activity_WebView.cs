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
using WeblayerApp.Fragments;

namespace WeblayerApp.Activities
{
    [Activity(Label = "WebView", MainLauncher = false, Icon = "@drawable/Icon")]
    public class Activity_WebView : Activity
    {
        WebView web_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity_WebView);

            var url = Intent.GetStringExtra("url");
            if (url == null)
                return;

            web_view = FindViewById<WebView>(Resource.Id.webview1);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.LoadUrl(url);

            web_view.SetWebViewClient(new Webview());
            

        }
    }
}