interface ICanHolster {
    void canHolster();
}

public abstract class MeleeWeapon extends Weapon implements ICanHolster {
    public MeleeWeapon (String weaponName) {
        super(weaponName);
    }

    public void attackType () {
        System.out.println(weaponName + "'s attack type is melee");
    }
    public void range () {
        System.out.println(weaponName + "'s range is 0");
    }

    public void canHolster () {
        System.out.println(weaponName + " can be holstered");
    }

    public abstract void strike();
}
