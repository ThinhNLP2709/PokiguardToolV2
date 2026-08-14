//Type is in global namespace

public class PetClaimDTO
{
	public long petId; //Field offset: 0x10
	public string petName; //Field offset: 0x18
	public int currentE1; //Field offset: 0x20
	public int e1Condition; //Field offset: 0x24
	public int currentE2; //Field offset: 0x28
	public int e2Condition; //Field offset: 0x2C
	public int currentE3; //Field offset: 0x30
	public int e3Condition; //Field offset: 0x34
	public bool canClaim; //Field offset: 0x38
	public bool alreadyClaimed; //Field offset: 0x39

	public PetClaimDTO() { }

}

