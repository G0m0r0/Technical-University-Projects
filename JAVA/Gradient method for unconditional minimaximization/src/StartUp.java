import java.util.Arrays;

public class StartUp {

	public static void main(String[] args) {	
	   int kMax=20_000;
	   double epsX=0.001;
	   double epsF=0.001;
	   double[] x=new double[] {0,0};
	   double c=5;
	   
		double f1=F1(x);
		double f2=F1(x);
		
		double f=0;	
		if(f1>f2) {
			f=F1(x);
		}else {
			f=F2(x);
		}   		
	   
	   int k=0;
	   for(k=0;k<kMax;k++) {
		   double Pk=c/(k+1);
		   
		   double[] gradFArray=new double[2];
		   if(f1>f2) {
			   gradFArray=GradF1(x);
		   }else {
			   gradFArray=GradF2(x);
		   }
		   		   
		   double resultGradF=ScalarOfF(gradFArray);
		   
		   if(resultGradF==0) {
			   resultGradF=0.0000001;
		   }
		   
		   double gammaK=1/(resultGradF); //what is resultGradF is 0?
		   
		   double[] xNext=XNext(x,gammaK,gradFArray,Pk);	
		   
		   double fNext=0;
		   if(f1>f2) {
			   fNext=F1(xNext);
			}else {
			   fNext=F2(xNext);
			}  		   
		   
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
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+Arrays.toString(x));
					 break;
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

	private static double F2(double[] x) {
	    double f2=Math.pow(x[0]-3, 2)+Math.pow(x[1]-4,2)-10;			
		
		return f2;
	}

	private static double F1(double[] x) {
		double f1=Math.pow(x[0]-1, 2)+Math.pow(x[1]-2,2)-1;			
		
		return f1;
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

	private static double[] GradF1(double[] x) {
		double[] newArray=new double[2];
		
		newArray[0]=2*(x[0]-1);
		newArray[1]=2*(x[1]-2);				
		
		return newArray;
	}
	
	private static double[] GradF2(double[] x) {
		double[] newArray=new double[2];
		
		newArray[0]=2*(x[0]-3);
		newArray[1]=2*(x[1]-4);				
		
		return newArray;
	}
}
