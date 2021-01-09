import java.util.Scanner;

public class Main {
    public static void main (String[] args) {
        Scanner reader = new Scanner(System.in);

        System.out.println("Please, input the index of the sword to create:");
        int swordIndex = reader.nextInt();
        System.out.println("Please, input the index of the ray gun to create:");
        int rayGunIndex = reader.nextInt();

        Sword sword = new Sword(swordIndex);
        RayGun rayGun = new RayGun(rayGunIndex);

        // Output their functions
        sword.strike();
        rayGun.fire();

        // Output their attackTypes and ranges
        sword.attackType();
        rayGun.attackType();

        sword.range();
        rayGun.range();
        // Output the sword's blade length and that it can be holstered
        sword.canHolster();
        System.out.println("Sword's blade length is " + sword.getBladeLength());
    }
}
