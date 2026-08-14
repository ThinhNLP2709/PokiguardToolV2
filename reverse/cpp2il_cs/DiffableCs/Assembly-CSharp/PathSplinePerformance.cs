//Type is in global namespace

public class PathSplinePerformance : MonoBehaviour
{
	public GameObject trackTrailRenderers; //Field offset: 0x20
	public GameObject car; //Field offset: 0x28
	public GameObject carInternal; //Field offset: 0x30
	public float circleLength; //Field offset: 0x38
	public float randomRange; //Field offset: 0x3C
	public int trackNodes; //Field offset: 0x40
	public float carSpeed; //Field offset: 0x44
	public float tracerSpeed; //Field offset: 0x48
	private LTSpline track; //Field offset: 0x50
	private int trackIter; //Field offset: 0x58
	private float carAdd; //Field offset: 0x5C
	private float trackPosition; //Field offset: 0x60

	public PathSplinePerformance() { }

	private void OnDrawGizmos() { }

	private void playSwish() { }

	private void Start() { }

	private void Update() { }

}

