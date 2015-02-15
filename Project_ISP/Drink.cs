using System;
using System.Collections.Generic;

namespace Project_ISP {
	public enum DrinkType : byte {
		Hot = 1, Iced = 2, Cappuccino = 4, Frapppuccino = 8
	}

	class Drink {
		public Drink(string name, DrinkType drinkPossibilities, bool canDecaf, bool canMilk, string drinkBox, int popularity) {
			this.Name = name;
			this.DrinkPossibilities = drinkPossibilities;
			this.CanDecaf = canDecaf;
			this.CanMilk = canMilk;
			this.DrinkBox = drinkBox;
		}

		public string Name = string.Empty;
		public DrinkType CurrentDrinkType = 0;
		public DrinkType DrinkPossibilities = 0;
		public bool CanDecaf = true;
		public string DecafBox = string.Empty;
		public short Shots = 0;
		public List<string> Syrups = new List<string>();
		public bool CanMilk = true;
		public string MilkBox = string.Empty;
		public string CustomBox = string.Empty;
		public int Sugars = 0;
		public string DrinkBox = string.Empty;
		public int popularity = 0;
	}
}
