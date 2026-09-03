/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	[IsReadOnly]
	[NativeHeader("Modules/UIElements/Core/Native/Unmanaged/UnmanagedDataHandle.h")]
	internal struct UnmanagedDataHandle // TypeDefIndex: 4987
	{
		// Fields
		public readonly int Index; // 0x00
		public readonly int Version; // 0x04
		internal static readonly EqualityComparer k_EqualityComparer; // 0x00
	
		// Properties
		public static UnmanagedDataHandle Undefined { get; } // 0x00000001802E7860-0x00000001802E7870 
		public bool IsUndefined { get; } // 0x0000000181CF8440-0x0000000181CF8450 
	
		// Nested types
		internal class EqualityComparer : IEqualityComparer<UnmanagedDataHandle> // TypeDefIndex: 4988
		{
			// Constructors
			public EqualityComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool Equals(UnmanagedDataHandle x, UnmanagedDataHandle y); // 0x00000001823F88B0-0x00000001823F8930
			public int GetHashCode(UnmanagedDataHandle handle); // 0x00000001823F8930-0x00000001823F8980
		}
	
		// Constructors
		internal UnmanagedDataHandle(int index, int version); // 0x0000000180C55C70-0x0000000180C55C80
		static UnmanagedDataHandle(); // 0x00000001823FF860-0x00000001823FF8E0
	
		// Methods
		public static bool operator ==(UnmanagedDataHandle a, UnmanagedDataHandle b); // 0x00000001823FF8E0-0x00000001823FF960
		public static bool operator !=(UnmanagedDataHandle a, UnmanagedDataHandle b); // 0x00000001823FF960-0x00000001823FF9E0
		public bool Equals(UnmanagedDataHandle other); // 0x000000018219A7A0-0x000000018219A7C0
		public override bool Equals(object obj); // 0x00000001823FF7C0-0x00000001823FF860
		public override int GetHashCode(); // 0x0000000180DF8AA0-0x0000000180DF8AB0
	}
}
