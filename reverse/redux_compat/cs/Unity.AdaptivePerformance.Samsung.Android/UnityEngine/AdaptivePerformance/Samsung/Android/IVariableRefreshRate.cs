/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 79: Unity.AdaptivePerformance.Samsung.Android.dll - Assembly: Unity.AdaptivePerformance.Samsung.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15913-15920

namespace UnityEngine.AdaptivePerformance.Samsung.Android
{
	public interface IVariableRefreshRate // TypeDefIndex: 15919
	{
		// Properties
		int[] SupportedRefreshRates { get; }
		int CurrentRefreshRate { get; }
	
		// Events
		event VariableRefreshRateEventHandler RefreshRateChanged {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Methods
		bool SetRefreshRateByIndex(int index);
	}
}
