//Type is in global namespace

public class PetStarListResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public int maxStar; //Field offset: 0x20
	public PetStarEntry[] stars; //Field offset: 0x28
	public Int64[] upgradablePetIds; //Field offset: 0x30

	public PetStarListResponse() { }

}

