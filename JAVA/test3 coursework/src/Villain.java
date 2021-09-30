
public class Villain extends Character implements IVillain{

	public Villain(String name, int attack, int deffence, String title) {
		super(name, attack, deffence);

		this.Name=title+" "+this.Name; //villain have title
	}

	@Override
	public void IsAttacked(int attacked)
	{
		attacked-=5; //villain lowers enemy attacks
		
		super.IsAttacked(attacked);
	}
}
