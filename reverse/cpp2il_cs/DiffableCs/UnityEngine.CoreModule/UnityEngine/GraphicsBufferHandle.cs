namespace UnityEngine;

[IsReadOnly]
[NativeClass("GfxBufferID")]
[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
public struct GraphicsBufferHandle : IEquatable<GraphicsBufferHandle>
{
	public readonly uint value; //Field offset: 0x0

	public virtual bool Equals(object obj) { }

	public override bool Equals(GraphicsBufferHandle other) { }

	public virtual int GetHashCode() { }

}

