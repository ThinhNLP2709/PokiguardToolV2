//Type is in global namespace

public class RoomDTO
{
	public int id; //Field offset: 0x10
	public int energy; //Field offset: 0x14
	public int energyFull; //Field offset: 0x18
	public int count; //Field offset: 0x1C
	public int requestPass; //Field offset: 0x20
	public int requestAttack; //Field offset: 0x24
	public string name; //Field offset: 0x28
	public int lever; //Field offset: 0x30
	public int petId; //Field offset: 0x34
	public int enemyPetId; //Field offset: 0x38
	public int enemyPetLevel; //Field offset: 0x3C
	public string nameEnemyPetId; //Field offset: 0x40
	public string elementType; //Field offset: 0x48
	public List<CardData> cards; //Field offset: 0x50

	public RoomDTO() { }

}

