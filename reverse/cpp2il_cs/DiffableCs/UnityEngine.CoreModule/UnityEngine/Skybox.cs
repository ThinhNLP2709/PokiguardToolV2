namespace UnityEngine;

[NativeHeader("Runtime/Camera/Skybox.h")]
public sealed class Skybox : Behaviour
{

	public Material material
	{
		 get { } //Length: 144
	}

	public Material get_material() { }

	private static IntPtr get_material_Injected(IntPtr _unity_self) { }

}

