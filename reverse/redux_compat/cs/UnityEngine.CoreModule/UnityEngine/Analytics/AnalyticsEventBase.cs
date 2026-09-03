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
	public class AnalyticsEventBase // TypeDefIndex: 8243
	{
		// Fields
		private string eventName; // 0x10
		private int eventVersion; // 0x18
		private string eventPrefix; // 0x20
		private SendEventOptions sendEventOptions; // 0x28
	
		// Constructors
		public AnalyticsEventBase(string eventName, int eventVersion, SendEventOptions sendEventOptions = SendEventOptions.kAppendNone /* Metadata: 0x0069D99C */, string eventPrefix = "" /* Metadata: 0x0069D99D */); // 0x0000000182229500-0x0000000182229570
		public AnalyticsEventBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
