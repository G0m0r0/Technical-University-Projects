
public class StartUp {

	public static void main(String[] args) {
		var student = new Student("021205000","Maria Petrova",4.76);
		var player = new Player("021203000","Ivan Yordanov",5.25,"Tenis",0); 
		
	 var students=new Student[2];
	 students[0]=student;
	 students[1]=player;

	 player.setPoints(50);
	 
	 System.out.println(students[0].getAvgGrades()+students[1].getAvgGrades());
	}

}
