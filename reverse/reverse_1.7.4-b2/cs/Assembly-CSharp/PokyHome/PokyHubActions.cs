/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHubActions : MonoBehaviour // TypeDefIndex: 2180
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
		public static PokyHubActions Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018076FCB0-0x000000018076FD00 0x000000018076FD00-0x000000018076FD70
	
		// Constructors
		public PokyHubActions(); // 0x00000001802EBA70-0x00000001802EBAF0
		static PokyHubActions(); // 0x000000018076F610-0x000000018076FCB0
	
		// Methods
		private void Awake(); // 0x000000018076E500-0x000000018076E5B0
		private void OnDestroy(); // 0x000000018076F410-0x000000018076F540
		public static bool IsKnown(string routeKey); // 0x000000018076F310-0x000000018076F410
		public bool Invoke(string routeKey); // 0x000000018076E680-0x000000018076F310
		public static Transform HubCanvasRoot(); // 0x000000018076E5B0-0x000000018076E680
		public static void PlayClick(); // 0x000000018076F540-0x000000018076F610
	}
}
