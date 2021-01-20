using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DoubleAnimation _animation;
        Storyboard _storyboard;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _storyboard = new Storyboard();
            _animation = new DoubleAnimation(1920, -1920, new Duration(new TimeSpan(0, 0, 15)));
            _storyboard.Children.Add(_animation);

            MessageText.RenderTransform = new TransformGroup
            {
                Children =
                {
                    new TranslateTransform()
                }
            };

            _animation.From = ActualWidth;
            _animation.To = -MessageText.ActualWidth;

            Storyboard.SetTarget(_animation, MessageText);
            Storyboard.SetTargetProperty(_animation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));
            _storyboard.Begin();
        }
    }
}
