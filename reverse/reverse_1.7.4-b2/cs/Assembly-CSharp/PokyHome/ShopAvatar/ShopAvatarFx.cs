/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ShopAvatarFx : MonoBehaviour // TypeDefIndex: 2324
	{
		// Fields
		public const string FLAG = "shopavatar.fx"; // Metadata: 0x0068E819
		private readonly List<int> _tweens; // 0x20
		private readonly List<GameObject> _staggered; // 0x28
		private bool _enabled; // 0x30
	
		// Properties
		public bool Enabled { get; } // 0x00000001807BFDB0-0x00000001807BFE10 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass12_0 // TypeDefIndex: 2325
		{
			// Fields
			public Graphic sweepTarget; // 0x10
			public Color baseColor; // 0x18
	
			// Constructors
			public __c__DisplayClass12_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _PlayBuySuccess_b__0(float v); // 0x00000001807C6D00-0x00000001807C6E20
			internal void _PlayBuySuccess_b__1(); // 0x00000001807C6E20-0x00000001807C6EB0
		}
	
		// Constructors
		public ShopAvatarFx(); // 0x00000001807BFCE0-0x00000001807BFDB0
	
		// Methods
		public void RefreshFlag(); // 0x00000001807BFC20-0x00000001807BFCE0
		private void OnDisable(); // 0x00000001807BEB50-0x00000001807BEB60
		public void CancelAll(); // 0x00000001807BE880-0x00000001807BEB50
		public void PlayOpen(RectTransform target); // 0x00000001807BF560-0x00000001807BF7F0
		public void PlayGridStagger(IList<ShopAvatarCellView> cells, int visibleCount); // 0x00000001807BEEB0-0x00000001807BF560
		public void PlaySelect(RectTransform frame); // 0x00000001807BF7F0-0x00000001807BFA90
		public void PlayBuySuccess(Graphic sweepTarget); // 0x00000001807BEB60-0x00000001807BEEB0
		public void PlayWalletChange(UnityEngine.UI.Text target, long value); // 0x00000001807BFA90-0x00000001807BFC20
	}
}
