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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
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
