//Type is in global namespace

public class WsPlayerStateDTO
{
	public Nullable<Boolean> ready; //Field offset: 0x10
	public int slotIndex; //Field offset: 0x14
	public List<Int32> selectedCardIds; //Field offset: 0x18
	public int petId; //Field offset: 0x20
	public int energyCur; //Field offset: 0x24
	public int avatarId; //Field offset: 0x28
	public string displayName; //Field offset: 0x30
	public int level; //Field offset: 0x38
	public int energyFull; //Field offset: 0x3C
	public int passed; //Field offset: 0x40
	public int rankPoints; //Field offset: 0x44
	public int pvpWins; //Field offset: 0x48
	public int pvpLosses; //Field offset: 0x4C
	public int pvpBestStreak; //Field offset: 0x50
	public int userId; //Field offset: 0x54
	public int actorNumber; //Field offset: 0x58
	public Nullable<Boolean> inMatch; //Field offset: 0x5C
	public Nullable<Int64> fusionUserPetId; //Field offset: 0x60
	public string fusionRejectReason; //Field offset: 0x70
	public int weaponImageId; //Field offset: 0x78
	public string weaponRarity; //Field offset: 0x80

	public WsPlayerStateDTO() { }

}

