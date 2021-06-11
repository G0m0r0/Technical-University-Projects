
public class Computer extends Goods{
	private int efficiencyInPoint;

	public Computer(String name, String countryOfProduction, double price, int efficiency ) {
		super(name, countryOfProduction, price);
		this.setScore(efficiency);
	}

	public int getScore() {
		return efficiencyInPoint;
	}

	public void setScore(int efficiencyInPoint) {
		this.efficiencyInPoint = efficiencyInPoint;
	}
	
	@Override
    public String toString() {
		return "Name: "+this.getName()+
				"\nCountry of production: "+this.getCountryOfProduction()+
				"\nPrice: "+this.getPrice()+
				"\nEfficiency: "+this.getScore()+"\n";
    }
}
