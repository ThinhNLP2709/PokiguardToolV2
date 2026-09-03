/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal abstract class LifecycleScopeWithContext<T> : LifecycleScopeBase // TypeDefIndex: 14878
		where T : class
	{
		// Fields
		[CompilerGenerated]
		private readonly T _Context_k__BackingField;
	
		// Properties
		internal T Context { [CompilerGenerated] get; }
	
		// Constructors
		protected LifecycleScopeWithContext(string name, T context);
	}
}
