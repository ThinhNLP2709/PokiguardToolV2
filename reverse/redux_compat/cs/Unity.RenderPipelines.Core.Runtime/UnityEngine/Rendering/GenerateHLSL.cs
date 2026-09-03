/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
	public class GenerateHLSL : Attribute // TypeDefIndex: 5689
	{
		// Fields
		public PackingRules packingRules; // 0x10
		public bool containsPackedFields; // 0x14
		public bool needAccessors; // 0x15
		public bool needSetters; // 0x16
		public bool needParamDebug; // 0x17
		public int paramDefinesStart; // 0x18
		public bool omitStructDeclaration; // 0x1C
		public bool generateCBuffer; // 0x1D
		public int constantRegister; // 0x20
		public string sourcePath; // 0x28
	
		// Constructors
		public GenerateHLSL(PackingRules rules = PackingRules.Exact /* Metadata: 0x0066178F */, bool needAccessors = true /* Metadata: 0x00661790 */, bool needSetters = false /* Metadata: 0x00661791 */, bool needParamDebug = false /* Metadata: 0x00661792 */, int paramDefinesStart = 1 /* Metadata: 0x00661793 */, bool omitStructDeclaration = false /* Metadata: 0x00661794 */, bool containsPackedFields = false /* Metadata: 0x00661795 */, bool generateCBuffer = false /* Metadata: 0x00661796 */, int constantRegister = -1 /* Metadata: 0x00661797 */, [CallerFilePath] string sourcePath = null); // 0x0000000181E8D2C0-0x0000000181E8D350
	}
}
