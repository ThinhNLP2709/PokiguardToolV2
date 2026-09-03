/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal sealed class LifecycleMethodRegistry // TypeDefIndex: 14872
	{
		// Fields
		private readonly Dictionary<Type, Dictionary<Assembly, List<LifecycleMethodData>>> _lifecycleCallbacks; // 0x10
		private readonly Dictionary<Assembly, HashSet<Type>> _assemblyToAttributeTypes; // 0x18
	
		// Constructors
		public LifecycleMethodRegistry(); // 0x0000000182067030-0x00000001820670F0
	
		// Methods
		public void Register(Type lifecycleAttributeType, Assembly assembly, string methodFullName, Action callback); // 0x0000000182066CE0-0x0000000182067030
		internal List<LifecycleMethodData> Get(Type lifecycleAttributeType, IReadOnlyList<Assembly> assemblies); // 0x0000000182066A20-0x0000000182066CE0
		internal void Clear(IReadOnlyList<Assembly> assemblies); // 0x00000001820664C0-0x00000001820668A0
		internal bool ContainsAttributeType(Type attributeType); // 0x00000001820668A0-0x0000000182066A20
	}
}
