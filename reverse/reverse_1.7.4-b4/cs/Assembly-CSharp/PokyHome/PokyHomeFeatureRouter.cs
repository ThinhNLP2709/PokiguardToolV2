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
	public class PokyHomeFeatureRouter : MonoBehaviour // TypeDefIndex: 2647
	{
		// Fields
		private const float COOLDOWN_SEC = 0.6f; // Metadata: 0x005F26F9
		[CompilerGenerated]
		private static PokyHomeFeatureRouter _Instance_k__BackingField; // 0x00
		[Header("Th\u00E0nh ph\u1EA7n n\u1ED9i b\u1ED9 c\u1EE7a scene")]
		public HomeSettingsPopup settingsPopup; // 0x20
		public PokyHomeNextModule nextModule; // 0x28
		[Tooltip("Ngu\u1ED3n ti\u1EBFng b\u1EA5m. N\u00FAt PokyHome ch\u1EA1y b\u1EB1ng HomePressScale (kh\u00F4ng c\u00F3 component Button) n\u00EAn ButtonClickSound kh\u00F4ng b\u1EAFt \u0111\u01B0\u1EE3c \u2014 ph\u1EA3i ph\u00E1t th\u1EE7 c\u00F4ng t\u1EA1i \u0111\u00E2y.")]
		public HomeAudio homeAudio; // 0x30
		private float _lastRouteAt; // 0x38
	
		// Properties
		public static PokyHomeFeatureRouter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C2B190-0x0000000180C2B1D0 0x0000000180C2B1D0-0x0000000180C2B270
		public bool Busy { get; } // 0x0000000180C2B270-0x0000000180C2B2D0 
		public static bool HubMode { get; } // 0x0000000180C2B2D0-0x0000000180C2B430 
	
		// Constructors
		public PokyHomeFeatureRouter(); // 0x0000000180C2C6B0-0x0000000180C2C700
	
		// Methods
		private void Awake(); // 0x0000000180C2B430-0x0000000180C2B440
		private void OnDestroy(); // 0x0000000180C2B440-0x0000000180C2B5A0
		public void OpenModule(PokyHomeModuleView view); // 0x0000000180C2B5A0-0x0000000180C2B6A0
		public void Open(string routeKey); // 0x0000000180C2B6A0-0x0000000180C2B6D0
		public void Open(string routeKey, int requireLevel, string flagKey, PokyHomeModuleView view); // 0x0000000180C2B6D0-0x0000000180C2C040
		private static bool HasOwnClickSound(PokyHomeModuleView view); // 0x0000000180C2C040-0x0000000180C2C290
		public void GoToHub(string routeKey); // 0x0000000180C2C290-0x0000000180C2C530
		private void PushHistory(); // 0x0000000180C2C530-0x0000000180C2C6B0
	}
}
