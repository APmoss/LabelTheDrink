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
using System.Windows.Shapes;

namespace Project_ISP {
	/// <summary>
	/// Interaction logic for LabelTheDrink.xaml
	/// </summary>
	public partial class LabelTheDrink : Window {
		public LabelTheDrink() {
			InitializeComponent();
		}

		private void StartGame(object sender, RoutedEventArgs e) {
			this.Content = new LabelTheDrink_Game();
		}
	}
}
