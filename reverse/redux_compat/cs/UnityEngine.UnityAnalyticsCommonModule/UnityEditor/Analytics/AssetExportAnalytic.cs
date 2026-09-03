/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 58: UnityEngine.UnityAnalyticsCommonModule.dll - Assembly: UnityEngine.UnityAnalyticsCommonModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15685-15721

namespace UnityEditor.Analytics
{
	[Serializable]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	internal class AssetExportAnalytic : AnalyticsEventBase // TypeDefIndex: 15717
	{
		// Fields
		public string package_name; // 0x30
		public string error_message; // 0x38
		public int items_count; // 0x40
		public string[] asset_extensions; // 0x48
		public bool include_upm_dependencies; // 0x50
	
		// Constructors
		public AssetExportAnalytic(); // 0x00000001825C6540-0x00000001825C65B0
	
		// Methods
		[RequiredByNativeCode]
		public static AssetExportAnalytic CreateAssetExportAnalytic(); // 0x00000001825C64B0-0x00000001825C6540
	}
}
