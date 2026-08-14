namespace UnityEngine.Rendering;

public class HableCurve
{
	private struct DirectParams
	{
		internal float x0; //Field offset: 0x0
		internal float y0; //Field offset: 0x4
		internal float x1; //Field offset: 0x8
		internal float y1; //Field offset: 0xC
		internal float W; //Field offset: 0x10
		internal float overshootX; //Field offset: 0x14
		internal float overshootY; //Field offset: 0x18
		internal float gamma; //Field offset: 0x1C

	}

	internal class Segment
	{
		public float offsetX; //Field offset: 0x10
		public float offsetY; //Field offset: 0x14
		public float scaleX; //Field offset: 0x18
		public float scaleY; //Field offset: 0x1C
		public float lnA; //Field offset: 0x20
		public float B; //Field offset: 0x24

		public Segment() { }

		public float Eval(float x) { }

	}

	internal class Uniforms
	{
		private HableCurve parent; //Field offset: 0x10

		public Vector4 curve
		{
			 get { } //Length: 55
		}

		public Vector4 midSegmentA
		{
			 get { } //Length: 144
		}

		public Vector4 midSegmentB
		{
			 get { } //Length: 99
		}

		public Vector4 shoSegmentA
		{
			 get { } //Length: 144
		}

		public Vector4 shoSegmentB
		{
			 get { } //Length: 99
		}

		public Vector4 toeSegmentA
		{
			 get { } //Length: 144
		}

		public Vector4 toeSegmentB
		{
			 get { } //Length: 99
		}

		internal Uniforms(HableCurve parent) { }

		public Vector4 get_curve() { }

		public Vector4 get_midSegmentA() { }

		public Vector4 get_midSegmentB() { }

		public Vector4 get_shoSegmentA() { }

		public Vector4 get_shoSegmentB() { }

		public Vector4 get_toeSegmentA() { }

		public Vector4 get_toeSegmentB() { }

	}

	[CompilerGenerated]
	private float <whitePoint>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private float <inverseWhitePoint>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private float <x0>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private float <x1>k__BackingField; //Field offset: 0x1C
	public readonly Segment[] segments; //Field offset: 0x20
	public readonly Uniforms uniforms; //Field offset: 0x28

	public private float inverseWhitePoint
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public private float whitePoint
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public private float x0
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public private float x1
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public HableCurve() { }

	private void AsSlopeIntercept(out float m, out float b, float x0, float x1, float y0, float y1) { }

	public float Eval(float x) { }

	private float EvalDerivativeLinearGamma(float m, float b, float g, float x) { }

	[CompilerGenerated]
	public float get_inverseWhitePoint() { }

	[CompilerGenerated]
	public float get_whitePoint() { }

	[CompilerGenerated]
	public float get_x0() { }

	[CompilerGenerated]
	public float get_x1() { }

	public void Init(float toeStrength, float toeLength, float shoulderStrength, float shoulderLength, float shoulderAngle, float gamma) { }

	private void InitSegments(DirectParams srcParams) { }

	[CompilerGenerated]
	private void set_inverseWhitePoint(float value) { }

	[CompilerGenerated]
	private void set_whitePoint(float value) { }

	[CompilerGenerated]
	private void set_x0(float value) { }

	[CompilerGenerated]
	private void set_x1(float value) { }

	private void SolveAB(out float lnA, out float B, float x0, float y0, float m) { }

}

