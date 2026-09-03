/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace Poki.Assets.Script.Boss.xephang
{
	public class TopPlayerItem : MonoBehaviour // TypeDefIndex: 2010
	{
		// Fields
		public UnityEngine.UI.Text txtTop; // 0x20
		public Image imgPet; // 0x28
		public Image imgbg; // 0x30
		public UnityEngine.UI.Text txtName; // 0x38
		public UnityEngine.UI.Text txtDame; // 0x40
		private static readonly Color SelfHighlight; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2011
		{
			// Fields
			public TopPlayerItem __4__this; // 0x10
			public int value; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _AnimateDamage_b__0(float v); // 0x000000018067B470-0x000000018067B560
			internal void _AnimateDamage_b__1(); // 0x000000018067B560-0x000000018067B620
		}
	
		// Constructors
		public TopPlayerItem(); // 0x00000001802E7A70-0x00000001802E7BC0
		static TopPlayerItem(); // 0x00000001806776B0-0x00000001806776F0
	
		// Methods
		public void SetupTopPlayer(BossRankingPlayerDTO player); // 0x00000001806772D0-0x00000001806772E0
		public void SetupTopPlayer(BossRankingPlayerDTO player, bool isSelf); // 0x00000001806772E0-0x00000001806776B0
		private void AnimateDamage(int value); // 0x0000000180676EB0-0x0000000180677110
		private void LoadPetAvatar(long petId); // 0x0000000180677110-0x00000001806772D0
	}
}
