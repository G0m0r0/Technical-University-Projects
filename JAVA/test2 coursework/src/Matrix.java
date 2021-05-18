import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.Scanner;

public class Matrix {
	int[][] myMatrix;
	int[] b;
	int[] c;
	
	public Matrix(int m) {
		myMatrix=new int[m][m];
		b=new int[myMatrix.length];
		c=new int[myMatrix.length];
	}
	
	public int[][] setMatrix() {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);		
		for(int i=0;i<myMatrix[0].length;i++){
			for(int j=0;j<myMatrix[i].length;j++) {
				myMatrix[i][j]=scanner.nextInt();
			}
		}
		
		return myMatrix;
	}
	
	public void GetElementsAsTable() {
		System.out.println("-------");
		for(int i=0; i<myMatrix[0].length;i++) {
			System.out.print("|");
			for(int j=0;j<myMatrix[i].length;j++) {
				System.out.print(myMatrix[i][j]+"| ");
			}
			System.out.println();
		}
		System.out.println("-------");
	}
	
	public void SumMatrix() {
		
		var sum=0;
		for(int i=0; i<myMatrix[0].length;i++) {
			for(int j=0;j<myMatrix[i].length;j++) {
				sum+=myMatrix[i][j];
			}
		}
		
		System.out.println("Sum is "+sum);
	}
	
	public void SumByRows() {	
		for(int i=0;i<myMatrix[0].length;i++) {
			for(int j=0;j<myMatrix[i].length;j++) {
				b[i]+=myMatrix[i][j];
			}
		}
		
		System.out.println("Sum rows "+Arrays.toString(b));
	}
	
	public void SumByColumns() {	
		for(int i=0;i<myMatrix[0].length;i++) {
			 for(int j=0;j<myMatrix[i].length;j++) {
				 c[i]+=myMatrix[j][i];
			 }
		}
		
		System.out.println("Sum colums "+Arrays.toString(c));
	}
	
	public void MinMaxrows() {		
		int min = Arrays.stream(b)
			      .min()
			      .getAsInt();
		
		int max = Arrays.stream(b)
			      .max()
			      .getAsInt();
		
		System.out.println("min element rows "+min);
		System.out.println("max element rows "+max);
	}
	
	public void MinMaxColoum() {		
		int min = Arrays.stream(c)
			      .min()
			      .getAsInt();
		
		int max = Arrays.stream(c)
			      .max()
			      .getAsInt();
		
		System.out.println("min elements coloum "+min);
		System.out.println("max elements coloum "+max);
	}
	
	public String WriteToFile() throws IOException {
		StringBuilder str = new StringBuilder(); 
		String fileName="myfile.txt";
		
        for (int[] int1 : myMatrix) {
            for (int j = 0; j < int1.length; j++) {
                str.append(int1[j]).append(' '); 
            }
            str.append("\r\n"); 
        }
        
        File yourFile = new File(fileName);
        yourFile.createNewFile();

        Path path = Paths.get("D:\\Programming\\University\\JAVA\\test2 coursework\\"+fileName); 

        Files.write(path, str.toString().getBytes());         		

		
		return "Matrix is saved to file!";
	}
	
	public void ReadFromFile() throws IOException {
		int i = 0;
		String fileName="myfile.txt";
		FileInputStream file = null;
		file = new FileInputStream(fileName);

		StringBuilder str=new StringBuilder();

		do {
			i = file.read();
		     str.append((char) i);
		   } while(i != -1);

		   file.close();
		   
		   System.out.println("Matrix from file");
		   System.out.println(str.toString());
	}
}
