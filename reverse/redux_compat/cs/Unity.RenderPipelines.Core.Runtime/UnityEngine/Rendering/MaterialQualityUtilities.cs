/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[MovedFrom("Utilities")]
	public static class MaterialQualityUtilities // TypeDefIndex: 5784
	{
		// Fields
		public static readonly string[] KeywordNames; // 0x00
		public static readonly string[] EnumNames; // 0x08
		public static readonly ShaderKeyword[] Keywords; // 0x10
	
		// Constructors
		static MaterialQualityUtilities(); // 0x0000000181EC1CB0-0x0000000181EC1F80
	
		// Methods
		public static MaterialQuality FromIndex(int index); // 0x0000000181EC1700-0x0000000181EC1710
	
		// Extension methods
		public static MaterialQuality GetHighestQuality(this MaterialQuality levels); // 0x0000000181EC18D0-0x0000000181EC1960
		public static MaterialQuality GetClosestQuality(this MaterialQuality availableLevels, MaterialQuality requestedLevel); // 0x0000000181EC1710-0x0000000181EC18D0
		public static void SetGlobalShaderKeywords(this MaterialQuality level); // 0x0000000181EC1960-0x0000000181EC1AA0
		public static void SetGlobalShaderKeywords(this MaterialQuality level, CommandBuffer cmd); // 0x0000000181EC1AA0-0x0000000181EC1C10
		public static int ToFirstIndex(this MaterialQuality level); // 0x0000000181EC1C10-0x0000000181EC1CB0
	}
}
