/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement.CodeGen
{
	[Nullable(0)]
	[NullableContext(1)]
	public abstract class ClassAutoCleanup // TypeDefIndex: 14896
	{
		// Constructors
		protected ClassAutoCleanup(Type scopeType); // 0x0000000182062E60-0x0000000182062EC0
		internal ClassAutoCleanup(Type scopeType, ScopeTransitionType cleanOn); // 0x0000000182062DF0-0x0000000182062E60
	
		// Methods
		public abstract void Cleanup();
	}
}
