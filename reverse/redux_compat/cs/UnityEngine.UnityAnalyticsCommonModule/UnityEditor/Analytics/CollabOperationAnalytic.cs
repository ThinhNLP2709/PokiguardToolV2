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
	public class CollabOperationAnalytic : AnalyticsEventBase // TypeDefIndex: 15699
	{
		// Fields
		public string category; // 0x30
		public string operation; // 0x38
		public string result; // 0x40
		public long start_ts; // 0x48
		public long duration; // 0x50
	
		// Constructors
		public CollabOperationAnalytic(); // 0x00000001825C6950-0x00000001825C69C0
	
		// Methods
		[RequiredByNativeCode]
		internal static CollabOperationAnalytic CreateCollabOperationAnalytic(); // 0x00000001825C68C0-0x00000001825C6950
	}
}
