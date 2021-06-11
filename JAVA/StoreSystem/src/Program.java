public class Program {

	public static void main(String[] args) {
		var computers=new Computer[2];
		
		computers[0]=new Computer("HP","USA",1800,80);
		computers[1]=new Computer("DELL","USA",1200,60);
		 
		for(int i=0;i<computers.length;i++) {
			System.out.println(computers[i].toString());
		}
		
		var firstComputer=computers[0].getScore()/computers[0].getPrice();
		var secondComputer=computers[1].getScore()/computers[1].getPrice();
		
		System.out.print("Better computer is: ");
		if(firstComputer<secondComputer) {
			System.out.println(computers[0].getName());
		}else
		{
			System.out.println(computers[1].getName());
		}		
	}

}
