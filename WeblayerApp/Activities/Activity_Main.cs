using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

using WeblayerApp.Fragments;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Webkit;

namespace WeblayerApp.Activities
{
    [Activity(Label = "Home", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
    public class Activity_Main : Activity_Base
    {
        //WebView web_view;
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        Android.Support.V4.App.Fragment fragment;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_Main;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            drawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home_1:
                        ListItemClicked(0);
                        break;
                    case Resource.Id.nav_home_2:
                        ListItemClicked(1);
                        break;

                    case Resource.Id.nav_home_vendas:
                        ListItemClicked(2);
                        break;

                    case Resource.Id.nav_home_suporte:
                        ListItemClicked(3);
                        break;

                    case Resource.Id.nav_home_contato:
                        ListItemClicked(4);
                        break;
                }

                //Snackbar.Make(drawerLayout, "You selected: " + e.MenuItem.TitleFormatted, Snackbar.LengthLong)
                 //   .Show();

                drawerLayout.CloseDrawers();
            };


            //if first time you will want to go ahead and click first item.
            if (savedInstanceState == null)
            {
                ListItemClicked(0);
            }
        }

        int oldPosition = -1;
        private void ListItemClicked(int position)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (position == oldPosition)
                return;

            oldPosition = position;

            
            switch (position)
            {
                case 0:
                    fragment = Fragment_Noticia.NewInstance();
                    this.Title = "Home";
                    break;
                case 1:
                    fragment = Fragment_Embarcador.NewInstance();
                    this.Title = "w/embarcador";
                    break;

                case 2:
                    fragment = Fragment_Vendas.NewInstance();
                    this.Title = "w/vendas";
                    break;

                case 3:
                    fragment = Fragment_Suporte.NewInstance();
                    this.Title = "w/suporte";
                    break;

                case 4:
                    fragment = Fragment_Contato.NewInstance();
                    this.Title = "w/contato";
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        

    }
}

