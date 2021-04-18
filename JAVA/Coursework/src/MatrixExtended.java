import java.util.Arrays;
import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;

public class MatrixExtended {
	int[][] matrix;
	String fileName="test.txt";
	
	public MatrixExtended(int size) {
		this.matrix=new int[size][size];
	}
	
	public String WriteToFile() throws IOException {
		StringBuilder sb = new StringBuilder(); 

        for (int[] int1 : matrix) {
            for (int j = 0; j < int1.length; j++) {
                sb.append(int1[j]).append(' '); 
            }
            sb.append("\r\n"); 
        }
        
        File yourFile = new File(this.fileName);
        yourFile.createNewFile();

        Path path = Paths.get("D:\\Programming\\University\\JAVA\\Coursework\\"+this.fileName); 

        Files.write(path, sb.toString().getBytes());         		

		
		return "Matrix is saved to file!";
	}
	
	public int[][] ReadFromFile() throws IOException {
		int i = 0;
		FileInputStream file = null;
		file = new FileInputStream(this.fileName);

		StringBuilder sb=new StringBuilder();

		do {
			i = file.read();
		     sb.append((char) i);
		   } while(i != -1);

		   file.close();
		   
		   System.out.println("Matrix read from file is:");
		   System.out.println(sb.toString());
		   
		   //TODO: convert sb to matrix

		   return matrix;
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
