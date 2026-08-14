//Type is in global namespace

public class ShopDataResponse
{
	public List<ShopItemDTO> items; //Field offset: 0x10
	public List<ShopPetDTO> pets; //Field offset: 0x18
	public List<ShopAvatarDTO> avatars; //Field offset: 0x20
	public List<ShopPackageDTO> packages; //Field offset: 0x28

	public ShopDataResponse() { }

}

