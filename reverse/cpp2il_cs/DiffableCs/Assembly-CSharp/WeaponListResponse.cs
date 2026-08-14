//Type is in global namespace

public class WeaponListResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public int totalPages; //Field offset: 0x20
	public int shardCount; //Field offset: 0x24
	public long equippedUserWeaponId; //Field offset: 0x28
	public List<UserWeaponDTO> weapons; //Field offset: 0x30

	public WeaponListResponse() { }

}

