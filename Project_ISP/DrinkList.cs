using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_ISP {
	static class DrinkList {
		public static List<Drink> AllDrinks = new List<Drink>() {
			new Drink("Test drink name", DrinkType.Hot | DrinkType.Iced | DrinkType.Cappuccino | DrinkType.Frapppuccino, true, true, "MyDrink", 500),
			new Drink("Caffe Latte", DrinkType.Hot | DrinkType.Iced, true, true, "L", 50),
			new Drink("Caffe Misto", DrinkType.Hot, true, true, "MIS", 50),
			new Drink("Cappuccino", DrinkType.Cappuccino, true, true, "C", 50),
			new Drink("Java Chip Frappuccino", DrinkType.Frapppuccino, true, true, "JCF", 50),
			new Drink("Caramel Frappuccino", DrinkType.Frapppuccino, true, true, "CRF", 50),
			new Drink("Mocha Frappuccino", DrinkType.Frapppuccino, true, true, "MF", 50),
			new Drink("Espresso", DrinkType.Hot | DrinkType.Iced, true, true, "E", 50),
			new Drink("Caffe Vanilla Frappuccino", DrinkType.Frapppuccino, true, true, "CVF", 50),
			new Drink("Espresso Frappuccino", DrinkType.Frapppuccino, true, true, "EF", 50),
			new Drink("Caramel Macchiato", DrinkType.Hot | DrinkType.Iced, true, true, "CM", 50),
			new Drink("Americano", DrinkType.Hot | DrinkType.Iced, true, true, "A", 50),
			new Drink("Espresso Macchiato", DrinkType.Hot, true, true, "EM", 50),
			new Drink("White Hot Chocolate", DrinkType.Hot, false, true, "WHC", 50),
			new Drink("Chai Tea Latte", DrinkType.Hot | DrinkType.Iced, true, true, "CH", 50),
			new Drink("White Mocha Frappuccino", DrinkType.Frapppuccino, true, true, "WMF", 50),
			new Drink("Coffee Frappuccino", DrinkType.Frapppuccino, true, true, "CF", 50),
			new Drink("Caffe Mocha", DrinkType.Hot | DrinkType.Iced, true, true, "CM", 50),
			new Drink("Green Tea", DrinkType.Hot | DrinkType.Iced, false, true, "GT", 50),
			new Drink("Green Tea Frappuccino", DrinkType.Frapppuccino, false, true, "GTF", 50),
			new Drink("Passion Tea Lemonade", DrinkType.Iced, false, false, "PTL", 50),
			new Drink("Vanilla Bean Frappuccino", DrinkType.Frapppuccino, false, true, "VBF", 50),
			new Drink("Cool Lime Refresher", DrinkType.Iced, false, false, "CLR", 50),
			new Drink("Berry Hibiscus Refresher", DrinkType.Iced, false, false, "BHR", 50),
			new Drink("Passion Tea", DrinkType.Iced, false, false, "PT", 50),
			new Drink("Black Tea", DrinkType.Iced, false, false, "BT", 50),
			new Drink("Strawberries n' Cream Frappuccino", DrinkType.Frapppuccino, false, true, "STCF", 50),
			new Drink("Green Tea Lemonade", DrinkType.Iced, false, false, "GTL", 50),
			new Drink("Caramel Apple Spice", DrinkType.Hot, false, false, "CAS", 50),
			new Drink("Double Chocolate Chip Frappuccino", DrinkType.Frapppuccino, false, true, "DCCF", 50),
			new Drink("Black Tea Lemonade", DrinkType.Iced, false, false, "BTL", 50),
			new Drink("Hot Chocolate", DrinkType.Hot, false, true, "HC", 50),
			new Drink("Green Tea Latte", DrinkType.Hot | DrinkType.Iced, false, true, "GRTL", 50)
		};

		public static Drink GetRandomDrink() {
			var r = new Random();

			var tmp = AllDrinks[r.Next(AllDrinks.Count)];
			var drink = new Drink(tmp.Name, tmp.DrinkPossibilities, tmp.CanDecaf, tmp.CanMilk, tmp.DrinkBox, tmp.popularity);

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
			if (drink.CanDecaf) {
				switch (r.Next(2)) {
					case 0:
						drink.DecafBox = "1/2";
						break;
					case 1:
						drink.DecafBox = "X";
						break;
				}
			}
			#endregion

			drink.Shots = (short)r.Next(3);

			#region Syrup
			int numSyrups = r.Next(4);
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

			drink.Syrups = drink.Syrups.Distinct().ToList();
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
					switch (r.Next(6)) {
						case 0: drink.CustomBox = "WC";
							break;
						case 1: drink.CustomBox = "XH";
							break;
						case 2: drink.CustomBox = "-F-";
							break;
						case 3: drink.CustomBox = "130";
							break;
						case 4: drink.CustomBox = "XCR";
							break;
						case 5: drink.CustomBox = "SUGAR";
							break;
					}
					break;
				case DrinkType.Iced:
					switch (r.Next(4)) {
						case 0: drink.CustomBox = "LTICE";
							break;
						case 1: drink.CustomBox = "XICE";
							break;
						case 2: drink.CustomBox = "WC";
							break;
						case 3: drink.CustomBox = "SUGAR";
							break;
					}
					break;
				case DrinkType.Cappuccino:
					switch (r.Next(4)) {
						case 0: drink.CustomBox = "XH";
							break;
						case 1: drink.CustomBox = "W";
							break;
						case 2: drink.CustomBox = "D";
							break;
						case 3: drink.CustomBox = "SUGAR";
							break;
					}
					break;
				case DrinkType.Frapppuccino:
					switch (r.Next(6)) {
						case 0: drink.CustomBox = "WC";
							break;
						case 1: drink.CustomBox = "-WC-";
							break;
						case 2: drink.CustomBox = "XWC";
							break;
						case 3: drink.CustomBox = "XCR";
							break;
						case 4: drink.CustomBox = "X2";
							break;
						case 5: drink.CustomBox = "SUGAR";
							break;
					}
					break;
			}

			if (drink.CustomBox == "SUGAR") {
				switch (r.Next(5)) {
					case 0: drink.CustomBox = "SP";
						break;
					case 1: drink.CustomBox = "SR";
						break;
					case 2: drink.CustomBox = "=";
						break;
					case 3: drink.CustomBox = "SL";
						break;
					case 4: drink.CustomBox = "HN";
						break;
				}

				drink.Sugars = r.Next(1, 6);
			}
			#endregion

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

				case "N": return "nonfat";
				case "%": return "2 percent";
				case "WH": return "whole";
				case "HC": return "heavy cream";
				case "1/2": return "half and half";
				case "S": return "soy";

				case "WC": return "whip cream";
				case "XH": return "extra hot temperature";
				case "-F-": return "no foam";
				case "130": return "childrens's temperature";
				case "XCR": return "extra caramel";
				case "SP": return "splenda packets";
				case "=": return "equals packets";
				case "SL": return "sweet n' low packets";
				case "SR": return "sugar in the raw packets";
				case "HN": return "honey packets";
				case "LTICE": return "light ice";
				case "XICE": return "extra ice";
				case "W": return "wet cappuccino style";
				case "D": return "dry cappuccino style";
				case "-WC-": return "no whip cream";
				case "XWC": return "extra whip cream";
				case "X2": return "it double blended";

				default: return "ERROR";
			}
		}
	}
}
