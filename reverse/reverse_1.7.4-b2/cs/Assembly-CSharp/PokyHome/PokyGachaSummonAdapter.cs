/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyGachaSummonAdapter : MonoBehaviour // TypeDefIndex: 2236
	{
		// Fields
		[Header("C\u1EDD tr\u1EA1ng th\u00E1i (node \'label\' \u1EA9n trong m\u1ED7i qu\u1EA3 c\u1EA7u)")]
		public UnityEngine.UI.Text shardProbe; // 0x20
		public UnityEngine.UI.Text weaponProbe; // 0x28
		[Header("Khung + qu\u1EA3 c\u1EA7u + t\u00EAn c\u1EE7a hai tab")]
		public Image shardFrame; // 0x30
		public Image weaponFrame; // 0x38
		public Image shardBall; // 0x40
		public Image weaponBall; // 0x48
		public UnityEngine.UI.Text shardName; // 0x50
		public UnityEngine.UI.Text weaponName; // 0x58
		private static readonly Color TintOn; // 0x00
		private static readonly Color TintOff; // 0x10
		private static readonly Color NameOn; // 0x20
		private static readonly Color NameOff; // 0x30
		private static readonly Vector3 ScaleOn; // 0x40
		private static readonly Vector3 ScaleOff; // 0x4C
		private int _state; // 0x60
	
		// Constructors
		public PokyGachaSummonAdapter(); // 0x00000001807804D0-0x00000001807804E0
		static PokyGachaSummonAdapter(); // 0x00000001807803F0-0x00000001807804D0
	
		// Methods
		private void OnEnable(); // 0x00000001807801D0-0x00000001807801F0
		private void LateUpdate(); // 0x0000000180780040-0x00000001807801D0
		private int Read(); // 0x00000001807801F0-0x0000000180780300
		private void Apply(int state); // 0x000000018077FD20-0x0000000180780040
		private static void Tint(Image img, bool on); // 0x0000000180780300-0x00000001807803F0
	}
}
