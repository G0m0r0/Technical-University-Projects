
public class myMainclass {

	public static void main(String[] args) {
		myClass myObjClass=new myClass();
		
		myObjClass.a=100;
		//myObjClass.b=100; error because its final
		
		System.out.println(myObjClass.a);
		System.out.println(myObjClass.b);
		
		myObjClass.myMethod();
	}

}
