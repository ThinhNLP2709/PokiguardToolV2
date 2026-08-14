//Type is in global namespace

public class MatchPlayerSnapshotDTO
{
	public string username; //Field offset: 0x10
	public int actorNumber; //Field offset: 0x18
	public int slotIndex; //Field offset: 0x1C
	public int teamId; //Field offset: 0x20
	public int hp; //Field offset: 0x24
	public int hpMax; //Field offset: 0x28
	public int mana; //Field offset: 0x2C
	public int manaMax; //Field offset: 0x30
	public int power; //Field offset: 0x34
	public int powerMax; //Field offset: 0x38
	public int attack; //Field offset: 0x3C
	public int shield; //Field offset: 0x40
	public int petId; //Field offset: 0x44
	public string petElementType; //Field offset: 0x48
	public int petLevel; //Field offset: 0x50
	public double weaknessVsBoss; //Field offset: 0x58
	public string displayName; //Field offset: 0x60
	public int avatarId; //Field offset: 0x68
	public int level; //Field offset: 0x6C
	public long userId; //Field offset: 0x70
	public int rankPoints; //Field offset: 0x78
	public bool inMatch; //Field offset: 0x7C
	public bool permanentLeave; //Field offset: 0x7D
	public bool online; //Field offset: 0x7E
	public List<Int32> handCards; //Field offset: 0x80
	public List<Int32> selectedDeck; //Field offset: 0x88
	public bool fusionUsedSuccess; //Field offset: 0x90
	public int fusionLastAttemptTurn; //Field offset: 0x94
	public Nullable<Int64> fusionSkillCardId; //Field offset: 0x98
	public Nullable<Int64> fusionSelectedUserPetId; //Field offset: 0xA8
	public Nullable<Int64> fusionSelectedPetId; //Field offset: 0xB8
	public int fusionBonusHp; //Field offset: 0xC8
	public int fusionBonusAttack; //Field offset: 0xCC
	public int fusionBonusMana; //Field offset: 0xD0
	public string fusionDropReason; //Field offset: 0xD8
	public int weaponImageId; //Field offset: 0xE0
	public string weaponRarity; //Field offset: 0xE8

	public MatchPlayerSnapshotDTO() { }

}

