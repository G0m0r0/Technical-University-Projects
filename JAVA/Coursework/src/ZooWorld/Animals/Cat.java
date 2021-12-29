package ZooWorld.Animals;
import ZooWorld.Mammal;

public class Cat extends Mammal{

	public Cat(String name, int bornYear) {
		super(name, bornYear);
		// TODO Auto-generated constructor stub
	}

	@Override
	public String Sound() {
		this.Hunger-=3;
		
		return "Meow! Meow!";
	}

}
