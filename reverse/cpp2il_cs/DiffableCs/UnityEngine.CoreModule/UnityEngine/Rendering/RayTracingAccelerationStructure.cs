namespace UnityEngine.Rendering;

[MovedFrom("UnityEngine.Experimental.Rendering")]
public sealed class RayTracingAccelerationStructure : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	}

	internal struct BuildSettings
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private RayTracingAccelerationStructureBuildFlags <buildFlags>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private Vector3 <relativeOrigin>k__BackingField; //Field offset: 0x4

		public RayTracingAccelerationStructureBuildFlags buildFlags
		{
			[CompilerGenerated]
			 set { } //Length: 3
		}

		public Vector3 relativeOrigin
		{
			[CompilerGenerated]
			 set { } //Length: 16
		}

		public BuildSettings() { }

		[CompilerGenerated]
		public void set_buildFlags(RayTracingAccelerationStructureBuildFlags value) { }

		[CompilerGenerated]
		public void set_relativeOrigin(Vector3 value) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10

	[FreeFunction("RayTracingAccelerationStructure_Bindings::Destroy")]
	private static void Destroy(RayTracingAccelerationStructure accelStruct) { }

	private static void Destroy_Injected(IntPtr accelStruct) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

}

