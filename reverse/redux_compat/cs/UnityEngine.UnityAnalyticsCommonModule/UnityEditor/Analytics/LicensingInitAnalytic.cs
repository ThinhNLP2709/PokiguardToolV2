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
	public class LicensingInitAnalytic : AnalyticsEventBase // TypeDefIndex: 15701
	{
		// Fields
		public string licensingProtocolVersion; // 0x30
		public string licensingClientVersion; // 0x38
		public string channelType; // 0x40
		public double initTime; // 0x48
		public bool isLegacy; // 0x50
		public string sessionId; // 0x58
		public string correlationId; // 0x60
	
		// Constructors
		public LicensingInitAnalytic(); // 0x00000001825C6B50-0x00000001825C6BC0
	
		// Methods
		[RequiredByNativeCode]
		internal static LicensingInitAnalytic CreateLicensingInitAnalytic(); // 0x00000001825C6AC0-0x00000001825C6B50
	}
}
