using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OxyplotSlowAnnotation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<LineAnnotation> annotations = new List<LineAnnotation>();
        public MainPage()
        {
            this.InitializeComponent();

            for (int i = 0; i < 10; i++)
            {

                PlotView Plot = new PlotView();
                Plot.Height = 200;
                 var model = new PlotModel();

                model.Series.Add(new FunctionSeries(System.Math.Sin, 0, 10, 0.01, "sin(x)"));
                Plot.Model = model;

                var annotation = new LineAnnotation()
                {
                    Type = LineAnnotationType.Vertical,
                    ClipByXAxis = false,
                    X = 0,
                };
                Plot.Model.Annotations.Add(annotation);
                annotations.Add(annotation);
                stack.Children.Add(Plot);
            }

        }
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            foreach (var annotation in annotations)
            {
                annotation.X = e.NewValue;
                annotation.PlotModel.InvalidatePlot(false);
            }
        }
    }
}
