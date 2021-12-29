public class RotateMatrix {
	/*Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4 
	bytes, write a method to rotate the image by 90 degrees. Can you do this in place? */

	public static void main(String[] args) {
		int n=5;
		var matrix=new int[][] {
										{1,2,3},
										{4,5,6},
										{7,8,9},
		};
		
		System.out.println(matrix.length);
		
		for (int i = 0; i < matrix.length; i++) {
			for (int j = 0; j < matrix[0].length; j++) {
				    //SWAP(matrix[i][j],matrix[j][matrix.length-1-i]);
				    matrix[i][j] = returnFirst(matrix[j][matrix.length-1-i], matrix[j][matrix.length-1-i] = matrix[i][j]); 
			}
		}
		
		for (int i = 0; i < matrix.length; i++) {
			for (int j = 0; j < matrix[0].length; j++) {
				    System.out.print(matrix[i][j]+" ");
			}
			System.out.println();
		}
	}

	private static void SWAP(Integer i, Integer j) {
		var swap=i;
		i=j;
		j=swap;		
	}
	
	static int returnFirst(int x, int y) {
	    return x;
	}

}
