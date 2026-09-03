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
	public class PackageManagerBaseAnalytic : AnalyticsEventBase // TypeDefIndex: 15706
	{
		// Fields
		public long start_ts; // 0x30
		public long duration; // 0x38
		public bool blocking; // 0x40
		public string package_id; // 0x48
		public int status_code; // 0x50
		public string error_message; // 0x58
	
		// Constructors
		public PackageManagerBaseAnalytic(string eventName); // 0x00000001825C6EF0-0x00000001825C6F50
	}
}
