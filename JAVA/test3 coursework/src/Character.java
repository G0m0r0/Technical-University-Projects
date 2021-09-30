
public abstract class Character implements ICharacter{
	public String Name;
	private int attack;
	private int defense;
	private int HP=100;
	
	public Character(String name, int attack, int defense) {
		this.Name=name;
		this.setAttack(attack);
		this.setDefense(defense);
	}

	public int getAttack() {
		if(this.getHP()<=0) {
			return 0;
		}
		
		return attack;
	}

	public void setAttack(int attack) {
		this.attack = attack;
	}

	public int getDefense() {
		if(this.getHP()<=0) {
			return 0;
		}
		
		return defense;
	}

	public void setDefense(int deffence) {
		this.defense = deffence;
	}

	public int getHP() {
		return HP;
	}

	public void setHP(int hp) {
		if(hp<0) {
			HP=0;
		}
		
		HP = hp;
	}
	
	public void IsAttacked(int attacked) {		
		if(this.getDefense()<attacked) {			
			this.setHP(this.getHP()-attacked);			
			System.out.println(this.Name+": Unsuccessful defense! ");	
			
			this.setDefense(this.getDefense()+1); //every unsuccessful defense add 1 point
		}else {
			System.out.println(this.Name+": Successful defense! ");
			this.setAttack(this.getAttack()+10); //every successful attack add 10 points
		}
	}
	
	@Override
	 public String toString() {
		if(this.getHP()<=0) {
			return "Character is dead!";
			
		}
		return this.Name+" is with "+this.getHP()+" HP, "+this.getAttack()+" attack, "+this.getDefense()+" deffence.";
    }
}
