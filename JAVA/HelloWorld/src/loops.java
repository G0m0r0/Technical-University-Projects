import java.util.*; 

public class loops {

	public static void main(String[] args) {
		int i = 0;
		while (i < 5) {
		  System.out.println(i);
		  i++;
		}

		List<String> arr1 
        = new ArrayList<String>(); 
    arr1.add("Geeks"); 
    arr1.add("For"); 
    arr1.add("Geeks"); 

    arr1 
        .parallelStream() 
        .forEach( 
            s -> { 
                System.out.println(s); 
            }); 
	}

}
