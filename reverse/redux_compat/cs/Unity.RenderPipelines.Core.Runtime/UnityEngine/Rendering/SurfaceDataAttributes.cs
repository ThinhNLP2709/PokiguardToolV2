/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AttributeUsage(AttributeTargets.Field)]
	public class SurfaceDataAttributes : Attribute // TypeDefIndex: 5690
	{
		// Fields
		public string[] displayNames; // 0x10
		public bool isDirection; // 0x18
		public bool sRGBDisplay; // 0x19
		public FieldPrecision precision; // 0x1C
		public bool checkIsNormalized; // 0x20
		public string preprocessor; // 0x28
	
		// Constructors
		public SurfaceDataAttributes(string displayName = "" /* Metadata: 0x00661798 */, bool isDirection = false /* Metadata: 0x00661799 */, bool sRGBDisplay = false /* Metadata: 0x0066179A */, FieldPrecision precision = FieldPrecision.Default /* Metadata: 0x0066179B */, bool checkIsNormalized = false /* Metadata: 0x0066179C */, string preprocessor = "" /* Metadata: 0x0066179D */); // 0x0000000181E9E660-0x0000000181E9E740
		public SurfaceDataAttributes(string[] displayNames, bool isDirection = false /* Metadata: 0x0066179E */, bool sRGBDisplay = false /* Metadata: 0x0066179F */, FieldPrecision precision = FieldPrecision.Default /* Metadata: 0x006617A0 */, bool checkIsNormalized = false /* Metadata: 0x006617A1 */, string preprocessor = "" /* Metadata: 0x006617A2 */); // 0x0000000181E9E740-0x0000000181E9E7C0
	}
}
