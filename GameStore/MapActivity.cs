using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V7.App;

namespace GameStore
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : AppCompatActivity, IOnMapReadyCallback
    {
        private readonly LatLng _gameStoreLocation = new LatLng(51.5459, -0.2212);
        GoogleMap _googleMap;

        public void OnMapReady(GoogleMap map)
        {
            _googleMap = map;

            _googleMap.UiSettings.ZoomControlsEnabled = true;
            _googleMap.UiSettings.CompassEnabled = true;
            _googleMap.UiSettings.MyLocationButtonEnabled = false;
            AddMarker();
        }

        [System.Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnCreate(Bundle bundle)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.game_map);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

        void AddMarker()
        {
            var marker = new MarkerOptions();
            marker.SetPosition(_gameStoreLocation)
                               .SetTitle("Game Store");
            _googleMap.AddMarker(marker);

            var cameraUpdate = CameraUpdateFactory.NewLatLngZoom(_gameStoreLocation, 15);
            _googleMap.MoveCamera(cameraUpdate);
        }
    }
}