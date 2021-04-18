package ZooWorld;

import java.util.Arrays;
import java.util.List;

import ZooWorld.Animals.Cat;
import ZooWorld.Animals.Dog;
import ZooWorld.Animals.Frog;
import ZooWorld.Animals.Jellyfish;
import ZooWorld.Animals.Lizzard;
import ZooWorld.Animals.Swallow;
import ZooWorld.Interfaces.IAnimal;
import ZooWorld.Interfaces.IBird;
import ZooWorld.Interfaces.IMammal;

public class Zoo {
	private static Animal[] arrayOfMammals = {
			new Dog("Rex",2020), 
		    new Cat("Garfield", 2010), 
		    new Frog("Pesho1",2019, "water"),
		    new Dog("TRex",2021), 
		    new Frog("Pesho2",2017, "neither"),
		    new Jellyfish("Nemo",2019),
		    new Swallow("AngryBird",2009),
		    new Lizzard("Oz",2002),
		};
		
	private static List<IAnimal> animalsList = Arrays.asList(arrayOfMammals);
	
	public static void DisplayAnimals() {
		for (IAnimal CurrentAnimal : animalsList) {
		    System.out.println(CurrentAnimal.toString());
		}
	}
		
		public static void FeedAllAnimals(double quantity) {
			for (IAnimal CurrentAnimal : animalsList) {
			    CurrentAnimal.FeedAnimal(quantity);
			}
	}
	
		public static void DisplayNameOfHungryAnimal() {
	    	System.out.println("Hungry animals: ");
			for (IAnimal CurrentAnimal : animalsList) {
			    if(CurrentAnimal.IsAnimalHungry()) {
			    	System.out.println(CurrentAnimal.GetName()+" ");
			    }
			}
		}
		
		public static void FeedHungryAnimals() {
			for (IAnimal CurrentAnimal : animalsList) {
			    if(CurrentAnimal.IsAnimalHungry()) {
			    	CurrentAnimal.FeedAnimal(100-CurrentAnimal.GetHunger());			   
			    }
			    
			    System.out.println(CurrentAnimal.GetName()+" is fed!");
			}
			System.out.println("All hungry animals are fed!");
		}
		
		public static void MakeSound() {			
			for (int i=0;i<animalsList.size();i++) {
				if(animalsList.get(i).getClass().getSuperclass().getSimpleName().equals("Mammal")) {					
					var animal = (IMammal)animalsList.get(i);
					System.out.println(animal.GetName()+"... "+ animal.Sound());
				}

			}
		}
		
		public static void PokeBirdsToFly() {			
			for (int i=0;i<animalsList.size();i++) {
				if(animalsList.get(i).getClass().getSuperclass().getSimpleName().equals("Bird")) {					
					var animal = (IBird)animalsList.get(i);
					System.out.println(animal.GetName()+"... "+ animal.PokeBirdToFly());
				}

			}
		}
}
