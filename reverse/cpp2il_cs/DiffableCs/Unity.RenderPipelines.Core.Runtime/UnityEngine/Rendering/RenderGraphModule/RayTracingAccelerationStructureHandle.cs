namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RayTracingAccelerationStructure ({handle.index})")]
[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct RayTracingAccelerationStructureHandle
{
	private static RayTracingAccelerationStructureHandle s_NullHandle; //Field offset: 0x0
	internal ResourceHandle handle; //Field offset: 0x0

	public static RayTracingAccelerationStructureHandle nullHandle
	{
		 get { } //Length: 98
	}

	private static RayTracingAccelerationStructureHandle() { }

	internal RayTracingAccelerationStructureHandle(int handle) { }

	public static RayTracingAccelerationStructureHandle get_nullHandle() { }

	public bool IsValid() { }

	public static RayTracingAccelerationStructure op_Implicit(RayTracingAccelerationStructureHandle handle) { }

}

