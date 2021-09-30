import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;


public class Program {

	public static void main(String[] args) {
		Hero hero1=new Hero("Ivan",15,8,5); //name,attack,defense,autoHeal
		Villain villain1=new Villain("Pesho",12,10,"Mr.");
		
		System.out.println("Fight between:");
		System.out.println(hero1.toString());
		System.out.println(villain1.toString());

		System.out.println();
		hero1.IsAttacked(villain1.getAttack());
		hero1.IsAttacked(villain1.getAttack());
		villain1.IsAttacked(hero1.getAttack());
		hero1.IsAttacked(villain1.getAttack());
		hero1.IsAttacked(villain1.getAttack());
		villain1.IsAttacked(hero1.getAttack());
		
		System.out.println();
		System.out.println(hero1.toString());
		System.out.println(villain1.toString());
		
		String strHero ="Hero,"+hero1.Name+','+hero1.getAttack()+','+hero1.getDefense()+','+hero1.getAutoHeal()+','+hero1.getHP();
		String strVillain="Villain,"+villain1.Name+','+villain1.getAttack()+','+villain1.getDefense()+','+villain1.getHP();
		String strToWrite=strHero+"\n"+strVillain;
        
        //save hero and villain to file
        try {
        	File yourFile = new File("game.txt");
            yourFile.createNewFile();

            Path path = Paths.get("D:\\game.txt"); 
			Files.write(path, strToWrite.getBytes());
			System.out.println("\nCharacters saved to file!\n");
		} catch (IOException e) {
			System.out.println("Problem with saving to file!\n");
			e.printStackTrace();
		} 
        
      //read from file
        int strToRead = 0;
		String str="";
		
        try {
        	FileInputStream file = new FileInputStream("D:\\game.txt");
		do {
			strToRead = file.read();
			str+=(char) strToRead;
		   } while(strToRead != -1);

		   file.close();
        }
        catch (IOException e) {
        	System.out.println("Problem with saving to file!\n");
			e.printStackTrace();
        }
		   
		   var strArray=str.split("\n");
		   
		   for(int j=0;j<strArray.length;j++) {
			   var tokens= strArray[j].split(",");
			   
			   ICharacter character=null;
			   
			   if(tokens[0].equals("Hero")) {
				   character=new Hero(tokens[1],Integer.valueOf(tokens[2]),Integer.valueOf(tokens[3]),Integer.valueOf(tokens[4]));
				   character.setHP(Integer.valueOf(tokens[5]));
			   }else if(tokens[0].equals("Villain")) {
				   var title=tokens[1].split(" ")[0];
				   var name=tokens[1].split(" ")[1];
				   character=new Villain(name,Integer.valueOf(tokens[2]),Integer.valueOf(tokens[3]),title);
			   }			   			 
			   
			   if(character==null)
			   {
				   System.out.println("No heroes saved!\n");
			   }else
			   {
				   System.out.println(character.toString());
			   }			   			  
			 }
			   		  
		   
	}
}
