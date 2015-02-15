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
	/// Interaction logic for LabelTheDrink_Game.xaml
	/// </summary>
	public partial class LabelTheDrink_Game : Page {
		Drink drink;

		public LabelTheDrink_Game() {
			InitializeComponent();
		}

		private void Initialize(object sender, RoutedEventArgs e) {
			drink = DrinkList.GetRandomDrink();

			OrderName.Text = drink.Name;
			foreach (var custom in drink.Customs) {
				OrderName.Text += ", one pump " + DrinkList.ToFullName(custom);
			}
		}
	}
}
