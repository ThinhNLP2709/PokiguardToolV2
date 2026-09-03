/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Layout;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[IsReadOnly]
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct UnmanagedFilterFunction : IEquatable<UnmanagedFilterFunction> // TypeDefIndex: 4382
	{
		// Fields
		private readonly FilterFunctionType m_Type; // 0x00
		private readonly FixedBuffer4<FilterParameter> m_Parameters; // 0x04
		private readonly int m_ParameterCount; // 0x64
		private readonly EntityId m_CustomDefinition; // 0x68
	
		// Constructors
		private UnmanagedFilterFunction(FilterFunction filterFunction); // 0x0000000182540E40-0x0000000182540F10
	
		// Methods
		private FilterFunction ToManaged(); // 0x0000000182540D60-0x0000000182540E40
		public static implicit operator UnmanagedFilterFunction(FilterFunction filterFunction); // 0x00000001825412C0-0x00000001825413F0
		public static implicit operator FilterFunction(UnmanagedFilterFunction unmanagedFilterFunction); // 0x0000000182541190-0x00000001825412C0
		public static bool operator ==(UnmanagedFilterFunction lhs, UnmanagedFilterFunction rhs); // 0x0000000182540F10-0x0000000182541190
		public bool Equals(UnmanagedFilterFunction other); // 0x00000001825408B0-0x0000000182540B80
		public override bool Equals(object obj); // 0x0000000182540B80-0x0000000182540C60
		public override int GetHashCode(); // 0x0000000182540C60-0x0000000182540D60
	}
}
