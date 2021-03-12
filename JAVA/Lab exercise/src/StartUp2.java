import java.util.Arrays;

public class StartUp2 {

	public static void main(String[] args) {
	   int kMax=500_000;
	   double epsX=0.001;
	   double epsF=0.001;
	   double[] x=new double[] {-10,10};
	   double c=2;
	   
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
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+Arrays.toString(x));
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
		
		newArray[0]=2*x[0]+x[1];
		newArray[1]=x[0]+2*x[1];				
		
		return newArray;
	}

	private static double F(double[] x) {
		double f=Math.pow(x[0],2)+Math.pow(x[1], 2)+x[0]*x[1]-10;
		
		return f;
	}

}
