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
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class DrawParams // TypeDefIndex: 5046
	{
		// Fields
		internal static readonly Rect k_UnlimitedRect; // 0x00
		internal static readonly Rect k_FullNormalizedRect; // 0x10
		internal readonly Stack<Matrix4x4> view; // 0x10
		internal readonly Stack<Rect> scissor; // 0x18
		internal readonly List<Material> defaultMaterial; // 0x20
		internal readonly List<MaterialPropertyBlock> props; // 0x28
		internal Rect drawBounds; // 0x30
	
		// Properties
		internal Vector2 boundsMin { get; } // 0x000000018240B260-0x000000018240B2C0 
	
		// Constructors
		public DrawParams(); // 0x000000018240B100-0x000000018240B260
		static DrawParams(); // 0x000000018240B0A0-0x000000018240B100
	
		// Methods
		public void Reset(); // 0x000000018240AED0-0x000000018240B0A0
	}
}
