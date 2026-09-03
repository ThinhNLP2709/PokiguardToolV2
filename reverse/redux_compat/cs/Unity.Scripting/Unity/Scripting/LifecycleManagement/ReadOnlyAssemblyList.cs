/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
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
	internal sealed class ReadOnlyAssemblyList : IReadOnlyList<Assembly> // TypeDefIndex: 14881
	{
		// Fields
		private readonly IReadOnlyList<Assembly> _assemblies; // 0x10
		private readonly Dictionary<string, Assembly> _assemblyLookup; // 0x18
	
		// Properties
		public Assembly this[int index] { get => default; } // 0x0000000182068BE0-0x0000000182068C90 
		public int Count { get; } // 0x0000000182068B20-0x0000000182068BE0 
	
		// Constructors
		public ReadOnlyAssemblyList(IReadOnlyList<Assembly> assemblies); // 0x0000000182068890-0x0000000182068B20
	
		// Methods
		public IEnumerator<Assembly> GetEnumerator(); // 0x00000001820686E0-0x0000000182068730
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000182068730-0x0000000182068780
		public bool Contains(string assemblyName); // 0x0000000182068680-0x00000001820686E0
		public bool Contains(AssemblyName assemblyName); // 0x0000000182068620-0x0000000182068680
		public bool TryGetAssembly(string assemblyName, out Assembly assembly); // 0x0000000182068820-0x0000000182068890
		public override string ToString(); // 0x0000000182068780-0x0000000182068820
	}
}
