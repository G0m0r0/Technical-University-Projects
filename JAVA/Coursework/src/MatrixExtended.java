import java.util.Arrays;
import java.util.Scanner;

public class MatrixExtended {
	int[][] matrix;
	
	public MatrixExtended(int size) {
		this.matrix=new int[size][size];
	}
	
	
	
	public void DisplayMinMaxOfRow() {		
		int minElementOfRows = Arrays.stream(this.SumByRows())
			      .min()
			      .getAsInt();
		
		int maxElementOfRows = Arrays.stream(this.SumByRows())
			      .max()
			      .getAsInt();
		
		System.out.println("min by rows: "+minElementOfRows);
		System.out.println("max by rows: "+maxElementOfRows);
	}
	
	public void DisplayMinMaxOfColumn() {		
		int minElementOfColumn = Arrays.stream(this.SumByColumns())
			      .min()
			      .getAsInt();
		
		int maxElementOfColumn = Arrays.stream(this.SumByColumns())
			      .max()
			      .getAsInt();
		
		System.out.println("min by columns: "+minElementOfColumn);
		System.out.println("max by columns: "+maxElementOfColumn);
	}
	
	public int[] SumByRows() {
		int[] sumRows=new int[matrix[0].length];
		
		for(int i=0;i<matrix[0].length;i++) {
			 sumRows[i]= Arrays.stream(matrix[i])		               
		                .sum();
		}
		
		return sumRows;
	}
	
	public int[] SumByColumns() {
		int[] sumColumns=new int[matrix[0].length];
		
		for(int i=0;i<matrix[0].length;i++) {
			 for(int j=0;j<matrix[i].length;j++) {
				 sumColumns[i]+=matrix[j][i];
			 }
		}
		
		return sumColumns;
	}
	
	public int Sum() {
		int sum = Arrays.stream(matrix)
                .flatMapToInt(Arrays::stream)
                .sum();
		
		return sum;
	}
	
	public int[][] Fill() {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);		
		for(int i=0;i<matrix[0].length;i++){
			for(int j=0;j<matrix[i].length;j++) {
			    System.out.print("["+i+","+j+"]=");
				matrix[i][j]=scanner.nextInt();
			}
		}
		
		return matrix;
	}
	
	public void Print() {
		for(int i=0; i<this.matrix[0].length;i++) {
			for(int j=0;j<this.matrix[i].length;j++) {
				System.out.print(matrix[i][j]+" ");
			}
			System.out.println();
		}
	}
}
