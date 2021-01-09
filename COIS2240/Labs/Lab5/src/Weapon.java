import java.util.Random;

public abstract class Weapon {
    public static Random rand = new Random();
    String weaponName;

    public Weapon (String weaponName) {
        this.weaponName = weaponName;
    }

    public int calculateDamage (String attackType, int range) {
        if (attackType.equals("MeleeWeapon"))
            return 10;
        else {
            if (range <= 10)
                return 10;
            else if (range <= 100)
                return 5;
            return 0;
        }
    }

    public abstract void attackType();
    public abstract void range();
}
