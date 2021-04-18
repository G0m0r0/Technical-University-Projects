package ZooWorld;
import java.time.Year;

import ZooWorld.Interfaces.IAnimal;

public abstract class Animal implements IAnimal{
	protected int Age=0;
	protected String Name="";
	protected double Hunger=10; //default value 10
		
	public Animal(String name, int bornYear ) {		
		this.Age =  Year.now().getValue() - bornYear;
		this.Name=name;
	}
	
	public String FeedAnimal(double amountFood) {
		
		if(this.Hunger>100) {
			return "Animal will die if you give it "+amountFood+"kg.";
		}
		
		this.Hunger+=amountFood;
		
		return "Successfully fed "+this.Name;
	}
	
	public double GetHunger() {
		return this.Hunger;
	}
	
	public Boolean IsAnimalHungry() {
		if(this.Hunger<30) {
			return true;
		}
		
		return false;
	}
	
	public String GetName() {
		return this.Name;
	}
	
	@Override
    public String toString() {
        return String.format(this.Name+" is "+
        		(this.Age<=1?(this.Age+" year old. "):(this.Age+" years old. "))+
        		"The "+this.getClass().getSuperclass().getSimpleName()+" is "+(this.IsAnimalHungry()?"hungry!":"not hungry."));
    }
	
}

