namespace DG.Tweening;

public static class DOCurve
{
	internal static class CubicBezier
	{

		public static Vector3 GetPointOnSegment(Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, float factor) { }

		public static Vector3[] GetSegmentPointCloud(Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, int resolution = 10) { }

		public static void GetSegmentPointCloud(List<Vector3> addToList, Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, int resolution = 10) { }

	}


}

