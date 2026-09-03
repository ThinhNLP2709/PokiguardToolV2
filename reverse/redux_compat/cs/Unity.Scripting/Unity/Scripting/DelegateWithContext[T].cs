/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting
{
	[Nullable(0)]
	[NullableContext(1)]
	internal sealed class DelegateWithContext<T> // TypeDefIndex: 14819
	{
		// Fields
		[CompilerGenerated]
		private readonly IntPtr _NativeInvocationContext_k__BackingField;
		[CompilerGenerated]
		private readonly T _NativeDelegate_k__BackingField;
		[CompilerGenerated]
		private readonly Profiling.ProfilerMarker _ProfilerMarker_k__BackingField;
	
		// Properties
		public IntPtr NativeInvocationContext { [CompilerGenerated] get; }
		public T NativeDelegate { [CompilerGenerated] get; }
		public Profiling.ProfilerMarker ProfilerMarker { [CompilerGenerated] get; }
	
		// Constructors
		public DelegateWithContext(IntPtr nativeInvocationContext, T nativeDelegate, string subsystemIdentifier);
	
		// Methods
		[NullableContext(2)]
		public override bool Equals(object obj);
		private bool Equals(DelegateWithContext<T> other);
		public override int GetHashCode();
	}
}
