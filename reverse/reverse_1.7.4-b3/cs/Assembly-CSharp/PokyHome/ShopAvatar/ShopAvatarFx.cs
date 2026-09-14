/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ShopAvatarFx : MonoBehaviour // TypeDefIndex: 2759
	{
		// Fields
		public const string FLAG = "shopavatar.fx"; // Metadata: 0x005F1786
		private readonly List<int> _tweens; // 0x20
		private readonly List<GameObject> _staggered; // 0x28
		private bool _enabled; // 0x30
	
		// Properties
		public bool Enabled { get; } // 0x0000000180CAA500-0x0000000180CAA5A0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass12_0 // TypeDefIndex: 2760
		{
			// Fields
			public Graphic sweepTarget; // 0x10
			public Color baseColor; // 0x18
	
			// Constructors
			public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayBuySuccess_b__0(float v); // 0x0000000180CAC1A0-0x0000000180CAC340
			internal void _PlayBuySuccess_b__1(); // 0x0000000180CAC340-0x0000000180CAC450
		}
	
		// Constructors
		public ShopAvatarFx(); // 0x0000000180CABF40-0x0000000180CAC1A0
	
		// Methods
		public void RefreshFlag(); // 0x0000000180CAA430-0x0000000180CAA500
		private void OnDisable(); // 0x0000000180CAA5A0-0x0000000180CAA5B0
		public void CancelAll(); // 0x0000000180CAA5B0-0x0000000180CAAA40
		public void PlayOpen(RectTransform target); // 0x0000000180CAAA40-0x0000000180CAAD80
		public void PlayGridStagger(IList<ShopAvatarCellView> cells, int visibleCount); // 0x0000000180CAAD80-0x0000000180CAB5A0
		public void PlaySelect(RectTransform frame); // 0x0000000180CAB5A0-0x0000000180CAB8A0
		public void PlayBuySuccess(Graphic sweepTarget); // 0x0000000180CAB8A0-0x0000000180CABD50
		public void PlayWalletChange(UnityEngine.UI.Text target, long value); // 0x0000000180CABD50-0x0000000180CABF40
	}
}
