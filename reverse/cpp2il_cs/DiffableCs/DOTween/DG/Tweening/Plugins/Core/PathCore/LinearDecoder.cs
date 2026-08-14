namespace DG.Tweening.Plugins.Core.PathCore;

internal class LinearDecoder : ABSPathDecoder
{

	internal virtual int minInputWaypoints
	{
		internal get { } //Length: 6
	}

	public LinearDecoder() { }

	internal virtual void FinalizePath(Path p, Vector3[] wps, bool isClosedPath) { }

	internal virtual int get_minInputWaypoints() { }

	internal virtual Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints) { }

	internal void SetTimeToLengthTables(Path p, int subdivisions) { }

	internal void SetWaypointsLengths(Path p, int subdivisions) { }

}

