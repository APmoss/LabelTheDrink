using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_ISP {
	/// <summary>
	/// Interaction logic for LabelTheDrink_End.xaml
	/// </summary>
	public partial class LabelTheDrink_End : Page {
		Window parentWindow;

		public LabelTheDrink_End(Window parentWindow, int scoreCorrect, int scoreIncorrect) {
			InitializeComponent();

			this.parentWindow = parentWindow;
			Correct.Text += scoreCorrect.ToString();
			Incorrect.Text += scoreIncorrect.ToString();
		}

		private void Back(object sender, RoutedEventArgs e) {
			var l = new LabelTheDrink();
			App.Current.MainWindow = l;
			parentWindow.Close();
			l.Show();
		}
	}
}
