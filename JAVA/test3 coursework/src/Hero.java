
public class Hero extends Character implements IHero{
	private int AutoHeal;
	
	public Hero(String name, int attack, int defense, int autoHeal) {
		super(name, attack, defense);
		this.setAutoHeal(autoHeal);
	}

	public int getAutoHeal() {
		if(this.getHP()<=0) {
			return 0;
		}
		return AutoHeal;
	}

	public void setAutoHeal(int autoHeal) {
		AutoHeal = autoHeal;
	}
	
	public void autoHealHero() {
		this.setHP(this.getHP()+this.getAutoHeal()); //special ability to add HP
	}
	
	@Override
    public String toString() {
		if(this.getHP()<=0) {
			return "This hero is dead!";
		}
		return super.toString()+ "Hero has "+this.getAutoHeal()+" autoheal.";
    }
}
