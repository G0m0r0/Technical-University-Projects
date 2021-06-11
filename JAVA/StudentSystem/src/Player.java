
public class Player extends Student{

	public String NameOfSport;
	private int WonPoints;
	
	public Player(String facultyNum, String name, double avgGrades, String nameOfSport, int wonPoints) {
		super(facultyNum, name, avgGrades);


		this.NameOfSport=nameOfSport;
		this.setPoints(wonPoints);
	}

	public int getPoints() {
		return WonPoints;
	}

	public void setPoints(int wonPoints) {
		WonPoints = wonPoints;
	}
	
	@Override
    public String toString() {
		return super.toString()+ "Has "+this.getPoints()+"in sport "+this.NameOfSport;
    }
}
