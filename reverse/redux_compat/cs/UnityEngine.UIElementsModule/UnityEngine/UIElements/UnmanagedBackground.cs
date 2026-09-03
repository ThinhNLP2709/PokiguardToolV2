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
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct UnmanagedBackground : IEquatable<UnmanagedBackground> // TypeDefIndex: 4701
	{
		// Fields
		public EntityId imageEntityId; // 0x00
		public UnmanagedRefCountedList<UnmanagedBackgroundGradient> gradient; // 0x08
	
		// Methods
		public static explicit operator EntityId(UnmanagedBackground bg); // 0x00000001808BADD0-0x00000001808BADE0
		public void CopyFrom(UnmanagedBackground other); // 0x00000001825702A0-0x00000001825702F0
		public void CopyFrom(Background managed); // 0x00000001825702F0-0x0000000182570510
		public void CopyFromBoxed(object boxed); // 0x0000000182570180-0x00000001825702A0
		public void Dispose(); // 0x0000000182570510-0x0000000182570550
		public bool Equals(UnmanagedBackground other); // 0x0000000182570630-0x00000001825706B0
		public override bool Equals(object obj); // 0x0000000182570550-0x0000000182570630
		public override int GetHashCode(); // 0x00000001825706B0-0x0000000182570720
		public static bool operator ==(UnmanagedBackground a, UnmanagedBackground b); // 0x0000000182570720-0x00000001825707B0
		public static bool operator !=(UnmanagedBackground a, UnmanagedBackground b); // 0x00000001825707B0-0x0000000182570840
	}
}
