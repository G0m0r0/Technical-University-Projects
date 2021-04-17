import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class StartUp5 {

	public static void main(String[] args) {		
	   //int kMax=50_000;
	   //double epsF=0.001;
	   //double[] x=new double[] {0,0};
	   //int n=2;
	   //double c=7;
		
		Scanner myInput = new Scanner( System.in );
		    
		    double[] x=new double[2];
		    System.out.print("x values: ");
		    String s[]= myInput.nextLine().split(" ");
		    for(int i =0;i < s.length;i++){	    	
		        x[i]= Double.parseDouble(s[i]);
		    }
		    
		    System.out.print("epsf= ");
			double epsF=myInput.nextDouble();
			System.out.print("kMax= ");
			int kMax=myInput.nextInt();
			System.out.print("c= ");
			double c=myInput.nextDouble();
			System.out.print("rangeMinW= ");
			int rangeMin=myInput.nextInt();
			System.out.print("rangeMaxW= ");
			int rangeMax=myInput.nextInt();
	   
	   double[] w=RandomGenerator(x.length,rangeMin,rangeMax);	   
	   
	   double f=F(x,w);	 
	  
	   double oldResultGradF=0;
	   int k=0;
	   double sumResultGradF=0;
	   for(k=0;k<kMax;k++) {					   
		   double Pk=c/(k+1);
		   double[] gradFArray=GradF(x,w);		   
		   double resultGradF=ScalarOfF(gradFArray);
		   
		   if(resultGradF==0) {
			   resultGradF=0.0000001;
		   }
		   
		   sumResultGradF+=resultGradF;		   
		   //double avgResultGradF=sumResultGradF/(k+1);		   
		   double gammaK=1/(resultGradF);
		   
		   double[] xNext=XNext(x,gammaK,gradFArray,Pk);	
		   
		   double fNext=F(xNext,w);
		   
		   if(Math.abs(oldResultGradF-resultGradF)<epsF &&k!=0) {
				 if(k>=1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("W= "+Arrays.toString(w));
					 System.out.println("X= "+Arrays.toString(xNext));			
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("W= "+Arrays.toString(w));
					 System.out.println("X= "+Arrays.toString(x));
					 break;
				 }
			 }				
		   
		   f=fNext;
		   x=xNext;		   
		   w=RandomGenerator(x.length,rangeMin,rangeMax);	 
		   oldResultGradF=resultGradF;
	   }
	   
	   if(k==kMax) {
			 System.out.println("K= "+k);
			 System.out.println("F= "+f);
			 System.out.println("W= "+Arrays.toString(w));
			 System.out.println("X= "+Arrays.toString(x));
		}
	}

	private static double[] RandomGenerator(int xLength, int rangeMin, int rangeMax) {
		double[] arrDouble=new double[xLength];
		
		Random r = new Random();
		
		for(int i=0; i<xLength; i++) {
			arrDouble[i] = rangeMin + (rangeMax - rangeMin) * r.nextDouble();
		}
		
		return arrDouble;
	}

	private static double[] XNext(double[] x, double gammaK, double[] gradFArray, double pk) {
		double[] newArray=new double[2];
		
		newArray[0]=x[0]-pk*gammaK*gradFArray[0];
		newArray[1]=x[1]-pk*gammaK*gradFArray[1];
		
		return newArray;
	}

	private static double ScalarOfF(double[] gradFArray) {
		double result=Math.sqrt(Math.pow(gradFArray[0], 2)+Math.pow(gradFArray[1], 2));
		
		return result;
	}

	private static double[] GradF(double[] x,double[] w) {
		double[] newArray=new double[2];
		
		newArray[0]=2*(x[0]-w[0]);
		newArray[1]=2*(x[1]-w[1]);				
		
		return newArray;
	}

	private static double F(double[] x,double[] w) {
		double f=Math.pow(x[0]-w[0],2)+Math.pow(x[1]-w[1], 2);		
		return f;
	}

}
