//Type is in global namespace

public class MatchPrepDataDTO
{
	public PetUserDTO userPet; //Field offset: 0x10
	public PetUserDTO enemyPet; //Field offset: 0x18
	public UserDTO user; //Field offset: 0x20
	public bool bossAttemptDeducted; //Field offset: 0x28
	public long serverTime; //Field offset: 0x30
	public Nullable<Int32> hpBonusPct; //Field offset: 0x38
	public Nullable<Int32> manaBonus; //Field offset: 0x40
	public Nullable<Int32> powerMax; //Field offset: 0x48

	public MatchPrepDataDTO() { }

}

