using System;
using System.Collections.Generic;

namespace Project_ISP {
	static class DrinkList {
		public static List<Drink> AllDrinks = new List<Drink>() {
			new Drink("Test drink name", DrinkType.Hot | DrinkType.Iced | DrinkType.Cappuccino | DrinkType.Frapppuccino, true, true, "MyDrink", 500),
			new Drink("Caffe Mocha", DrinkType.Hot | DrinkType.Iced, true, true, "M", 5)
		};

		public static Drink GetRandomDrink() {
			var r = new Random();

			var drink = AllDrinks[r.Next(AllDrinks.Count)];

			#region Drink Type
			while (drink.CurrentDrinkType == 0) {
				switch (r.Next(4)) {
					case 0:
						if (drink.DrinkPossibilities.HasFlag(DrinkType.Hot)) {
							drink.CurrentDrinkType = DrinkType.Hot;
						}
						break;
					case 1:
						if (drink.DrinkPossibilities.HasFlag(DrinkType.Iced)) {
							drink.CurrentDrinkType = DrinkType.Iced;
						}
						break;
					case 2:
						if (drink.DrinkPossibilities.HasFlag(DrinkType.Cappuccino)) {
							drink.CurrentDrinkType = DrinkType.Cappuccino;
						}
						break;
					case 3:
						if (drink.DrinkPossibilities.HasFlag(DrinkType.Frapppuccino)) {
							drink.CurrentDrinkType = DrinkType.Frapppuccino;
						}
						break;
				}
			}
			#endregion

			#region Decaf
			switch (r.Next(2)) {
				case 0:
					drink.DecafBox = "1/2";
					break;
				case 1:
					drink.DecafBox = "X";
					break;
			}
			#endregion

			drink.Shots = (short)r.Next(3);

			#region Syrup
			int numSyrups = r.Next(3);
			for (int i = 0; i < numSyrups; i++) {
				switch (r.Next(16)) {
					case 0:
						drink.Syrups.Add("V");
						break;
					case 1:
						drink.Syrups.Add("H");
						break;
					case 2:
						drink.Syrups.Add("M");
						break;
					case 3:
						drink.Syrups.Add("WM");
						break;
					case 4:
						drink.Syrups.Add("CD");
						break;
					case 5:
						drink.Syrups.Add("TN");
						break;
					case 6:
						drink.Syrups.Add("P");
						break;
					case 7:
						drink.Syrups.Add("R");
						break;
					case 8:
						drink.Syrups.Add("CL");
						break;
					case 9:
						drink.Syrups.Add("CR");
						break;
					case 10:
						drink.Syrups.Add("SFV");
						break;
					case 11:
						drink.Syrups.Add("SFH");
						break;
					case 12:
						drink.Syrups.Add("SFCD");
						break;
					case 13:
						drink.Syrups.Add("SFC");
						break;
					case 14:
						drink.Syrups.Add("CH");
						break;
					case 15:
						drink.Syrups.Add("SFM");
						break;
				}
			}
#endregion

			#region Milk
			if (drink.CanMilk) {
				switch (r.Next(7)) {
					case 0:
						drink.MilkBox = "N";
						break;
					case 1:
						drink.MilkBox = "%";
						break;
					case 2:
						drink.MilkBox = "WH";
						break;
					case 3:
						drink.MilkBox = "HC";
						break;
					case 4:
						drink.MilkBox = "1/2";
						break;
					case 5:
						drink.MilkBox = "S";
						break;
				}
			}
			#endregion

			#region Custom
			switch (drink.CurrentDrinkType) {
				case DrinkType.Hot:

					break;
				case DrinkType.Iced:

					break;
				case DrinkType.Cappuccino:

					break;
				case DrinkType.Frapppuccino:

					break;
			}
			#endregion

			drink.Customs.Add("v");
			drink.Customs.Add("m");
			drink.Customs.Add("wm");
			drink.Customs.Add("h");

			return drink;
		}

		public static string ToFullName(string abbreviation) {
			switch (abbreviation.ToUpper()) {
				case "V": return "vanilla";
				case "M": return "mocha";
				case "WM": return "white mocha";
				case "H": return "hazelnut";
				case "CD": return "cinnamon dulce";
				case "TN": return "toffee nut";
				case "P": return "peppermint";
				case "R": return "raspberry";
				case "CL": return "classic";
				case "CR": return "caramel";
				case "CH": return "chai";
				case "SFV": return "sugar free vanilla";
				case "SFM": return "sugar free mocha";
				case "SFH": return "sugar free hazelnut";
				case "SFCD": return "sugar free cinnamon dulce";
				case "SFC": return "sugar free caramel";
				default: return "ERROR";
			}
		}
	}
}
