package ZooWorld;

public abstract class Reptile extends Animal {

	public Reptile(String name, int bornYear) {
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

	@Override
    public String toString() {
		return super.toString()+ " "+"Like hot places";
    }
}
