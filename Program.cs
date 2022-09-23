using System;
using System.Collections.Generic;
using System.Linq;

/*
 * You are a zookeeper tasked with walking and feeding the animals.
 * The animals must be walked and then fed the proper food for their diet
 * until their hunger level reaches 0
 *
 */

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Time to feed my animals");
		
		var animals = new List<Object>();
		
		animals.Add(new Lion());
		animals.Add(new Giraffe());
		
		var backpack = new List<Food>();
		backpack.Add(new Meat());
		backpack.Add(new Grass());
	
		foreach (var animal in animals) {
			if (animal.GetType() == typeof(Lion)) {
				((Lion)animal).Walk();
			}
			else {
				((Giraffe)animal).Walk();
			}
			
			foreach (var food in backpack) {
				if (food is Meat meat) {
				  	if (animal.GetType() == typeof(Lion)) {
						var lion = (Lion)animal;
						while (lion.HungerLevel > 0) {
							lion.Eat(meat);
						}
					}
				}
				else if (food is Grass grass) {
					if (animal.GetType() == typeof(Giraffe)) {
						var giraffe = (Giraffe)animal;
						while (giraffe.HungerLevel > 0) {
							giraffe.Eat(grass);
						}
					}
				}
			}
		}
		
		foreach(var animal in animals){
			int hungerLevel = -1;
			
			if(animal.GetType() == typeof(Lion)){
				hungerLevel = ((Lion)animal).HungerLevel;
			}
			else if(animal.GetType() == typeof(Giraffe)){
				hungerLevel = ((Giraffe)animal).HungerLevel;
			}
			
			Console.WriteLine(animal.GetType().ToString() + " has hunger: " + hungerLevel);
		}
		
		
	}
}

public abstract record Food;

public record Meat : Food;

public record Grass : Food;

public class Lion {
	public int HungerLevel = 0;
	
	public void Walk() {
		HungerLevel += 10;
	}
	
	public void Eat(Meat meat) {
	  	HungerLevel -= 10;
		Console.WriteLine("Crunch chrunch");
	}
}
						
public class Giraffe {
	public int HungerLevel = 0;
	
	public void Walk() {
		HungerLevel += 20;
	}
	
	public void Eat(Grass grass) {
	  	HungerLevel -= 5;
		Console.WriteLine("Nom nom");
	}
}