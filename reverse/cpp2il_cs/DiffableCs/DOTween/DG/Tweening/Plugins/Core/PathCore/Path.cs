namespace DG.Tweening.Plugins.Core.PathCore;

public class Path
{
	private static CatmullRomDecoder _catmullRomDecoder; //Field offset: 0x0
	private static LinearDecoder _linearDecoder; //Field offset: 0x8
	private static CubicBezierDecoder _cubicBezierDecoder; //Field offset: 0x10
	public Single[] wpLengths; //Field offset: 0x10
	[SerializeField]
	public Vector3[] wps; //Field offset: 0x18
	[SerializeField]
	internal PathType type; //Field offset: 0x20
	[SerializeField]
	internal int subdivisionsXSegment; //Field offset: 0x24
	[SerializeField]
	internal int subdivisions; //Field offset: 0x28
	[SerializeField]
	internal ControlPoint[] controlPoints; //Field offset: 0x30
	[SerializeField]
	internal float length; //Field offset: 0x38
	[SerializeField]
	internal bool isFinalized; //Field offset: 0x3C
	[SerializeField]
	internal Single[] timesTable; //Field offset: 0x40
	[SerializeField]
	internal Single[] lengthsTable; //Field offset: 0x48
	internal int linearWPIndex; //Field offset: 0x50
	internal bool addedExtraStartWp; //Field offset: 0x54
	internal bool addedExtraEndWp; //Field offset: 0x55
	internal PathOptions plugOptions; //Field offset: 0x58
	private Path _incrementalClone; //Field offset: 0xC8
	private int _incrementalIndex; //Field offset: 0xD0
	private ABSPathDecoder _decoder; //Field offset: 0xD8
	private bool _changed; //Field offset: 0xE0
	internal Vector3[] nonLinearDrawWps; //Field offset: 0xE8
	internal Vector3 targetPosition; //Field offset: 0xF0
	internal Nullable<Vector3> lookAtPosition; //Field offset: 0xFC
	internal Color gizmoColor; //Field offset: 0x10C

	internal int minInputWaypoints
	{
		internal get { } //Length: 45
	}

	public Path(PathType type, Vector3[] waypoints, int subdivisionsXSegment, Nullable<Color> gizmoColor = null) { }

	internal Path() { }

	internal void AssignDecoder(PathType pathType) { }

	internal void AssignWaypoints(Vector3[] newWps, bool cloneWps = false) { }

	internal Path CloneIncremental(int loopIncrement) { }

	internal float ConvertToConstantPathPerc(float perc) { }

	private static Vector3 ConvertToDrawPoint(Vector3 wp, PathOptions plugOptions) { }

	internal void Destroy() { }

	internal void Draw() { }

	private static void Draw(Path p) { }

	internal void FinalizePath(bool isClosedPath, AxisConstraint lockPositionAxes, Vector3 currTargetVal) { }

	internal int get_minInputWaypoints() { }

	internal static Vector3[] GetDrawPoints(Path p, int drawSubdivisionsXSegment) { }

	internal Vector3 GetPoint(float perc, bool convertToConstantPerc = false) { }

	internal int GetWaypointIndexFromPerc(float perc, bool isMovingForward) { }

	internal static void RefreshNonLinearDrawWps(Path p) { }

}

