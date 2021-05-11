package test;

import java.util.ArrayList;

public class Main {

	public static void main(String[] args) {
		ArrayList<Employee> listEmployee=new ArrayList<Employee>(5);
		listEmployee.add(new Employee("male","Bulgaria"));
		listEmployee.add(new Employee("female","France"));
		listEmployee.add(new Employee("female","USA"));
		listEmployee.add(new Employee("female","Canada"));
		listEmployee.add(new Employee("male","Bulgaria"));
		
		int count=0;
		for(int i=0;i<listEmployee.size();i++) {
			if(listEmployee.get(i).getSex()=="female") {
				count++;
			}
		}
		
		System.out.println(count);
	}

}
