/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeFeatureRouter : MonoBehaviour // TypeDefIndex: 2640
	{
		// Fields
		private const float COOLDOWN_SEC = 0.6f; // Metadata: 0x005F12E2
		[CompilerGenerated]
		private static PokyHomeFeatureRouter _Instance_k__BackingField; // 0x00
		[Header("Th\u00E0nh ph\u1EA7n n\u1ED9i b\u1ED9 c\u1EE7a scene")]
		public HomeSettingsPopup settingsPopup; // 0x20
		public PokyHomeNextModule nextModule; // 0x28
		[Tooltip("Ngu\u1ED3n ti\u1EBFng b\u1EA5m. N\u00FAt PokyHome ch\u1EA1y b\u1EB1ng HomePressScale (kh\u00F4ng c\u00F3 component Button) n\u00EAn ButtonClickSound kh\u00F4ng b\u1EAFt \u0111\u01B0\u1EE3c \u2014 ph\u1EA3i ph\u00E1t th\u1EE7 c\u00F4ng t\u1EA1i \u0111\u00E2y.")]
		public HomeAudio homeAudio; // 0x30
		private float _lastRouteAt; // 0x38
	
		// Properties
		public static PokyHomeFeatureRouter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C1D9B0-0x0000000180C1D9F0 0x0000000180C1D9F0-0x0000000180C1DA90
		public bool Busy { get; } // 0x0000000180C1DA90-0x0000000180C1DAF0 
		public static bool HubMode { get; } // 0x0000000180C1DAF0-0x0000000180C1DC50 
	
		// Constructors
		public PokyHomeFeatureRouter(); // 0x0000000180C1EED0-0x0000000180C1EF20
	
		// Methods
		private void Awake(); // 0x0000000180C1DC50-0x0000000180C1DC60
		private void OnDestroy(); // 0x0000000180C1DC60-0x0000000180C1DDC0
		public void OpenModule(PokyHomeModuleView view); // 0x0000000180C1DDC0-0x0000000180C1DEC0
		public void Open(string routeKey); // 0x0000000180C1DEC0-0x0000000180C1DEF0
		public void Open(string routeKey, int requireLevel, string flagKey, PokyHomeModuleView view); // 0x0000000180C1DEF0-0x0000000180C1E860
		private static bool HasOwnClickSound(PokyHomeModuleView view); // 0x0000000180C1E860-0x0000000180C1EAB0
		public void GoToHub(string routeKey); // 0x0000000180C1EAB0-0x0000000180C1ED50
		private void PushHistory(); // 0x0000000180C1ED50-0x0000000180C1EED0
	}
}
