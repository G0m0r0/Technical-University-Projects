/package test;

public class Employee implements Person{

	public String Country="";
	public String Sex="";
	
	public Employee(String sex, String country) {
		this.Country=country;
		this.Sex=sex;
	}
	
	@Override
	public String getSex() {		
		return this.Sex;
	}
	

}
