public class Sword extends MeleeWeapon {
    private double bladeLength;
    private String attackType;

    public Sword (int index) {
        super("Sword " + index);
        attackType = "MeleeAttack";
        bladeLength = rand.nextDouble() * 100;
    }

    public double getBladeLength() {
        return bladeLength;
    }

    public void strike () {
        System.out.println(weaponName + " was used. Damage dealt: " + calculateDamage(attackType, 0));
    }
}
