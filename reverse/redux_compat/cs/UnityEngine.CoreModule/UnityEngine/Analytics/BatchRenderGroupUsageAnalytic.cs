/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Analytics
{
	[Serializable]
	[RequiredByNativeCode(GenerateProxy = true)]
	internal class BatchRenderGroupUsageAnalytic : AnalyticsEventBase // TypeDefIndex: 8244
	{
		// Fields
		public int maxBRGInstance; // 0x30
		public int maxMeshCount; // 0x34
		public int maxMaterialCount; // 0x38
		public int maxDrawCommandBatch; // 0x3C
	
		// Constructors
		public BatchRenderGroupUsageAnalytic(); // 0x000000018222AB80-0x000000018222AC10
	
		// Methods
		[RequiredByNativeCode]
		public static BatchRenderGroupUsageAnalytic CreateBatchRenderGroupUsageAnalytic(); // 0x000000018222AAC0-0x000000018222AB80
	}
}
