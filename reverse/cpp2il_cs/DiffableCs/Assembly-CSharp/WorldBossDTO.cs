//Type is in global namespace

public class WorldBossDTO
{
	public int id; //Field offset: 0x10
	public int petId; //Field offset: 0x14
	public string bossName; //Field offset: 0x18
	public int bossLevel; //Field offset: 0x20
	public int bossHp; //Field offset: 0x24
	public int bossAttack; //Field offset: 0x28
	public int bossMana; //Field offset: 0x2C
	public string elementType; //Field offset: 0x30
	public string startTime; //Field offset: 0x38
	public string endTime; //Field offset: 0x40
	public long startTimeMs; //Field offset: 0x48
	public long endTimeMs; //Field offset: 0x50
	public long serverTimeMs; //Field offset: 0x58
	public string status; //Field offset: 0x60
	public int remainingAttempts; //Field offset: 0x68
	public int maxAttempts; //Field offset: 0x6C
	public int currentDamage; //Field offset: 0x70
	public int userRank; //Field offset: 0x74

	public WorldBossDTO() { }

}

