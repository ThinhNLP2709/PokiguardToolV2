//Type is in global namespace

public class PathBezier2d : MonoBehaviour
{
	public Transform[] cubes; //Field offset: 0x20
	public GameObject dude1; //Field offset: 0x28
	public GameObject dude2; //Field offset: 0x30
	private LTBezierPath visualizePath; //Field offset: 0x38

	public PathBezier2d() { }

	private void OnDrawGizmos() { }

	private void Start() { }

}

