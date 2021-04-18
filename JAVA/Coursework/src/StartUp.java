import java.io.IOException;
import java.util.Arrays;
import java.util.Scanner;

public class StartUp {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		
		System.out.print("Enter size of matrix: ");
		int size = scanner.nextInt();
		
		MatrixExtended matrixExtended=new MatrixExtended(size);
		matrixExtended.Fill();
		
		System.out.println("Sum of the elements is: "+ matrixExtended.Sum()+"\n");
		
		System.out.println("Sum by rows: "+Arrays.toString(matrixExtended.SumByRows()));
		System.out.println("Sum by Columns: "+Arrays.toString(matrixExtended.SumByColumns()));
		
		matrixExtended.DisplayMinMaxOfRow();
		matrixExtended.DisplayMinMaxOfColumn();
		
		
		System.out.println();
		try {
			System.out.println(matrixExtended.WriteToFile());
			matrixExtended.ReadFromFile();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		System.out.println("Matrix is: ");
		matrixExtended.Print();
	}

}
