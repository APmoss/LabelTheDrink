using System;
using System.Collections.Generic;

namespace Project_ISP {
	static class DrinkList {
		public static List<Drink> AllDrinks = new List<Drink>() {
			new Drink("Test drink name", DrinkType.Hot, true, true, "MyDrink", 500),
			new Drink("Caffe Mocha", DrinkType.Hot, true, true, "M", 5)
		};

		public static Drink GetRandomDrink() {
			var r = new Random();

			var drink = AllDrinks[r.Next(AllDrinks.Count)];

			switch (r.Next(2)) {
				case 0:
					drink.DecafBox = "1/2";
					break;
				case 1:
					drink.DecafBox = "X";
					break;
			}

			drink.Shots = (short)r.Next(3);

			int numSyrups = r.Next(3);
			#region Add Syrups
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

			return drink;
		}
	}
}
