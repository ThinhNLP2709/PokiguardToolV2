//Type is in global namespace

public class PurchaseResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public int newGold; //Field offset: 0x20
	public int newRuby; //Field offset: 0x24
	public int newSafia; //Field offset: 0x28
	public WeaponDropDTO[] grantedWeapons; //Field offset: 0x30

	public PurchaseResponse() { }

}

