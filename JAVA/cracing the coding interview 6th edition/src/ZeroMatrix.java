import java.util.HashMap;

public class ZeroMatrix {
	// Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and 
	// column are set to 0. 

	public static void main() {

		var matrix=new int[][] {
										{1,2,3},
										{4,0,6},
										{0,8,9},
		};
		
		var map=new HashMap<Integer,Integer>();
		
		for (int i = 0; i < matrix.length; i++) {
			for (int j = 0; j < matrix[i].length; j++) {
				if(matrix[i][j]==0) {
					map.put(i, j);
				}
			}
		}
		
		
		System.out.println("Normal Price: " + map);

	}

}
