namespace DG.Tweening.Plugins.Core.PathCore;

internal abstract class ABSPathDecoder
{

	internal abstract int minInputWaypoints
	{
		internal get { } //Length: 0
	}

	protected ABSPathDecoder() { }

	internal abstract void FinalizePath(Path p, Vector3[] wps, bool isClosedPath) { }

	internal abstract int get_minInputWaypoints() { }

	internal abstract Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints) { }

}

