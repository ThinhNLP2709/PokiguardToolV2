namespace TMPro.Examples;

public class TextMeshSpawner : MonoBehaviour
{
	public int SpawnType; //Field offset: 0x20
	public int NumberOfNPC; //Field offset: 0x24
	public Font TheFont; //Field offset: 0x28
	private TextMeshProFloatingText floatingText_Script; //Field offset: 0x30

	public TextMeshSpawner() { }

	private void Awake() { }

	private void Start() { }

}

