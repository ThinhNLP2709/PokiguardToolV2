/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHubActions : MonoBehaviour // TypeDefIndex: 2623
	{
		// Fields
		[CompilerGenerated]
		private static PokyHubActions _Instance_k__BackingField; // 0x00
		[Tooltip("B\u1EA3ng node \u2192 route (Assets/PokyHome/Data/PokyHubMap.asset).")]
		public PokyHubMap map; // 0x20
		[Tooltip("KH\u00D4NG C\u00D2N D\u00D9NG (07/09/2026): route \'settings\' nay m\u1EDF SettingsPanel d\u1EF1ng l\u00FAc ch\u1EA1y. Tr\u01B0\u1EDDng gi\u1EEF l\u1EA1i \u0111\u1EC3 prefab v\u1ECF \u0111\u00E3 build kh\u00F4ng m\u1EA5t tham chi\u1EBFu khi Unity n\u1EA1p l\u1EA1i.")]
		public HomeSettingsPopup settingsPopup; // 0x28
		public static readonly string[] ROUTES; // 0x08
	
		// Properties
		public static PokyHubActions Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C16040-0x0000000180C160A0 0x0000000180C160A0-0x0000000180C16150
	
		// Constructors
		public PokyHubActions(); // 0x000000018028A560-0x000000018028A5B0
		static PokyHubActions(); // 0x0000000180C17A80-0x0000000180C180D0
	
		// Methods
		private void Awake(); // 0x0000000180C16150-0x0000000180C161A0
		private void OnDestroy(); // 0x0000000180C161A0-0x0000000180C16350
		public static bool IsKnown(string routeKey); // 0x0000000180C16350-0x0000000180C164A0
		public bool Invoke(string routeKey); // 0x0000000180C164A0-0x0000000180C17690
		public static Transform HubCanvasRoot(); // 0x0000000180C17690-0x0000000180C17860
		public static void PlayClick(); // 0x0000000180C17860-0x0000000180C17A80
	}
}
