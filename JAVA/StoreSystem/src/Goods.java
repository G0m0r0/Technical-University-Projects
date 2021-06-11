
public class Goods {
	private String name;
	private String countryOfProduction;
	private double price;
	
	public Goods(String name, String countryOfProduction, double price) {
		this.setName(name);
		this.setCountryOfProduction(countryOfProduction);
		this.setPrice(price);
	}
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getCountryOfProduction() {
		return countryOfProduction;
	}
	public void setCountryOfProduction(String countryOfProduction) {
		this.countryOfProduction = countryOfProduction;
	}
	public double getPrice() {
		return price;
	}
	public void setPrice(double price) {
		this.price = price;
	}
}
