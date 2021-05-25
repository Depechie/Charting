using System;
using Xamarin.Forms;
using Steema.TeeChart;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace AreaLineWithPointer
{
    public class GraphData
    {
        public GraphData() { }

        public GraphData(double x, double y, string description = null)
        {
            X = x;
            Y = y;
            Description = description;
        }

        public GraphData(double x, double y, Color color, string description = null)
        {
            X = x;
            Y = y;
            Color = color;
            Description = description;
        }

        public string Description { get; set; }
        public Color Color { get; set; }
        public decimal Value { get; set; }

        public DateTime X_DT { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
    }

    public class GraphDataSerie
    {
        public GraphDataSerie()
        {
            Data = new List<GraphData>();
        }

        public string Description { get; set; }
        public List<GraphData> Data { get; set; }
    }

    public class LineData : INotifyPropertyChanged
    {
        public const string GraphDataSeriePropertyName = "GraphDataSerie";

        private GraphDataSerie _graphDataSerie;
        public GraphDataSerie GraphDataSerie
        {
            get => _graphDataSerie;
            set
            {
                if (value != _graphDataSerie)
                {
                    _graphDataSerie = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color Color { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class StockPriceLineGraph : ContentView
    {
        public Steema.TeeChart.ChartView AreaLineChart { get; } = new Steema.TeeChart.ChartView();

        public static readonly BindableProperty BottomIncrementProperty =
            BindableProperty.Create(nameof(BottomIncrement), typeof(int), typeof(StockPriceLineGraph), 1, propertyChanged: OnBottomIncrementPropertyChanged);

        public int BottomIncrement
        {
            get => (int)GetValue(BottomIncrementProperty);
            set => SetValue(BottomIncrementProperty, value);
        }

        public static readonly BindableProperty LineDataProperty =
            BindableProperty.Create(nameof(LineData), typeof(LineData), typeof(StockPriceLineGraph), null, propertyChanged: OnLineDataPropertyChanged);

        public LineData LineData
        {
            get => (LineData)GetValue(LineDataProperty);
            set => SetValue(LineDataProperty, value);
        }

        public static readonly BindableProperty MonthlyProperty =
            BindableProperty.Create(nameof(LineData), typeof(bool), typeof(StockPriceLineGraph), false, propertyChanged: OnMonthlyPropertyChanged);

        public bool Monthly
        {
            get => (bool)GetValue(MonthlyProperty);
            set => SetValue(MonthlyProperty, value);
        }

        private static void OnMonthlyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            StockPriceLineGraph me = (StockPriceLineGraph)bindable;

            var month = (bool)newValue;
            if (month)
            {
                me.AreaLineChart.Chart.Axes.Bottom.Increment = Utils.GetDateTimeStep(DateTimeSteps.OneMonth);
                me.AreaLineChart.Chart.Axes.Bottom.Labels.DateTimeFormat = "yy-MM";
            }
            else
            {
                me.AreaLineChart.Chart.Axes.Bottom.Increment = Utils.GetDateTimeStep(DateTimeSteps.OneYear);
                me.AreaLineChart.Chart.Axes.Bottom.Labels.DateTimeFormat = "yy";
            }
        }

        private static void OnLineDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            StockPriceLineGraph me = (StockPriceLineGraph)bindable;

            if (oldValue is LineData dataOld)
                me.UnregisterPropertyChanged();

            if (newValue is LineData dataNew)
            {
                me.RegisterPropertyChanged();
                me.DrawGraph();
            }
        }

        private static void OnBottomIncrementPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            StockPriceLineGraph me = (StockPriceLineGraph)bindable;

            if (newValue is int intValue)
            {
                me.AreaLineChart.Chart.Axes.Bottom.Increment = 365 * intValue;
            }
        }

        public StockPriceLineGraph()
        {
            AreaLineChart.Chart.Panning.Allow = Steema.TeeChart.ScrollModes.None;

            AreaLineChart.Chart.Panel.Gradient.Visible = false;
            AreaLineChart.Chart.Panel.Transparent = true;
            AreaLineChart.Chart.Panel.BackImageClear();

            AreaLineChart.Chart.Walls.Back.Visible = false;
            AreaLineChart.Chart.Header.Visible = false;
            AreaLineChart.Chart.Legend.Visible = false;
            AreaLineChart.Chart.Aspect.View3D = false;

            AreaLineChart.Chart.Axes.Bottom.Labels.Font.Brush.Color = Color.FromHex("#757575");
            AreaLineChart.Chart.Axes.Bottom.Labels.Font.Size = 12;
            AreaLineChart.Chart.Axes.Bottom.AxisPen.Visible = false;
            AreaLineChart.Chart.Axes.Bottom.Ticks.Length = Device.RuntimePlatform == Device.iOS ? 6 : 24;
            AreaLineChart.Chart.Axes.Bottom.Ticks.Color = Color.FromHex("#757575");
            AreaLineChart.Chart.Axes.Bottom.Ticks.Visible = true;

            if (Monthly)
            {
                AreaLineChart.Chart.Axes.Bottom.Increment = Utils.GetDateTimeStep(DateTimeSteps.OneMonth);
                AreaLineChart.Chart.Axes.Bottom.Labels.DateTimeFormat = "yy-MM";
            }
            else
            {
                AreaLineChart.Chart.Axes.Bottom.Increment = Utils.GetDateTimeStep(DateTimeSteps.OneYear);
                AreaLineChart.Chart.Axes.Bottom.Labels.DateTimeFormat = "yy";
            }

            AreaLineChart.Chart.Axes.Bottom.LabelsOnAxis = true;

            AreaLineChart.Chart.Axes.Left.Labels.Font.Brush.Color = Color.FromHex("#757575");
            AreaLineChart.Chart.Axes.Left.Labels.Font.Size = 12;
            AreaLineChart.Chart.Axes.Left.AxisPen.Visible = false;
            AreaLineChart.Chart.Axes.Left.MaximumOffset = 5;
            AreaLineChart.Chart.Axes.Left.MinimumOffset = 5;
            AreaLineChart.Chart.Axes.Left.Ticks.Length = 10;

            AreaLineChart.Chart.Panel.Brush.Solid = true;

            AreaLineChart.BackgroundColor = Color.Transparent;

            AreaLineChart.HorizontalOptions = LayoutOptions.FillAndExpand;
            AreaLineChart.VerticalOptions = LayoutOptions.FillAndExpand;

            AreaLineChart.WidthRequest = 1024;
            AreaLineChart.HeightRequest = 200;

            Content = new StackLayout
            {
                Children =
                  {
                    AreaLineChart
                  },
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
        }

        private void UnregisterPropertyChanged()
        {
            LineData.PropertyChanged -= OnDataInnerPropertyChanged;
        }

        private void RegisterPropertyChanged()
        {
            LineData.PropertyChanged += OnDataInnerPropertyChanged;
        }

        private void OnDataInnerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == LineData.GraphDataSeriePropertyName)
                DrawGraph();
        }

        private void DrawGraph()
        {
            AreaLineChart.Chart.Series.Clear();

            if (LineData.GraphDataSerie != null)
            {
                Steema.TeeChart.Styles.Area area = new Steema.TeeChart.Styles.Area();

                area.AreaBrush.Color = Color.FromHex("#BBC3D3"); // Color.Transparent; For a regular line graph
                area.AreaBrush.Solid = true; // false; For a regular line graph
                area.AreaBrush.Visible = true;
                area.AreaLines.Visible = false;

                area.Brush.Color = Color.FromHex("#BBC3D3"); // Color.Transparent; For a regular line graph
                area.Brush.Solid = true; // false; For a regular line graph

                area.Color = Color.FromHex("#BBC3D3");

                area.LinePen.Width = Device.RuntimePlatform == Device.iOS ? 2 : 8;
                area.LinePen.Color = Color.FromHex("#1D386D");
                area.LinePen.DashCap = Steema.TeeChart.Drawing.PenLineCap.Round;
                area.LinePen.EndCap = Steema.TeeChart.Drawing.PenLineCap.Round;

                area.Marks.Visible = false;

                if (LineData.GraphDataSerie != null)
                {
                    foreach (GraphData data in LineData.GraphDataSerie.Data)
                        area.Add((DateTime)data.X_DT, (double)data.Y);
                }

                //Due to how the default settings are for the area chart, we need to add extra min and max offset values
                //This to ensure that the bottom axes also shows the first and last value
                AreaLineChart.Chart.Axes.Bottom.MinimumOffset = 10;
                //AreaLineChart.Chart.Axes.Bottom.MaximumOffset = 10;

                area.XValues.DateTime = true;

                AreaLineChart.Chart.Series.Add(area);
            }
        }
    }
}
