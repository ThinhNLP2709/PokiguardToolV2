//Type is in global namespace

public class ShopPetDTO
{
	public long id; //Field offset: 0x10
	public long shopId; //Field offset: 0x18
	public string name; //Field offset: 0x20
	public int attack; //Field offset: 0x28
	public int hp; //Field offset: 0x2C
	public int mana; //Field offset: 0x30
	public int price; //Field offset: 0x34
	public string currencyType; //Field offset: 0x38
	public string elementType; //Field offset: 0x40
	public int purchaseCount; //Field offset: 0x48
	public int maxPurchasePerDay; //Field offset: 0x4C
	public bool canPurchase; //Field offset: 0x50

	public ShopPetDTO() { }

}

