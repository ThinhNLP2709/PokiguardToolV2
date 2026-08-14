//Type is in global namespace

[DisallowMultipleComponent]
public class PetStarRowUI : MonoBehaviour
{
	public const string NODE = "starRow"; //Field offset: 0x0
	[Tooltip("Ẩn hẳn cả dải khi pet chưa nâng sao (0 sao).")]
	public bool hideWhenZero; //Field offset: 0x20
	[Tooltip("Trần sao hiển thị. Server trả maxStar động; 0 = dùng số node con có sẵn.")]
	public int maxStar; //Field offset: 0x24
	private int _lastStar; //Field offset: 0x28
	private int _lastMax; //Field offset: 0x2C

	public PetStarRowUI() { }

	public static void Apply(Component petItem, int star, int maxStar = 6) { }

	public static PetStarRowUI FindUnder(Component petItem) { }

	public void Invalidate() { }

	public void SetStar(int star, int maxStarOverride = 0) { }

}

