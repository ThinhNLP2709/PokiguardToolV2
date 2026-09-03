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

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct UnmanagedBackgroundGradientStop : IEquatable<UnmanagedBackgroundGradientStop> // TypeDefIndex: 4702
	{
		// Fields
		public Color color; // 0x00
		public float position; // 0x10
		public int positionIsPercent; // 0x14
	
		// Methods
		public static implicit operator UnmanagedBackgroundGradientStop(BackgroundGradientStop s); // 0x000000018256F8E0-0x000000018256F930
		public BackgroundGradientStop ToManaged(); // 0x000000018256F8B0-0x000000018256F8E0
		public bool Equals(UnmanagedBackgroundGradientStop other); // 0x000000018256F690-0x000000018256F760
		public override bool Equals(object obj); // 0x000000018256F760-0x000000018256F800
		public override int GetHashCode(); // 0x000000018256F800-0x000000018256F8B0
	}
}
