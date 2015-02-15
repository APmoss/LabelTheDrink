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
		Window parentWindow;
		int ordersLeft, scoreCorrect, scoreIncorrect;

		Drink drink;
		DispatcherTimer t = new DispatcherTimer();
		TimeSpan timeLeft = TimeSpan.FromMinutes(1);

		public LabelTheDrink_Game(Window parentWindow, int ordersLeft, int scoreCorrect, int scoreIncorrect) {
			InitializeComponent();

			this.parentWindow = parentWindow;

			this.ordersLeft = ordersLeft;
			this.scoreCorrect = scoreCorrect;
			this.scoreIncorrect = scoreIncorrect;
		}

		private void Initialize(object sender, RoutedEventArgs e) {
			t.Stop();
			t = new DispatcherTimer();
			t.Interval = TimeSpan.FromSeconds(1);
			t.Tick += (se, ev) => {
				if (timeLeft.TotalSeconds > 0) {
					timeLeft -= TimeSpan.FromSeconds(1);
				}
				else {
					CheckLabels();
					DoneButton.IsEnabled = false;
					NextButton.IsEnabled = true;
					t.Stop();
				}
				TimeLeftBox.Text = timeLeft.Minutes + ":" + timeLeft.Seconds;
			};
			t.Start();

			OrdersLeftBox.Text = ordersLeft.ToString();
			CorrectScoreBox.Text = scoreCorrect.ToString();
			IncorrectScoreBox.Text = scoreIncorrect.ToString();

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

		protected void CheckLabels() {
			bool perfect = true;

			if (DecafBox.Text.Trim().ToUpper() != drink.DecafBox) {
				DecafCorrect.Foreground = Brushes.Red;
				DecafCorrect.Text = drink.DecafBox;

				perfect = false;
			}
			else {
				DecafCorrect.Foreground = Brushes.Green;
				DecafCorrect.Text = "Correct";
			}

			if (drink.Shots > 0 && ShotsBox.Text.Trim() != drink.Shots.ToString()) {
				ShotsCorrect.Foreground = Brushes.Red;
				ShotsCorrect.Text = drink.Shots.ToString();

				perfect = false;
			}
			else {
				ShotsCorrect.Foreground = Brushes.Green;
				ShotsCorrect.Text = "Correct";
			}

			SyrupCorrect.Text = string.Empty;
			var syrupInputs = SyrupBox.Text.Trim().ToUpper().Split(' ');
			foreach (var syrup in drink.Syrups) {
				if (!syrupInputs.Contains(syrup)) {
					SyrupCorrect.Foreground = Brushes.Red;
					SyrupCorrect.Text += syrup + " ";

					perfect = false;
				}
			}
			if (SyrupCorrect.Text == string.Empty) {
				SyrupCorrect.Foreground = Brushes.Green;
				SyrupCorrect.Text = "Correct";
			}

			if (MilkBox.Text.Trim().ToUpper() != drink.MilkBox) {
				MilkCorrect.Foreground = Brushes.Red;
				MilkCorrect.Text = drink.MilkBox;

				perfect = false;
			}
			else {
				MilkCorrect.Foreground = Brushes.Green;
				MilkCorrect.Text = "Correct";
			}

			if (drink.Sugars > 1) {
				if (CustomBox.Text.Trim().ToUpper() != drink.Sugars + drink.CustomBox) {
					CustomCorrect.Foreground = Brushes.Red;
					CustomCorrect.Text = drink.Sugars + drink.CustomBox;

					perfect = false;
				}
				else {
					CustomCorrect.Foreground = Brushes.Green;
					CustomCorrect.Text = "Correct";
				}
			}
			else if (CustomBox.Text.Trim().ToUpper() != drink.CustomBox) {
				CustomCorrect.Foreground = Brushes.Red;
				CustomCorrect.Text = drink.CustomBox;

				perfect = false;
			}
			else {
				CustomCorrect.Foreground = Brushes.Green;
				CustomCorrect.Text = "Correct";
			}

			if (DrinkBox.Text.Trim().ToUpper() != drink.DrinkBox) {
				DrinkCorrect.Foreground = Brushes.Red;
				DrinkCorrect.Text = drink.DrinkBox;

				perfect = false;
			}
			else {
				DrinkCorrect.Foreground = Brushes.Green;
				DrinkCorrect.Text = "Correct";
			}

			if (perfect) {
				scoreCorrect++;
				CorrectScoreBox.Text = scoreCorrect.ToString();
			}
			else {
				scoreIncorrect++;
				IncorrectScoreBox.Text = scoreIncorrect.ToString();
			}
		}

		private void Done(object sender, RoutedEventArgs e) {
			t.Stop();
			CheckLabels();
			DoneButton.IsEnabled = false;
			NextButton.IsEnabled = true;
		}

		private void Next(object sender, RoutedEventArgs e) {
			if (ordersLeft != 0) {
				parentWindow.Content = new LabelTheDrink_Game(parentWindow, ordersLeft - 1, scoreCorrect, scoreIncorrect);
			}
			else {
				parentWindow.Content = new LabelTheDrink_End(parentWindow, scoreCorrect, scoreIncorrect);
			}
		}
	}
}
