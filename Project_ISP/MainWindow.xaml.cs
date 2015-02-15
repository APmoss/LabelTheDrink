using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using System.IO;

namespace Project_ISP {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			/* Sami, Laura, Clair, Cole, Gus, Konrad
			 * Hot - WC, XH, F(strikethrough), 130(degrees), XCR, SP, SR, =, SL, HN
			 * Cold - LTICE, XICE, WC, SP, SR, =, SL, HN
			 * Cappuccino - XH, W, D, SP, SR, =, SL, HN
			 * Frappuccino - WC, XCR, WC(strikethrough), XWC, X2, SP, SR, =, SL, HN
			 */

			/*WC - Whip Cream
			 * XH - Xtra Hot
			 * F(str) - no foam
			 * 130(deg) - 130 degrees
			 * XCR - Xtra Caramel
			 * SP - splenda
			 * = - Equals
			 * SL - Sweet n Low
			 * HN - Honey
			 * LTICE - Light Ice
			 * XICE - Xtra Ice
			 * W - Wet
			 * D - Dry
			 * WC(Str) - No whip cream
			 * XWC - Xtra whip cream
			 * X2 - double blended
			 * 
			 * Syrups:
			 * V - Vanilla
			 * H - Hazelnut
			 * M - Mocha
			 * WM - White Mocha
			 * CD - Cinnamon Dulce
			 * TN - Toffee Nut
			 * P - Peppermint
			 * R - Raspberry
			 * CL - Classic
			 * CR - Caramel
			 * SFV - Sugar free vanilla
			 * SFH
			 * SFCD
			 * SFC
			 * CH - Chai
			 * SFM
			 */
		}

		private void SelectionChanged(object sender, SelectionChangedEventArgs e) {
			var item = ProgramList.SelectedItem as ListBoxItem;

			switch ((string)item.Content) {
				case "Label the Drink":
					Description.Text = "Enter the correct labels on the cup to gather the most points.";
					break;
			}
		}

		private void Launch(object sender, RoutedEventArgs e) {
			if (ProgramList.SelectedItem != null) {
				var item = ProgramList.SelectedItem as ListBoxItem;

				switch ((string)item.Content) {
					case "Label the Drink":
						var l = new LabelTheDrink();
						App.Current.MainWindow = l;
						this.Close();
						l.Show();
						break;
				}
			}
		}
	}
}
