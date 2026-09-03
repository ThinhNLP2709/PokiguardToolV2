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
	internal sealed class ScopeTransitionHelper // TypeDefIndex: 14884
	{
		// Fields
		private static readonly string k_ProfilerMarkerPrefix; // 0x00
		private static readonly string k_DetailedInvokeMarkerPrefix; // 0x08
		private readonly StackOrderedAssemblyList _assemblyList; // 0x10
		private readonly LifecycleMethodRegistry _lifecycleMethodRegistry; // 0x18
		[CompilerGenerated]
		[Nullable(2)]
		private INativeCallbackProvider _NativeCallbackProvider_k__BackingField; // 0x20
	
		// Properties
		private static bool EnableDetailedProfiling { get; } // 0x0000000182069C10-0x0000000182069C70 
		[Nullable(2)]
		internal INativeCallbackProvider NativeCallbackProvider { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public IReadOnlyList<Assembly> AllAssemblies { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public ScopeTransitionHelper(LifecycleMethodRegistry lifecycleMethodRegistry); // 0x0000000182069B20-0x0000000182069C10
		static ScopeTransitionHelper(); // 0x0000000182069A70-0x0000000182069B20
	
		// Methods
		private List<LifecycleMethodData> FindStaticMethodsWithAttribute(Type attributeType, IReadOnlyList<Assembly> assemblies); // 0x00000001820698A0-0x00000001820698C0
		[NullableContext(2)]
		public void ExecuteMethodsInOrder<T>(ReadOnlyAssemblyList assemblies = null);
		private void ExecuteMethodsInOrder(Type attributeType, IReadOnlyList<Assembly> assemblies); // 0x0000000182068D40-0x00000001820692F0
		[NullableContext(2)]
		public void ExecuteMethodsInReverseOrder<T>(ReadOnlyAssemblyList assemblies = null);
		private void ExecuteMethodsInReverseOrder(Type attributeType, IReadOnlyList<Assembly> assemblies); // 0x00000001820692F0-0x00000001820698A0
		internal void PushStack(ReadOnlyAssemblyList assemblies); // 0x0000000182069990-0x0000000182069A70
		internal void PopStack(); // 0x00000001820698C0-0x0000000182069990
	}
}
