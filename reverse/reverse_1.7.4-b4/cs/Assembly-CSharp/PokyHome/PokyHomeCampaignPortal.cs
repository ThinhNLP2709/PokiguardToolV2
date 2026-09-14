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
	public class PokyHomeCampaignPortal : MonoBehaviour // TypeDefIndex: 2645
	{
		// Fields
		public const int MAX_PARTICLES = 60; // Metadata: 0x005F26F0
		[Tooltip("C\u00E1c h\u1EC7 h\u1EA1t c\u1EE7a c\u1ED5ng (builder \u0111i\u1EC1n: Particle, Circle).")]
		public ParticleSystem[] systems; // 0x20
		private bool _playing; // 0x28
	
		// Constructors
		public PokyHomeCampaignPortal(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180C2A790-0x0000000180C2A9A0
		private void OnEnable(); // 0x0000000180C2A9A0-0x0000000180C2A9B0
		private void OnDisable(); // 0x0000000180C2A9B0-0x0000000180C2A9C0
		private void OnApplicationPause(bool paused); // 0x0000000180C2A9C0-0x0000000180C2A9D0
		public void SetPlaying(bool play); // 0x0000000180C2A9D0-0x0000000180C2ABF0
	}
}
