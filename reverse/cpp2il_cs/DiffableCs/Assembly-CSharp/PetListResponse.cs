//Type is in global namespace

public class PetListResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public List<PetClaimDTO> pets; //Field offset: 0x20

	public PetListResponse() { }

}

