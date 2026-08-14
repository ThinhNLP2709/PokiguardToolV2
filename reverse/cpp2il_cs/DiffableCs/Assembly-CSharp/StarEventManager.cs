//Type is in global namespace

public class StarEventManager : MonoBehaviour
{
	public static StarEventManager Instance; //Field offset: 0x0
	[CompilerGenerated]
	private Action<Int32, Int32, Int32> OnStarCountChanged; //Field offset: 0x20

	public event Action<Int32, Int32, Int32> OnStarCountChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public StarEventManager() { }

	[CompilerGenerated]
	public void add_OnStarCountChanged(Action<Int32, Int32, Int32> value) { }

	private void Awake() { }

	[CompilerGenerated]
	public void remove_OnStarCountChanged(Action<Int32, Int32, Int32> value) { }

	public void UpdateStarCount(int white, int blue, int red) { }

}

