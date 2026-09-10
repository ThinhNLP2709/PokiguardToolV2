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
	public class PokyHubNoticeBadge : MonoBehaviour // TypeDefIndex: 2187
	{
		// Fields
		private const float INTERVAL = 1f; // Metadata: 0x0068E103
		[Tooltip("Node \'Notify\' c\u1EE7a n\u00FAt Inbox tr\u00EAn v\u1ECF (Bottom/Inbox/Button/Notify).")]
		public GameObject notifyNode; // 0x20
		[Tooltip("Ch\u1EA5m \u0111\u1ECF tr\u00EAn node \u0111\u00F3 (c\u00F3 th\u00EC d\u00F9ng hi\u1EC7u \u1EE9ng n\u1EA3y v\u00E0o c\u1EE7a n\u00F3).")]
		public HomeNotifyBadge badge; // 0x28
		private float _timer; // 0x30
		private bool _has; // 0x34
	
		// Constructors
		public PokyHubNoticeBadge(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void OnEnable(); // 0x0000000180773BB0-0x0000000180773BC0
		private void Update(); // 0x0000000180773D10-0x0000000180773DF0
		private void Tick(); // 0x0000000180773BC0-0x0000000180773D10
		private static bool ComputeHasNew(); // 0x0000000180773B20-0x0000000180773BB0
	}
}
