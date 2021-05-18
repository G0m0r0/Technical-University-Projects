package ZooWorld;

import java.io.IOException;

public class StartUp2 {

	public static void main(String[] args) { 
		Zoo.DisplayAnimals();
		Zoo.FeedAllAnimals(20);		
		Zoo.DisplayNameOfHungryAnimal();		
		Zoo.FeedHungryAnimals();
		Zoo.MakeSound();
		Zoo.PokeBirdsToFly();
				
		 try {
				System.out.println(Zoo.WriteToFile());
				System.out.println(Zoo.ReadFromFile());
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	}

}
