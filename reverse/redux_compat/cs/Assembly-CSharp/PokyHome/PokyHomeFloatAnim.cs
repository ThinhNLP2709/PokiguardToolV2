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
	public class PokyHomeFloatAnim : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1878
	{
		// Fields
		[Tooltip("Bi\u00EAn \u0111\u1ED9 theo pixel UI (b\u1EA3n g\u1ED1c: 6).")]
		public float amplitude; // 0x20
		[Tooltip("Th\u1EDDi gian \u0111i m\u1ED9t chi\u1EC1u (gi\u00E2y). B\u1EA3n g\u1ED1c ~1.5 s m\u1ED7i chi\u1EC1u.")]
		public float halfPeriod; // 0x24
		[Tooltip("Tr\u1EC5 kh\u1EDFi \u0111\u1ED9ng \u2014 builder r\u1EA3i ng\u1EABu nhi\u00EAn 0\u20261.5 s \u0111\u1EC3 10 to\u00E0 l\u1EC7ch pha.")]
		public float startDelay; // 0x28
		private float _baseY; // 0x2C
		private bool _captured; // 0x30
	
		// Constructors
		public PokyHomeFloatAnim(); // 0x000000018062BC20-0x000000018062BC40
	
		// Methods
		private void Awake(); // 0x000000018062B700-0x000000018062B780
		private void OnDestroy(); // 0x000000018062B7D0-0x000000018062B820
		private void OnEnable(); // 0x000000018062B890-0x000000018062B8E0
		private void OnDisable(); // 0x000000018062B820-0x000000018062B890
		private void Capture(); // 0x000000018062B780-0x000000018062B7D0
		private void RestoreBase(); // 0x000000018062BB90-0x000000018062BC20
		public void Recapture(); // 0x000000018062BAE0-0x000000018062BB90
		public void Play(); // 0x000000018062B980-0x000000018062BAE0
		public void OnHubSuspend(); // 0x000000018062B910-0x000000018062B980
		public void OnHubResume(); // 0x000000018062B8E0-0x000000018062B910
	}
}
