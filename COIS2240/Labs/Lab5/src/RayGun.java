public class RayGun extends Weapon {
    private String attackType;
    private int range;

    // Creates an instance of RayGun with a given number
    public RayGun (int index) {
        super("Ray Gun " + index);
        attackType = "RangedAttack";
        range = rand.nextInt(100) + 1;
    }

    public void fire () {
        System.out.println(weaponName + " fired. Damage dealt: " + calculateDamage(attackType, range));
    }

    public void attackType() {
        System.out.println(weaponName + "'s attack type is ranged");
    }

    public void range() {
        System.out.println(weaponName + "'s range is " + range);
    }
}
