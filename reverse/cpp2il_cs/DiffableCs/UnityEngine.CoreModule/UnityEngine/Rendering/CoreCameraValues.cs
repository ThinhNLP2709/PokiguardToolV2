namespace UnityEngine.Rendering;

[UsedByNativeCode]
internal struct CoreCameraValues : IEquatable<CoreCameraValues>
{
	private int filterMode; //Field offset: 0x0
	private uint cullingMask; //Field offset: 0x4
	private int instanceID; //Field offset: 0x8

	public override bool Equals(CoreCameraValues other) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

}

