public class Task {

	public static void main(String[] args) {		
		
		double x=-1;
		double epsx=0.001;
		double epsf=0.001;
		int kMax=500_000;
		double step=0.01;
		
		double f= Math.sqrt(5*Math.pow(x, 2)+x+6)+Math.sqrt(3*x+7);
		double gradF=0;		
		double xNext=0;
		
		double fNext=0;	
		int k=1;
		for(k=1;k<=kMax;k++) {
						
			 gradF=(10*x+1)/(2*Math.sqrt(5*Math.pow(x, 2)+x+6))+(3/(2*Math.sqrt(3*x+7)));
			 
			 xNext=x-Math.abs(step*gradF);
			 fNext=Math.sqrt(5*Math.pow(xNext, 2)+xNext+6)+Math.sqrt(3*xNext+7);		
			 		 
			 if(Math.abs(f-fNext)<epsf) {
				 if(k>1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+xNext);			
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+x);
					 break;
				 }
			 }		
			 
			 if(Math.abs(x-xNext)<epsx) {
				 if(k>1)
				 {
					 System.out.println("K= "+k);
					 System.out.println("F= "+fNext);
					 System.out.println("X= "+xNext);			
					 break;
				 }else {
					 System.out.println("K= "+k);
					 System.out.println("F= "+f);
					 System.out.println("X= "+x);
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
