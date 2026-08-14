//Type is in global namespace

public class PetShardDTO
{
	public long petId; //Field offset: 0x10
	public string petName; //Field offset: 0x18
	public string elementType; //Field offset: 0x20
	public int quantity; //Field offset: 0x28
	public int star; //Field offset: 0x2C
	public int nextCost; //Field offset: 0x30
	public bool owned; //Field offset: 0x34
	public bool canExchange; //Field offset: 0x35

	public bool CanUpgradeNow
	{
		 get { } //Length: 25
	}

	public PetShardDTO() { }

	public bool CanExchangeWith(int exchangeCost) { }

	public bool get_CanUpgradeNow() { }

}

