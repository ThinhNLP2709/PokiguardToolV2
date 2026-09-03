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
	public class PokyHomeCampaignPortal : MonoBehaviour // TypeDefIndex: 1875
	{
		// Fields
		public const int MAX_PARTICLES = 60; // Metadata: 0x0064DD3B
		[Tooltip("C\u00E1c h\u1EC7 h\u1EA1t c\u1EE7a c\u1ED5ng (builder \u0111i\u1EC1n: Particle, Circle).")]
		public ParticleSystem[] systems; // 0x20
		private bool _playing; // 0x28
	
		// Constructors
		public PokyHomeCampaignPortal(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x000000018062A1F0-0x000000018062A310
		private void OnEnable(); // 0x000000018062A330-0x000000018062A340
		private void OnDisable(); // 0x000000018062A320-0x000000018062A330
		private void OnApplicationPause(bool paused); // 0x000000018062A310-0x000000018062A320
		public void SetPlaying(bool play); // 0x000000018062A340-0x000000018062A4B0
	}
}
