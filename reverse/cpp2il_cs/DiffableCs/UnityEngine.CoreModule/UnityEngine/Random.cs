namespace UnityEngine;

[NativeHeader("Runtime/Export/Random/Random.bindings.h")]
public static class Random
{
	internal struct State
	{
		[SerializeField]
		private int s0; //Field offset: 0x0
		[SerializeField]
		private int s1; //Field offset: 0x4
		[SerializeField]
		private int s2; //Field offset: 0x8
		[SerializeField]
		private int s3; //Field offset: 0xC

	}


	[StaticAccessor("GetScriptingRand()", StaticAccessorType::Dot (0))]
	public static State state
	{
		 get { } //Length: 60
		 set { } //Length: 51
	}

	public static float value
	{
		[FreeFunction]
		 get { } //Length: 42
	}

	public static State get_state() { }

	private static void get_state_Injected(out State ret) { }

	[FreeFunction]
	public static float get_value() { }

	[NativeMethod("SetSeed")]
	[StaticAccessor("GetScriptingRand()", StaticAccessorType::Dot (0))]
	public static void InitState(int seed) { }

	[FreeFunction]
	private static int RandomRangeInt(int minInclusive, int maxExclusive) { }

	[FreeFunction]
	public static float Range(float minInclusive, float maxInclusive) { }

	public static int Range(int minInclusive, int maxExclusive) { }

	public static void set_state(State value) { }

	private static void set_state_Injected(in State value) { }

}

