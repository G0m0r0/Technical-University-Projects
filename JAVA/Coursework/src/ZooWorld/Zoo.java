package ZooWorld;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
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
	private static String fileName="zooWorld.txt";
	
	private static Animal[] arrayOfAnimals = {
			new Dog("Rex",2020), 
		    new Cat("Garfield", 2010), 
		    new Frog("Pesho1",2019, "water"),
		    new Dog("TRex",2021), 
		    new Frog("Pesho2",2017, "neither"),
		    new Jellyfish("Nemo",2019),
		    new Swallow("AngryBird",2009),
		    new Lizzard("Oz",2002),
		};
		
	private static List<IAnimal> animalsList = Arrays.asList(arrayOfAnimals);
	static List<IAnimal> animals = new ArrayList<>();

	
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
		
		public static String WriteToFile() throws IOException {
			StringBuilder sb = new StringBuilder(); 

	        sb.append("Dog Rex 2020\n");
	        sb.append("Cat Garfield 2010\n");
	        sb.append("Frog Pesho1 2019 water\n");
	        sb.append("Dog TRex 2021\n");
	        sb.append("Frog Pesho2 2017 neither\n");
	        sb.append("Jellyfish Nemo 2019\n");
	        sb.append("Swallow AngryBird 2009\n");
	        sb.append("Lizzard Oz 2002\n");
	        
	        File yourFile = new File(fileName);
	        yourFile.createNewFile();

	        Path path = Paths.get("D:\\Programming\\University\\JAVA\\Coursework\\"+fileName); 

	        Files.write(path, sb.toString().getBytes());         		

			
			return "Animals are saved to file!";
		}
		
		public static String ReadFromFile() throws IOException {
			int i = 0;
			FileInputStream file = null;
			file = new FileInputStream(fileName);

			StringBuilder sb=new StringBuilder();

			do {
				i = file.read();
			     sb.append((char) i);
			   } while(i != -1);

			   file.close();
			   
			   var arrayOfObjectsString=sb.toString().split("\n");
			   
			   for(int j=0;j<arrayOfObjectsString.length;j++) {
				   var tokens=arrayOfObjectsString[j].split(" ");
				   
				   IAnimal animal = null;
				   
				   switch(tokens[0]) {
				   case "Cat":
					   animal=new Cat(tokens[1],Integer. parseInt(tokens[2]));
				     break;
				   case "Dog":
					   animal=new Dog(tokens[1],Integer. parseInt(tokens[2]));
				     break;
				   case "Frog":
					   animal=new Frog(tokens[1],Integer. parseInt(tokens[2]),tokens[3]);
					     break;
				   case "Jellyfish":
					   animal=new Jellyfish(tokens[1],Integer. parseInt(tokens[2]));
					     break;
				   case "Lizzard":
					   animal=new Lizzard(tokens[1],Integer. parseInt(tokens[2]));
					     break;
				   case "Swallow":
					   animal=new Swallow(tokens[1],Integer. parseInt(tokens[2]));
					     break;
				 }
				   
				   animals.add(animal);
			   }
			   
			   return "Animals were read from file!";
		}
}
