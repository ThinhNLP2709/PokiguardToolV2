/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHubActions : MonoBehaviour // TypeDefIndex: 1853
	{
		// Fields
		[CompilerGenerated]
		private static PokyHubActions _Instance_k__BackingField; // 0x00
		[Tooltip("B\u1EA3ng node \u2192 route (Assets/PokyHome/Data/PokyHubMap.asset).")]
		public PokyHubMap map; // 0x20
		[Tooltip("B\u1EA3ng c\u00E0i \u0111\u1EB7t c\u1EE7a v\u1ECF (route \'settings\').")]
		public HomeSettingsPopup settingsPopup; // 0x28
		public static readonly string[] ROUTES; // 0x08
	
		// Properties
		public static PokyHubActions Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180602360-0x00000001806023B0 0x00000001806023B0-0x0000000180602420
	
		// Constructors
		public PokyHubActions(); // 0x00000001802E7A70-0x00000001802E7BC0
		static PokyHubActions(); // 0x0000000180601D20-0x0000000180602360
	
		// Methods
		private void Awake(); // 0x0000000180600C70-0x0000000180600D20
		private void OnDestroy(); // 0x0000000180601B40-0x0000000180601C70
		public static bool IsKnown(string routeKey); // 0x0000000180601A40-0x0000000180601B40
		public bool Invoke(string routeKey); // 0x0000000180600DF0-0x0000000180601A40
		public static Transform HubCanvasRoot(); // 0x0000000180600D20-0x0000000180600DF0
		public static void PlayClick(); // 0x0000000180601C70-0x0000000180601D20
	}
}
