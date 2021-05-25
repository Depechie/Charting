using System.ComponentModel;
using Xamarin.Forms;

namespace AreaLineWithPointer
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private LineData _lineData;
        public LineData LineData
        {
            get => _lineData;
            set
            {
                if (value != _lineData)
                {
                    _lineData = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isReserveVisible = false;
        public bool IsReserveVisible
        {
            get => _isReserveVisible;
            set
            {
                _isReserveVisible = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            InitData();

            BindingContext = this;
        }

        private void InitData()
        {
            GraphDataSerie series = new GraphDataSerie();

            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 4, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 5, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 6, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 7, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 8, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 9, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 10, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 11, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2016, 12, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 1, 1), Y = 492020.97 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 2, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 3, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 4, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 5, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 6, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 7, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 8, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 9, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 10, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 11, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2017, 12, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 1, 1), Y = 501395.22 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 2, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 3, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 4, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 5, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 6, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 7, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 8, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 9, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 10, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 11, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2018, 12, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 1, 1), Y = 508414.75 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 2, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 3, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 4, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 5, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 6, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 7, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 8, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 9, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 10, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 11, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2019, 12, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 1, 1), Y = 514261.52 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 2, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 3, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 4, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 5, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 6, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 7, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 8, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 9, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 10, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 11, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2020, 12, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2021, 1, 1), Y = 518632.74 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2021, 2, 1), Y = 523053.25 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2021, 3, 1), Y = 523053.25 });
            series.Data.Add(new GraphData() { X_DT = new System.DateTime(2021, 4, 1), Y = 523053.25 });

            LineData = new LineData() { GraphDataSerie = series };
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            IsReserveVisible = !IsReserveVisible;
        }
    }
}