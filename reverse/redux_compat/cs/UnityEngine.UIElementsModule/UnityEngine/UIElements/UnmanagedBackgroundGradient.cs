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
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct UnmanagedBackgroundGradient : IEquatable<UnmanagedBackgroundGradient> // TypeDefIndex: 4703
	{
		// Fields
		private static bool s_WarnedTruncatedStops; // 0x00
		public GradientType type; // 0x00
		public BackgroundGradientShape shape; // 0x04
		public BackgroundGradientSize size; // 0x08
		public float angle; // 0x0C
		public Vector2 position; // 0x10
		public int stopCount; // 0x18
		private int __padding; // 0x1C
		public FixedBuffer4<UnmanagedBackgroundGradientStop> stops; // 0x20
	
		// Methods
		public static implicit operator UnmanagedBackgroundGradient(BackgroundGradient g); // 0x000000018256FE60-0x0000000182570180
		public BackgroundGradient ToManaged(); // 0x000000018256FCE0-0x000000018256FE60
		public bool Equals(UnmanagedBackgroundGradient other); // 0x000000018256FA20-0x000000018256FB90
		public override bool Equals(object obj); // 0x000000018256F930-0x000000018256FA20
		public override int GetHashCode(); // 0x000000018256FB90-0x000000018256FCE0
	}
}
