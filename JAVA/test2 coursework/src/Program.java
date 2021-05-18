import java.io.IOException;
import java.util.Scanner;

public class Program {

	public static void main(String[] args)  {
		Scanner sc = new Scanner(System.in);
		
		System.out.print("Set matrix size ");
		int m = sc.nextInt();
		
		Matrix mymatrix=new Matrix(m);
		mymatrix.setMatrix();
		mymatrix.GetElementsAsTable();
		mymatrix.SumMatrix();
		mymatrix.SumByRows();
		mymatrix.MinMaxrows();
		mymatrix.SumByColumns();
		mymatrix.MinMaxColoum();
		try {
			System.out.println(mymatrix.WriteToFile());
			mymatrix.ReadFromFile();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		System.out.println("Matrix is: ");
		mymatrix.GetElementsAsTable();;
	}

}
