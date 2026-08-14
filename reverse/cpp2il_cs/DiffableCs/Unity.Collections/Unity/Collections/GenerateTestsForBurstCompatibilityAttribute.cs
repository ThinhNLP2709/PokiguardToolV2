namespace Unity.Collections;

[AttributeUsage(236, AllowMultiple = True)]
public class GenerateTestsForBurstCompatibilityAttribute : Attribute
{
	internal enum BurstCompatibleCompileTarget
	{
		Player = 0,
		Editor = 1,
		PlayerAndEditor = 2,
	}

	[CompilerGenerated]
	private Type[] <GenericTypeArguments>k__BackingField; //Field offset: 0x10
	public string RequiredUnityDefine; //Field offset: 0x18
	public BurstCompatibleCompileTarget CompileTarget; //Field offset: 0x20

	public Type[] GenericTypeArguments
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public GenerateTestsForBurstCompatibilityAttribute() { }

	[CompilerGenerated]
	public Type[] get_GenericTypeArguments() { }

	[CompilerGenerated]
	public void set_GenericTypeArguments(Type[] value) { }

}

