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
	internal class StallMarkerAnalytic : AnalyticsEventBase // TypeDefIndex: 15719
	{
		// Fields
		public string Name; // 0x30
		public bool HasProgressMarkup; // 0x38
		public double Duration; // 0x40
	
		// Constructors
		public StallMarkerAnalytic(); // 0x00000001825C7A30-0x00000001825C7AA0
	
		// Methods
		[RequiredByNativeCode]
		internal static StallMarkerAnalytic CreateStallMarkerAnalytic(); // 0x00000001825C79A0-0x00000001825C7A30
	}
}
