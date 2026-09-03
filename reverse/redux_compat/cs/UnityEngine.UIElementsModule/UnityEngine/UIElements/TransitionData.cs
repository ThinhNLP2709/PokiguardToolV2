/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct TransitionData : IStyleDataGroup<UnityEngine.UIElements.TransitionData>, IEquatable<UnityEngine.UIElements.TransitionData> // TypeDefIndex: 4626
	{
		// Fields
		public UnmanagedRefCountedList<TimeValue> transitionDelay; // 0x00
		public UnmanagedRefCountedList<TimeValue> transitionDuration; // 0x08
		public UnmanagedRefCountedList<StylePropertyId> transitionProperty; // 0x10
		public UnmanagedRefCountedList<EasingFunction> transitionTimingFunction; // 0x18
	
		// Methods
		public TransitionData GetDefault(); // 0x0000000180BB1500-0x0000000180BB1510
		public TransitionData Copy(); // 0x0000000182547480-0x0000000182547530
		public void CopyFrom(ref TransitionData other); // 0x00000001825473E0-0x0000000182547480
		public void Dispose(); // 0x0000000182547530-0x00000001825475C0
		public static bool operator ==(TransitionData lhs, TransitionData rhs); // 0x00000001825478B0-0x0000000182547A40
		public bool Equals(TransitionData other); // 0x00000001825475C0-0x0000000182547720
		public override bool Equals(object obj); // 0x0000000182547720-0x00000001825477C0
		public override int GetHashCode(); // 0x00000001825477C0-0x00000001825478B0
	}
}
