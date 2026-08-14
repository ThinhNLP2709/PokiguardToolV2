//Type is in global namespace

public class PetsPaginatedDataDTO
{
	public PetUserDTO[] content; //Field offset: 0x10
	public int totalPages; //Field offset: 0x18
	public int totalElements; //Field offset: 0x1C
	public int number; //Field offset: 0x20
	public int size; //Field offset: 0x24
	public bool first; //Field offset: 0x28
	public bool last; //Field offset: 0x29
	public int numberOfElements; //Field offset: 0x2C

	public PetsPaginatedDataDTO() { }

}

