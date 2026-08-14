namespace DG.Tweening.Plugins.Core.PathCore;

internal class CubicBezierDecoder : ABSPathDecoder
{
	private static readonly ControlPoint[] _PartialControlPs; //Field offset: 0x0
	private static readonly Vector3[] _PartialWps; //Field offset: 0x8

	internal virtual int minInputWaypoints
	{
		internal get { } //Length: 6
	}

	private static CubicBezierDecoder() { }

	public CubicBezierDecoder() { }

	internal virtual void FinalizePath(Path p, Vector3[] wps, bool isClosedPath) { }

	internal virtual int get_minInputWaypoints() { }

	internal virtual Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints) { }

	internal void SetTimeToLengthTables(Path p, int subdivisions) { }

	internal void SetWaypointsLengths(Path p, int subdivisions) { }

}

