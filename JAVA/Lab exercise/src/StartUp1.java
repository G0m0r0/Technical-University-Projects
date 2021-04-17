import java.util.Scanner;

public class StartUp1 {

	public static void main(String[] args) {		
		Scanner myInput = new Scanner( System.in );
	      
		//double x=-2;
		//double epsx=0.000000001;
		//double epsf=0.000000001;
		//int kMax=500_000;
		//double step=0.01;
		System.out.print("x= ");
	    double x=myInput.nextDouble();
	    System.out.print("epsx= ");
	    double epsx=myInput.nextDouble();
	    System.out.print("epsf= ");
		double epsf=myInput.nextDouble();
		System.out.print("kMax= ");
		int kMax=myInput.nextInt();
		System.out.print("alpha= ");
		double step=myInput.nextDouble();
		
		//f=0.991375
		//x=-2.75491
		
		double f= -Math.pow(-x*x-3*x+10, 1/3.0)+Math.pow(x*x+8*x+25, 1/3.0)+1;
		double gradF=0;		
		double xNext=0;
		
		double fNext=0;	
		int k=1;
		for(k=1;k<=kMax;k++) {
						
			 gradF=(-2*x-3)/(-3*Math.pow(-x*x-3*x+10, 2/3.0))+(2*x+8)/(3*Math.pow(x*x+8*x+25, 2/3.0));
			 
			 xNext=x-(step*gradF);
			 fNext=-Math.pow(-xNext*xNext-3*xNext+10, 1/3.0)+Math.pow(xNext*xNext+8*xNext+25, 1/3.0)+1;	
			 		 
			 if(Math.abs(f-fNext)<epsf) {
				 if(k>1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+xNext);		
					 System.out.println("Break from condition F. ");
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+x);
					 System.out.println("Break from condition F. ");
					 break;
				 }
			 }		
			 
			 if(Math.abs(x-xNext)<epsx) {
				 if(k>1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+xNext);	
					 System.out.println("Break from condition X. ");
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+x);
					 System.out.println("Break from condition X. ");
					 break;
				 }
			 }
			 											 
			 f=fNext;
			 x=xNext;
		}
		
		if(k==kMax) {
			 System.out.println("K= "+k);
			 System.out.println("F= "+fNext);
			 System.out.println("X= "+xNext);
		}
	}

}
