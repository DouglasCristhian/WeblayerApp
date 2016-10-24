using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Webkit;


namespace WeblayerApp.Fragments
{
    public class Fragment_Noticia:Fragment
    {
        WebView web_view;
        View View;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View = inflater.Inflate(Resource.Layout.Fragment_Noticia, null);

            web_view = View.FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.LoadUrl("http://www.weblayer.com.br/noticias-mobile/");

            web_view.SetWebViewClient(new webview());

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return View;
        }

        

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

          

        }


        public static Fragment_Noticia NewInstance()
        {
            var frag1 = new Fragment_Noticia { Arguments = new Bundle() };
            return frag1;
        }


       

        

    }
}