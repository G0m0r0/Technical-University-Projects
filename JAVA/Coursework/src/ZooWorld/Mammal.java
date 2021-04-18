package ZooWorld;

import ZooWorld.Interfaces.IMammal;

public abstract class Mammal extends Animal implements IMammal {

	public Mammal(String name, int bornYear) {
		super(name, bornYear);
		// TODO Auto-generated constructor stub
	}

	public String PetAnimal() {
		return this.getClass().getSimpleName()+" "+this.Name+" is happy that you pet it!";
	}
	
	public String IsMammalBaby() {
		if(this.Age<1) {
			return "Baby needs milk!";
		}
		
		return "Mammal is adult.";
	}
	
	@Override
    public String toString() {
		return super.toString()+ " "+this.IsMammalBaby();
    }

	@Override
	public String Sound() {		
		return "Mammals makes sound!";
	}
}
