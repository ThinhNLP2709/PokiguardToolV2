//Type is in global namespace

public class PathSplineEndless : MonoBehaviour
{
	public GameObject trackTrailRenderers; //Field offset: 0x20
	public GameObject car; //Field offset: 0x28
	public GameObject carInternal; //Field offset: 0x30
	public GameObject[] cubes; //Field offset: 0x38
	private int cubesIter; //Field offset: 0x40
	public GameObject[] trees; //Field offset: 0x48
	private int treesIter; //Field offset: 0x50
	public float randomIterWidth; //Field offset: 0x54
	private LTSpline track; //Field offset: 0x58
	private List<Vector3> trackPts; //Field offset: 0x60
	private int zIter; //Field offset: 0x68
	private float carIter; //Field offset: 0x6C
	private float carAdd; //Field offset: 0x70
	private int trackMaxItems; //Field offset: 0x74
	private int trackIter; //Field offset: 0x78
	private float pushTrackAhead; //Field offset: 0x7C
	private float randomIter; //Field offset: 0x80

	public PathSplineEndless() { }

	[CompilerGenerated]
	private void <Start>b__17_0(float val) { }

	private void addRandomTrackPoint() { }

	private GameObject objectQueue(GameObject[] arr, ref int lastIter) { }

	private void playSwish() { }

	private void refreshSpline() { }

	private void Start() { }

	private void Update() { }

}

