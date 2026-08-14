//Type is in global namespace

public class RoomBootstrapData
{
	public UserDTO user; //Field offset: 0x10
	public List<PetUserDTO> userPets; //Field offset: 0x18
	public RoomDTO roomData; //Field offset: 0x20
	public string roomLockReason; //Field offset: 0x28
	public PvpProfileDTO pvpProfile; //Field offset: 0x30
	public long serverTime; //Field offset: 0x38

	public RoomBootstrapData() { }

}

