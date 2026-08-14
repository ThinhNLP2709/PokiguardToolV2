namespace UnityEngine.AdaptivePerformance.Provider;

[Preserve]
public sealed class AdaptivePerformanceSubsystemDescriptor : SubsystemDescriptorWithProvider<AdaptivePerformanceSubsystem, APProvider>
{
	internal struct Cinfo
	{
		[CompilerGenerated]
		private string <id>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private Type <providerType>k__BackingField; //Field offset: 0x8
		[CompilerGenerated]
		private Type <subsystemTypeOverride>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private Type <subsystemImplementationType>k__BackingField; //Field offset: 0x18

		public string id
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 8
		}

		public Type providerType
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		[Obsolete("AdaptivePerformanceSubsystem no longer supports the deprecated set of base classes for subsystems as of Unity 2023.1. Use providerType and, optionally, subsystemTypeOverride instead.", True)]
		public Type subsystemImplementationType
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public Type subsystemTypeOverride
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		[CompilerGenerated]
		[IsReadOnly]
		public string get_id() { }

		[CompilerGenerated]
		[IsReadOnly]
		public Type get_providerType() { }

		[CompilerGenerated]
		[IsReadOnly]
		public Type get_subsystemImplementationType() { }

		[CompilerGenerated]
		[IsReadOnly]
		public Type get_subsystemTypeOverride() { }

		[CompilerGenerated]
		public void set_id(string value) { }

		[CompilerGenerated]
		public void set_providerType(Type value) { }

		[CompilerGenerated]
		public void set_subsystemImplementationType(Type value) { }

		[CompilerGenerated]
		public void set_subsystemTypeOverride(Type value) { }

	}


	public AdaptivePerformanceSubsystemDescriptor(Cinfo cinfo) { }

	public static AdaptivePerformanceSubsystemDescriptor RegisterDescriptor(Cinfo cinfo) { }

}

