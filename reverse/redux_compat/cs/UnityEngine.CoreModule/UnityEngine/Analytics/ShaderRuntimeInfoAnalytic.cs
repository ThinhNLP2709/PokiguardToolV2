/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Analytics
{
	[Serializable]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	internal class ShaderRuntimeInfoAnalytic : AnalyticsEventBase // TypeDefIndex: 8246
	{
		// Fields
		public long VariantsRequested; // 0x30
		public long VariantsRequestedMissing; // 0x38
		public long VariantsRequestedUnsupported; // 0x40
		public long VariantsRequestedCompiled; // 0x48
		public long VariantsRequestedViaWarmup; // 0x50
		public long VariantsUnused; // 0x58
		public int VariantsCompilationTimeTotal; // 0x60
		public int VariantsCompilationTimeMax; // 0x64
		public int VariantsCompilationTimeMedian; // 0x68
		public int VariantsWarmupTimeTotal; // 0x6C
		public int VariantsWarmupTimeMax; // 0x70
		public int VariantsWarmupTimeMedian; // 0x74
		public bool UseProgressiveWarmup; // 0x78
		public int ShaderChunkSizeMin; // 0x7C
		public int ShaderChunkSizeMax; // 0x80
		public int ShaderChunkSizeAvg; // 0x84
		public int ShaderChunkCountMin; // 0x88
		public int ShaderChunkCountMax; // 0x8C
		public int ShaderChunkCountAvg; // 0x90
	
		// Constructors
		private ShaderRuntimeInfoAnalytic(); // 0x00000001822534F0-0x0000000182253580
	
		// Methods
		[RequiredByNativeCode]
		public static ShaderRuntimeInfoAnalytic CreateShaderRuntimeInfoAnalytic(); // 0x0000000182253430-0x00000001822534F0
	}
}
