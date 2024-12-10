using Syncfusion.Maui.Maps;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MostSkysCrapers
{
    public class SkysCrapersData : INotifyPropertyChanged
    {
        public ObservableCollection<SkysCrapersModel> Data { get; set; }

        public ObservableCollection<Brush> CustomBrushes { get; set; }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    UpdateIndex();
                    OnPropertyChanged(nameof(SelectedIndex));
                }
            }
        }

        private string? _selectedCityImage;

        public string? SelectedCityImage
        {
            get => _selectedCityImage;
            set
            {
                _selectedCityImage = value;
                OnPropertyChanged(nameof(SelectedCityImage));
            }
        }

        private string? _selectedCityName;

        public string? SelectedCityName
        {
            get => _selectedCityName;
            set
            {
                _selectedCityName = value;
                OnPropertyChanged(nameof(SelectedCityName)); 
            }
        }

        private string? _selectedCountryName;

        public string? SelectedCountryName
        {
            get => _selectedCountryName;
            set
            {
                _selectedCountryName = value;
                OnPropertyChanged(nameof(SelectedCountryName));
            }
        }

        private int _selectedCityCount;

        public int SelectedCityCount
        {
            get => _selectedCityCount;
            set
            {
                _selectedCityCount = value;
                OnPropertyChanged(nameof(SelectedCityCount));
            }
        }

        private MapMarkerCollection? _mapMarkerCollection;

        public MapMarkerCollection? MapMarkerCollection
        {
            get => _mapMarkerCollection;
            set
            {
                _mapMarkerCollection = value;
                OnPropertyChanged(nameof(MapMarkerCollection));
            }
        }

        public SkysCrapersData()
        {
            Data = new ObservableCollection<SkysCrapersModel>
            {
                new SkysCrapersModel { City = "Hong-Kong", Country = "Hong Kong", Count = 558 },
                new SkysCrapersModel { City = "Shenzhen", Country = "China", Count = 415 },
                new SkysCrapersModel { City = "New York", Country = "US", Count = 318 },
                new SkysCrapersModel { City = "Dubai", Country = "UAE", Count = 263 },
                new SkysCrapersModel { City = "Guangzhou", Country = "China", Count = 194 },
                new SkysCrapersModel { City = "Shanghai", Country = "China", Count = 194 },
                new SkysCrapersModel { City = "Kuala Lumpur", Country = "Malaysia", Count = 179 },
                new SkysCrapersModel { City = "Tokyo", Country = "Japan", Count = 176 },
                new SkysCrapersModel { City = "Wuhan", Country = "China", Count = 169 },
                new SkysCrapersModel { City = "Chongqing", Country = "China", Count = 145 },
            };

            CustomBrushes = new ObservableCollection<Brush>()
            {
                  new SolidColorBrush(Color.FromArgb("#9e0142")), 
                  new SolidColorBrush(Color.FromArgb("#d53e4f")), 
                  new SolidColorBrush(Color.FromArgb("#f46d43")), 
                  new SolidColorBrush(Color.FromArgb("#fdae61")), 
                  new SolidColorBrush(Color.FromArgb("#fee08b")), 
                  new SolidColorBrush(Color.FromArgb("#e6f598")),
                  new SolidColorBrush(Color.FromArgb("#abdda4")), 
                  new SolidColorBrush(Color.FromArgb("#66c2a5")), 
                  new SolidColorBrush(Color.FromArgb("#3288bd")), 
                  new SolidColorBrush(Color.FromArgb("#5e4fa2")), 
            };

            MapMarkerCollection = new MapMarkerCollection();
            SelectedIndex = 1;
        }

        private void UpdateIndex()
        {
            var selectedCity = Data.ElementAtOrDefault(SelectedIndex);
            if (selectedCity != null)
            {
                SelectedCityName = selectedCity.City;
                SelectedCountryName = selectedCity.Country;
                SelectedCityCount = selectedCity.Count;
                SelectedCityImage = $"{selectedCity.Country?.ToLower().Replace(" ", "_")}.png";
             
                MapMarkerCollection?.Clear(); 

                var marker = selectedCity.City switch
                {
                    "Hong-Kong" => new MapMarker { Latitude = 22.3193, Longitude = 114.1694 },
                    "Shenzhen" => new MapMarker { Latitude = 22.5429, Longitude = 114.0596 },
                    "New York" => new MapMarker { Latitude = 40.7128, Longitude = 74.0060 },
                    "Dubai" => new MapMarker { Latitude = 25.2048, Longitude = 55.2708 },
                    "Guangzhou" => new MapMarker { Latitude = 23.1291, Longitude = 113.2644 },
                    "Shanghai" => new MapMarker { Latitude = 31.2304, Longitude = 121.4737 },
                    "Kuala Lumpur" => new MapMarker { Latitude = 3.1499, Longitude = 101.6945 },
                    "Tokyo" => new MapMarker { Latitude = 35.6764, Longitude = 139.6500 },
                    "Wuhan" => new MapMarker { Latitude = 30.5928, Longitude = 114.3052 },
                    "Chongqing" => new MapMarker { Latitude = 29.5657, Longitude = 106.5512 },
                    _ => null
                };

                if (marker != null)
                {
                    MapMarkerCollection?.Add(marker);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}