namespace UnityEngine;

[NativeHeader("Runtime/Camera/Camera.h")]
internal class CameraRaycastHelper
{

	[FreeFunction("CameraScripting::RaycastTry")]
	internal static GameObject RaycastTry(Camera cam, Ray ray, float distance, int layerMask) { }

	private static IntPtr RaycastTry_Injected(IntPtr cam, in Ray ray, float distance, int layerMask) { }

	[FreeFunction("CameraScripting::RaycastTry2D")]
	internal static GameObject RaycastTry2D(Camera cam, Ray ray, float distance, int layerMask) { }

	private static IntPtr RaycastTry2D_Injected(IntPtr cam, in Ray ray, float distance, int layerMask) { }

}

