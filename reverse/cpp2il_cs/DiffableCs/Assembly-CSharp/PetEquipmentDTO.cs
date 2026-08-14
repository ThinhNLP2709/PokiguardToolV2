//Type is in global namespace

public class PetEquipmentDTO
{
	public long id; //Field offset: 0x10
	public long petId; //Field offset: 0x18
	public string name; //Field offset: 0x20
	public int level; //Field offset: 0x28
	public int hp; //Field offset: 0x2C
	public int attack; //Field offset: 0x30
	public int mana; //Field offset: 0x34
	public string elementType; //Field offset: 0x38
	public bool equipped; //Field offset: 0x40

	public PetEquipmentDTO() { }

}

