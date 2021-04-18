package ZooWorld.Animals;
import ZooWorld.Mammal;

public class Dog extends Mammal{

	public Dog(String name, int bornYear) {
		super(name, bornYear);
		// TODO Auto-generated constructor stub
	}

	@Override
	public String Sound() {		
		this.Hunger-=5;
		
		return "Bark! Bark!";
	}

}
