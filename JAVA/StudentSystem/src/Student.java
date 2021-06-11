
public class Student {
	public String FacultyNum;
	public String Name;
	private double AvgGrades;
	
	public Student(String facultyNum, String name, double avgGrades) {
		this.FacultyNum=facultyNum;
		this.Name=name;
		this.setAvgGrades(avgGrades);
	}

	public double getAvgGrades() {
		return AvgGrades;
	}

	public void setAvgGrades(double avgGrades) {
		AvgGrades = avgGrades;
	}
	
	@Override
    public String toString() {
		return "Student "+this.Name+" with faculty number: "+this.FacultyNum+" has averag grade "+this.getAvgGrades()+".";
    }
}
