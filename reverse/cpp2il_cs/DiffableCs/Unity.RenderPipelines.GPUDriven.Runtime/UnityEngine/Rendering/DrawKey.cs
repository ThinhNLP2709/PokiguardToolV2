namespace UnityEngine.Rendering;

internal struct DrawKey : IEquatable<DrawKey>
{
	public BatchMeshID meshID; //Field offset: 0x0
	public int submeshIndex; //Field offset: 0x4
	public BatchMaterialID materialID; //Field offset: 0x8
	public BatchDrawCommandFlags flags; //Field offset: 0xC
	public int transparentInstanceId; //Field offset: 0x10
	public uint overridenComponents; //Field offset: 0x14
	public RangeKey range; //Field offset: 0x18
	public int lightmapIndex; //Field offset: 0x34

	public override bool Equals(DrawKey other) { }

	public virtual int GetHashCode() { }

}

