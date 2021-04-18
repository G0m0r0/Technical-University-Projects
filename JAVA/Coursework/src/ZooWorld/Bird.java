package ZooWorld;

import ZooWorld.Interfaces.IBird;

public abstract class Bird extends Animal implements IBird{

	public Bird(String name, int bornYear) {
		super(name, bornYear);
		// TODO Auto-generated constructor stub
	}
	
	@Override
	public Boolean IsAnimalHungry() {
		if(this.Hunger<10) {
			return true;
		}
		
		return false;
	}

	public String PokeBirdToFly() {
		this.Hunger-=10;
		
		return " is flying";
	}
	
	

}
