package chapter4;

import java.util.*;

class Dice {
    public static void main(String[] arguments) {
        Random generator = new Random();
        int value = generator.nextInt();
        System.out.println("The random number is "
            + value);
    }
}
