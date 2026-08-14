namespace UnityEngine;

[UsedByNativeCode]
public struct BoneWeight : IEquatable<BoneWeight>
{
	[SerializeField]
	private float m_Weight0; //Field offset: 0x0
	[SerializeField]
	private float m_Weight1; //Field offset: 0x4
	[SerializeField]
	private float m_Weight2; //Field offset: 0x8
	[SerializeField]
	private float m_Weight3; //Field offset: 0xC
	[SerializeField]
	private int m_BoneIndex0; //Field offset: 0x10
	[SerializeField]
	private int m_BoneIndex1; //Field offset: 0x14
	[SerializeField]
	private int m_BoneIndex2; //Field offset: 0x18
	[SerializeField]
	private int m_BoneIndex3; //Field offset: 0x1C

	public int boneIndex0
	{
		 get { } //Length: 6
	}

	public int boneIndex1
	{
		 get { } //Length: 6
	}

	public int boneIndex2
	{
		 get { } //Length: 6
	}

	public int boneIndex3
	{
		 get { } //Length: 6
	}

	public float weight0
	{
		 get { } //Length: 7
	}

	public float weight1
	{
		 get { } //Length: 8
	}

	public float weight2
	{
		 get { } //Length: 8
	}

	public float weight3
	{
		 get { } //Length: 8
	}

	public virtual bool Equals(object other) { }

	public override bool Equals(BoneWeight other) { }

	public int get_boneIndex0() { }

	public int get_boneIndex1() { }

	public int get_boneIndex2() { }

	public int get_boneIndex3() { }

	public float get_weight0() { }

	public float get_weight1() { }

	public float get_weight2() { }

	public float get_weight3() { }

	public virtual int GetHashCode() { }

}

