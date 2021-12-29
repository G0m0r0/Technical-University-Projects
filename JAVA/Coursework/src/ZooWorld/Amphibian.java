package ZooWorld;

public abstract class Amphibian extends Animal {
	private String PreferedPlace = "";

	public Amphibian(String name, int bornYear, String preferedPlace) {
		super(name, bornYear);
		if (preferedPlace == "ground" || preferedPlace == "water")
			this.PreferedPlace = preferedPlace;
		else
			this.PreferedPlace = "neither";
	}

	public String PreferedPlace() {
		return this.PreferedPlace;
	}

	@Override
	public String toString() {
		return super.toString() + " This animal prefers " + this.PreferedPlace() + ".";
	}
}
