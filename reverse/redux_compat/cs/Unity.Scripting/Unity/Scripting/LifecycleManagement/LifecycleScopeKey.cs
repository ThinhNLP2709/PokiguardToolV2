/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[IsReadOnly]
	[Nullable(0)]
	[NullableContext(1)]
	internal struct LifecycleScopeKey : IEquatable<Unity.Scripting.LifecycleManagement.LifecycleScopeKey> // TypeDefIndex: 14877
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x00
		[CompilerGenerated]
		[Nullable(2)]
		private readonly object _Context_k__BackingField; // 0x08
	
		// Properties
		public Type Type { [CompilerGenerated] get; } // 0x00000001808BADD0-0x00000001808BADE0 
		[Nullable(2)]
		public object Context { [NullableContext(2)] [CompilerGenerated] get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
	
		// Constructors
		public LifecycleScopeKey(Type scopeType); // 0x0000000182067A80-0x0000000182067A90
		public LifecycleScopeKey(Type scopeType, [Nullable(2)] object context); // 0x00000001820679B0-0x0000000182067A80
	
		// Methods
		public static LifecycleScopeKey CreateFromScope(LifecycleScope scope); // 0x0000000182067600-0x0000000182067640
		public static LifecycleScopeKey CreateFromScope<T>(LifecycleScopeWithContext<T> scope)
			where T : class;
		public bool Equals(LifecycleScopeKey other); // 0x0000000182067710-0x0000000182067780
		public override int GetHashCode(); // 0x0000000182067780-0x00000001820677E0
		[CompilerGenerated]
		[NullableContext(0)]
		public override string ToString(); // 0x0000000182067880-0x00000001820679B0
		[CompilerGenerated]
		[NullableContext(0)]
		private bool PrintMembers(StringBuilder builder); // 0x00000001820677E0-0x0000000182067880
		[CompilerGenerated]
		public static bool operator !=(LifecycleScopeKey left, LifecycleScopeKey right); // 0x0000000182067B00-0x0000000182067B80
		[CompilerGenerated]
		public static bool operator ==(LifecycleScopeKey left, LifecycleScopeKey right); // 0x0000000182067A90-0x0000000182067B00
		[CompilerGenerated]
		[NullableContext(0)]
		public override bool Equals(object obj); // 0x0000000182067640-0x0000000182067710
	}
}
