import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

public class StartUp3 {

	public static void main(String[] args) {	
	   int kMax=20_000;
	   double epsX=0.00001;
	   double epsF=0.00001;
	   double[] x=new double[] {5,3,4};
	   double c=5;
	   	   
		double f1=F1(x);
		double f2=F2(x);
		double f3=F3(x);
		double f4=F4(x);
	    Double[] arrayOfF=new Double[] {f1,f2,f3,f4};
		
		double f=0;	
		f=Collections.max(Arrays.asList(arrayOfF));	
		double newF=f;
	   
	   int k=0;
	   for(k=0;k<kMax;k++) {
		   double Pk=c/(k+1);
		   
		   double[] gradFArray=new double[2];
		   if(f1==newF) {
			   gradFArray=GradF1(x);
		   }else if(f2==newF) {
			   gradFArray=GradF2(x);
		   }else if(f3==newF) {
			   gradFArray=GradF3(x);
		   }else if(f4==newF) {
			   gradFArray=GradF4(x);
		   }
		   		   
		   double resultGradF=ScalarOfF(gradFArray);
		   
		   if(resultGradF==0) {
			   resultGradF=0.0000001;
		   }
		   
		   double gammaK=1/(resultGradF); 
		   
		   double[] xNext=XNext(x,gammaK,gradFArray,Pk);	
		   
		   double fNext=0; 		   
		   if(f1==newF) {
			   fNext=F1(xNext);
		   }else if(f2==newF) {
			   fNext=F2(xNext);
		   }else if(f3==newF) {
			   fNext=F3(xNext);
		   }else if(f4==newF) {
			   fNext=F4(xNext);
		   }
		   
		   if(Math.abs(f-fNext)<epsF) {
				 if(k>=1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+Arrays.toString(xNext));			
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+Arrays.toString(x));
					 break;
				 }
			 }		
			 
		   for(int i=0;i<3;i++)
		   {
			 if(Math.abs(x[i]-xNext[i])<epsX) {
				 if(k>=1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+Arrays.toString(xNext));			
					 return;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+Arrays.toString(x));
					 return;
				 }
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

	private static double F4(double[] x) {
		double f4=2/x[2];		
		
		return f4;
	}
	
	private static double F3(double[] x) {
		double f3=(x[2]*x[2])/(x[1]);			
		
		return f3;
	}

	private static double F2(double[] x) {
	    double f2=(x[1]*x[1])/(4*x[0]);		
		
		return f2;
	}

	private static double F1(double[] x) {
		double f1=x[0];			
		
		return f1;
	}

	private static double[] XNext(double[] x, double gammaK, double[] gradFArray, double pk) {
		double[] newArray=new double[3];
		
		newArray[0]=x[0]-pk*gammaK*gradFArray[0];
		newArray[1]=x[1]-pk*gammaK*gradFArray[1];
		newArray[2]=x[2]-pk*gammaK*gradFArray[2];
		
		return newArray;
	}

	private static double ScalarOfF(double[] gradFArray) {
		double result=Math.sqrt(Math.pow(gradFArray[0], 2)+Math.pow(gradFArray[1], 2));
		
		return result;
	}

	private static double[] GradF1(double[] x) {
		double[] newArray=new double[3];
		
		newArray[0]=1;
		newArray[1]=0;		
		newArray[2]=0;
		
		return newArray;
	}
	
	private static double[] GradF2(double[] x) {
		double[] newArray=new double[3];
		
		newArray[0]=-(x[1]*x[1])/(4*x[0]*x[0]);
		newArray[1]=x[1]/(2*x[0]);		
		newArray[2]=0;
		
		return newArray;
	}
	
	private static double[] GradF3(double[] x) {
		double[] newArray=new double[3];
		
		newArray[0]=0;
		newArray[1]=-(x[2]*x[2])/(x[1]*x[1]);		
		newArray[2]=(2*x[2])/x[1];
		
		return newArray;
	}
	
	private static double[] GradF4(double[] x) {
		double[] newArray=new double[3];
		
		newArray[0]=0;
		newArray[1]=0;		
		newArray[2]=-2/(x[2]*x[2]);
		
		return newArray;
	}
}
