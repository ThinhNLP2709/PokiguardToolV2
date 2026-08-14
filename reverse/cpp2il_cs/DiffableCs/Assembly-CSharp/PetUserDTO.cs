//Type is in global namespace

public class PetUserDTO
{
	public int id; //Field offset: 0x10
	public Nullable<Int32> userId; //Field offset: 0x14
	public int petId; //Field offset: 0x1C
	public Nullable<Int32> skillCardId; //Field offset: 0x20
	public string name; //Field offset: 0x28
	public string des; //Field offset: 0x30
	public string elementType; //Field offset: 0x38
	public string elementOther; //Field offset: 0x40
	public int level; //Field offset: 0x48
	public int maxLevel; //Field offset: 0x4C
	public int hp; //Field offset: 0x50
	public int attack; //Field offset: 0x54
	public int mana; //Field offset: 0x58
	public double weaknessValue; //Field offset: 0x60
	public int manaSkillCard; //Field offset: 0x68
	public CardData cardDTO; //Field offset: 0x70

	public PetUserDTO() { }

}

