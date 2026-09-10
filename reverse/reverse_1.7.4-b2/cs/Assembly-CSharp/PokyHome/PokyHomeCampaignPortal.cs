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
	public class PokyHomeCampaignPortal : MonoBehaviour // TypeDefIndex: 2202
	{
		// Fields
		public const int MAX_PARTICLES = 60; // Metadata: 0x0068E1BB
		[Tooltip("C\u00E1c h\u1EC7 h\u1EA1t c\u1EE7a c\u1ED5ng (builder \u0111i\u1EC1n: Particle, Circle).")]
		public ParticleSystem[] systems; // 0x20
		private bool _playing; // 0x28
	
		// Constructors
		public PokyHomeCampaignPortal(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void Awake(); // 0x000000018076B680-0x000000018076B7A0
		private void OnEnable(); // 0x000000018076B7C0-0x000000018076B7D0
		private void OnDisable(); // 0x000000018076B7B0-0x000000018076B7C0
		private void OnApplicationPause(bool paused); // 0x000000018076B7A0-0x000000018076B7B0
		public void SetPlaying(bool play); // 0x000000018076B7D0-0x000000018076B940
	}
}
