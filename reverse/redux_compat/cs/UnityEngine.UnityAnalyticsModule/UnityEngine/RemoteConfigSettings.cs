/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 64: UnityEngine.UnityAnalyticsModule.dll - Assembly: UnityEngine.UnityAnalyticsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15794-15806

namespace UnityEngine
{
	[ExcludeFromDocs]
	[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
	public class RemoteConfigSettings // TypeDefIndex: 15799
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
		[CompilerGenerated]
		private Action<bool> Updated; // 0x18
	
		// Methods
		[RequiredByNativeCode]
		internal static void RemoteConfigSettingsUpdated(RemoteConfigSettings rcs, bool wasLastUpdatedFromServer); // 0x00000001825C8CE0-0x00000001825C8D10
	}
}
