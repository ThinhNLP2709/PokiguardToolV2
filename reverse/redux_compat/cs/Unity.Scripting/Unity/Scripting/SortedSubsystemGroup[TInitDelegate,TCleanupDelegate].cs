/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class SortedSubsystemGroup<TInitDelegate, TCleanupDelegate> // TypeDefIndex: 14831
	{
		// Fields
		[Nullable(new byte[5] {1, 1, 1, 0, 0 })]
		private readonly Dictionary<string, SubsystemEntry> m_Subsystems;
		[Nullable(new byte[2] {2, 1 })]
		private TInitDelegate[] m_InitDelegates;
		[Nullable(new byte[2] {2, 1 })]
		private TCleanupDelegate[] m_CleanupDelegates;
	
		// Properties
		private bool Frozen { get; }
		public TInitDelegate[] SortedInitCallbacks { get; }
		public TCleanupDelegate[] SortedCleanupCallbacks { get; }
	
		// Nested types
		[Nullable(0)]
		private class SubsystemEntry // TypeDefIndex: 14832
		{
			// Fields
			[CompilerGenerated]
			private readonly string _Name_k__BackingField;
			[CompilerGenerated]
			[Nullable(2)]
			private readonly TInitDelegate _InitDelegate_k__BackingField;
			[CompilerGenerated]
			[Nullable(2)]
			private readonly TCleanupDelegate _CleanupDelegate_k__BackingField;
			[CompilerGenerated]
			private readonly string[] _Dependencies_k__BackingField;
	
			// Properties
			public string Name { [CompilerGenerated] get; }
			[Nullable(2)]
			public TInitDelegate InitDelegate { [NullableContext(2)] [CompilerGenerated] get; }
			[Nullable(2)]
			public TCleanupDelegate CleanupDelegate { [NullableContext(2)] [CompilerGenerated] get; }
			public string[] Dependencies { [CompilerGenerated] get; }
	
			// Constructors
			public SubsystemEntry(string name, [Nullable(2)] TInitDelegate initDelegate, [Nullable(2)] TCleanupDelegate cleanupDelegate, string[] dependencies);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14833
		{
			// Fields
			[Nullable(0)]
			public static readonly __c<TInitDelegate, TCleanupDelegate> __9;
			[Nullable(0)]
			public static Func<SubsystemEntry<TInitDelegate, TCleanupDelegate>, bool> __9__10_0;
			[Nullable(0)]
			public static Func<SubsystemEntry<TInitDelegate, TCleanupDelegate>, TInitDelegate> __9__10_1;
			[Nullable(0)]
			public static Func<SubsystemEntry<TInitDelegate, TCleanupDelegate>, bool> __9__10_2;
			[Nullable(0)]
			public static Func<SubsystemEntry<TInitDelegate, TCleanupDelegate>, TCleanupDelegate> __9__10_3;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			[NullableContext(0)]
			internal bool _SortAndFreeze_b__10_0(SubsystemEntry<TInitDelegate, TCleanupDelegate> s);
			[NullableContext(0)]
			internal TInitDelegate _SortAndFreeze_b__10_1(SubsystemEntry<TInitDelegate, TCleanupDelegate> s);
			[NullableContext(0)]
			internal bool _SortAndFreeze_b__10_2(SubsystemEntry<TInitDelegate, TCleanupDelegate> s);
			[NullableContext(0)]
			internal TCleanupDelegate _SortAndFreeze_b__10_3(SubsystemEntry<TInitDelegate, TCleanupDelegate> s);
		}
	
		// Constructors
		public SortedSubsystemGroup();
	
		// Methods
		[NullableContext(2)]
		public void RegisterSubsystem([Nullable(1)] string name, TInitDelegate initDelegate, TCleanupDelegate cleanupDelegate, [Nullable(new byte[2] {2, 1 })] string[] dependencies);
		private void SortAndFreeze();
		private SubsystemEntry[] TopologicalSort();
		private void Visit(SubsystemEntry subsystem, HashSet<string> visited, List<SubsystemEntry> sorted, HashSet<string> pendingDependencies);
	}
}
