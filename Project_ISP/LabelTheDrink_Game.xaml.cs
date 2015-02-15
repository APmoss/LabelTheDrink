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
using System.Windows.Threading;

namespace Project_ISP {
	/// <summary>
	/// Interaction logic for LabelTheDrink_Game.xaml
	/// </summary>
	public partial class LabelTheDrink_Game : Page {
		Drink drink;
		DispatcherTimer t = new DispatcherTimer();
		TimeSpan timeLeft = TimeSpan.FromMinutes(1);

		public LabelTheDrink_Game() {
			InitializeComponent();
		}

		private void Initialize(object sender, RoutedEventArgs e) {
			t = new DispatcherTimer();
			t.Interval = TimeSpan.FromSeconds(1);
			t.Tick += (se, ev) => {
				timeLeft -= TimeSpan.FromSeconds(1);
				TimeLeftBox.Text = timeLeft.Minutes + ":" + timeLeft.Seconds;
			};
			t.Start();
			drink = DrinkList.GetRandomDrink();

			SetOrderNameText();
		}

		protected void SetOrderNameText() {
			var t = string.Empty;

			switch (drink.Shots) {
				case 1: t += "Single shot ";
					break;
				case 2: t += "Double shot ";
					break;
				case 3: t += "Triple shot ";
					break;
			}

			if (drink.DecafBox == "1/2") {
				t += "Half-caff ";
			}
			else if (drink.DecafBox == "X") {
				t += "Decaf ";
			}
			if (drink.CurrentDrinkType == DrinkType.Iced) {
				t += "Iced ";
			}

			t += drink.Name;

			if (drink.Syrups.Count > 0) {
				t += ", with a pump of ";

				for (int i = 0; i < drink.Syrups.Count; i++) {
					t += DrinkList.ToFullName(drink.Syrups[i]);
					if (drink.Syrups.Count > 1 && i == drink.Syrups.Count - 2) {
						t += ", and ";
					}
					else if (i != drink.Syrups.Count - 1) {
						t += ", ";
					}
				}

				t += " syrup";
			}

			if (drink.CanMilk && drink.MilkBox != string.Empty) {
				t += ", " + DrinkList.ToFullName(drink.MilkBox) + " ";
				if (drink.MilkBox != "HC" && drink.MilkBox != "1/2") {
					t += "milk ";
				}
			}

			t += ", with ";
			if (drink.Sugars > 0) {
				t += drink.Sugars + " ";
			}
			t += DrinkList.ToFullName(drink.CustomBox);

			OrderName.Text = t;
		}

		private void Done(object sender, RoutedEventArgs e) {
			Initialize(null, null);
		}
	}
}
