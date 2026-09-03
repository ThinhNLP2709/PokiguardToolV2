/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class PackingAttribute : Attribute // TypeDefIndex: 5692
	{
		// Fields
		public string[] displayNames; // 0x10
		public float[] range; // 0x18
		public FieldPacking packingScheme; // 0x20
		public int offsetInSource; // 0x24
		public int sizeInBits; // 0x28
		public bool isDirection; // 0x2C
		public bool sRGBDisplay; // 0x2D
		public bool checkIsNormalized; // 0x2E
		public string preprocessor; // 0x30
	
		// Constructors
		public PackingAttribute(string[] displayNames, FieldPacking packingScheme = FieldPacking.NoPacking /* Metadata: 0x006617A3 */, int bitSize = 32 /* Metadata: 0x006617A4 */, int offsetInSource = 0 /* Metadata: 0x006617A5 */, float minValue = 0f /* Metadata: 0x006617A6 */, float maxValue = 1f /* Metadata: 0x006617AA */, bool isDirection = false /* Metadata: 0x006617AE */, bool sRGBDisplay = false /* Metadata: 0x006617AF */, bool checkIsNormalized = false /* Metadata: 0x006617B0 */, string preprocessor = "" /* Metadata: 0x006617B1 */); // 0x0000000181E8FFE0-0x0000000181E900E0
		public PackingAttribute(string displayName = "" /* Metadata: 0x006617B2 */, FieldPacking packingScheme = FieldPacking.NoPacking /* Metadata: 0x006617B3 */, int bitSize = 0 /* Metadata: 0x006617B4 */, int offsetInSource = 0 /* Metadata: 0x006617B5 */, float minValue = 0f /* Metadata: 0x006617B6 */, float maxValue = 1f /* Metadata: 0x006617BA */, bool isDirection = false /* Metadata: 0x006617BE */, bool sRGBDisplay = false /* Metadata: 0x006617BF */, bool checkIsNormalized = false /* Metadata: 0x006617C0 */, string preprocessor = "" /* Metadata: 0x006617C1 */); // 0x0000000181E900E0-0x0000000181E90220
	}
}
