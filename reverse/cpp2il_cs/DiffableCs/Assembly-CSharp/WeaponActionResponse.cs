//Type is in global namespace

public class WeaponActionResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public long equippedUserWeaponId; //Field offset: 0x20
	public int weaponImageId; //Field offset: 0x28
	public string weaponRarity; //Field offset: 0x30
	public int star; //Field offset: 0x38
	public int power; //Field offset: 0x3C

	public WeaponActionResponse() { }

}

