import java.util.Arrays;
import java.util.Scanner;

public class StartUp4 {

	public static void main(String[] args) {
	   //int kMax=50_000;
	   //double epsX=0.001;
	   //double epsF=0.001;
	   //double[] x=new double[] {0,10};
	   //double[] a=new double[] {-10,-20}; //conditions for limit A
	   //double[] b=new double[] {10,20}; //conditions for limit B
	   //double c=2;
		Scanner myInput = new Scanner( System.in );		
		    
		    double[] x=new double[2];
		    System.out.print("x values: ");
		    String s1[]= myInput.nextLine().split(" ");
		    for(int i =0;i < s1.length;i++){	    	
		        x[i]= Double.parseDouble(s1[i]);
		    }
		    
		    double[] a=new double[2];
		    System.out.print("a interval: ");
		    String s2[]= myInput.nextLine().split(" ");
		    for(int i =0;i < s2.length;i++){	    	
		        a[i]= Double.parseDouble(s2[i]);
		    }
		    
		    double[] b=new double[2];
		    System.out.print("b interval: ");
		    String s3[]= myInput.nextLine().split(" ");
		    for(int i =0;i < s3.length;i++){	    	
		        b[i]= Double.parseDouble(s3[i]);
		    }
		    
		    System.out.print("epsx= ");
		    double epsX=myInput.nextDouble();
		    System.out.print("epsf= ");
			double epsF=myInput.nextDouble();
			System.out.print("kMax= ");
			int kMax=myInput.nextInt();
			System.out.print("c= ");
			double c=myInput.nextDouble();
	   
	   double f=F(x);	   	  	   	  
	   
	   int k=0;
	   for(k=0;k<kMax;k++) {
		   double Pk=c/(k+1);
		   double[] gradFArray=GradF(x);		   
		   double resultGradF=ScalarOfF(gradFArray);
		   
		   if(resultGradF==0) {
			   resultGradF=0.0000001;
		   }
		   
		   double gammaK=1/(resultGradF);
		   
		   double[] xNext=XNext(x,gammaK,gradFArray,Pk);	
		   
		   double fNext=F(xNext);
		   
		   if(Math.abs(f-fNext)<epsF) {
				 if(k>1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+Arrays.toString(xNext));		
					 System.out.println("Break from condition F. ");
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+Arrays.toString(x));
					 System.out.println("Break from condition F. ");
					 break;
				 }
			 }		
			 
		   for(int i=0;i<2;i++)
		   {
			 if(Math.abs(x[i]-xNext[i])<epsX) {
				 if(k>1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+Arrays.toString(xNext));	
					 System.out.println("Break from condition X. ");
					 return;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+Arrays.toString(x));
					 System.out.println("Break from condition X. ");
					 return;
				 }
			 }
		   }	
		   
		   for(int i=0;i<2;i++)
		   {
			 if(b[i]<xNext[i]) {
				xNext[i]=b[i];			 
			 }
		   }	
		   
		   for(int i=0;i<2;i++)
		   {
			 if(a[i]>xNext[i]) {
				xNext[i]=a[i];			 
			 }
		   }	
		   
		   f=fNext;
		   x=xNext;
		   
	   }
	   
	   if(k==kMax) {
			 System.out.println("K= "+k);
			 System.out.println("F= "+f);
			 System.out.println("X= "+Arrays.toString(x));
		}
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

	private static double[] GradF(double[] x) {
		double[] newArray=new double[2];
		
		newArray[0]=3*x[0]*x[0]-3*x[1];
		newArray[1]=3*x[1]*x[1]-3*x[0];				
		
		return newArray;
	}

	private static double F(double[] x) {
		double f=Math.pow(x[0],3)+Math.pow(x[1], 3)-3*x[0]*x[1];
		
		return f;
	}

}
