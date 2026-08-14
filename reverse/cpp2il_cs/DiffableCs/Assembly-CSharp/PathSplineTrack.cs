//Type is in global namespace

public class PathSplineTrack : MonoBehaviour
{
	public GameObject car; //Field offset: 0x20
	public GameObject carInternal; //Field offset: 0x28
	public GameObject trackTrailRenderers; //Field offset: 0x30
	public Transform[] trackOnePoints; //Field offset: 0x38
	private LTSpline track; //Field offset: 0x40
	private int trackIter; //Field offset: 0x48
	private float trackPosition; //Field offset: 0x4C

	public PathSplineTrack() { }

	private void OnDrawGizmos() { }

	private void playSwish() { }

	private void Start() { }

	private void Update() { }

}

