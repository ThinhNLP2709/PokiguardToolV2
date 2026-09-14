/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace Poki.Assets.Script.Boss.xephang
{
	public class TopPlayerItem : MonoBehaviour // TypeDefIndex: 2610
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
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2611
		{
			// Fields
			public TopPlayerItem __4__this; // 0x10
			public int value; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _AnimateDamage_b__0(float v); // 0x0000000180C032A0-0x0000000180C03480
			internal void _AnimateDamage_b__1(); // 0x0000000180C03480-0x0000000180C03660
		}
	
		// Constructors
		public TopPlayerItem(); // 0x000000018028A560-0x000000018028A5B0
		static TopPlayerItem(); // 0x0000000180C03250-0x0000000180C032A0
	
		// Methods
		public void SetupTopPlayer(BossRankingPlayerDTO player); // 0x0000000180C023E0-0x0000000180C023F0
		public void SetupTopPlayer(BossRankingPlayerDTO player, bool isSelf); // 0x0000000180C023F0-0x0000000180C02B30
		private void AnimateDamage(int value); // 0x0000000180C02B30-0x0000000180C02EC0
		private void LoadPetAvatar(long petId); // 0x0000000180C02EC0-0x0000000180C03250
	}
}
