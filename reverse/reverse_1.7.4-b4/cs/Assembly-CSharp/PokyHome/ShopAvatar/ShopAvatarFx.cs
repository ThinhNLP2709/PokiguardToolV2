/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ShopAvatarFx : MonoBehaviour // TypeDefIndex: 2766
	{
		// Fields
		public const string FLAG = "shopavatar.fx"; // Metadata: 0x005F2B9D
		private readonly List<int> _tweens; // 0x20
		private readonly List<GameObject> _staggered; // 0x28
		private bool _enabled; // 0x30
	
		// Properties
		public bool Enabled { get; } // 0x0000000180CB7CD0-0x0000000180CB7D70 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass12_0 // TypeDefIndex: 2767
		{
			// Fields
			public Graphic sweepTarget; // 0x10
			public Color baseColor; // 0x18
	
			// Constructors
			public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayBuySuccess_b__0(float v); // 0x0000000180CB9970-0x0000000180CB9B10
			internal void _PlayBuySuccess_b__1(); // 0x0000000180CB9B10-0x0000000180CB9C20
		}
	
		// Constructors
		public ShopAvatarFx(); // 0x0000000180CB9710-0x0000000180CB9970
	
		// Methods
		public void RefreshFlag(); // 0x0000000180CB7C00-0x0000000180CB7CD0
		private void OnDisable(); // 0x0000000180CB7D70-0x0000000180CB7D80
		public void CancelAll(); // 0x0000000180CB7D80-0x0000000180CB8210
		public void PlayOpen(RectTransform target); // 0x0000000180CB8210-0x0000000180CB8550
		public void PlayGridStagger(IList<ShopAvatarCellView> cells, int visibleCount); // 0x0000000180CB8550-0x0000000180CB8D70
		public void PlaySelect(RectTransform frame); // 0x0000000180CB8D70-0x0000000180CB9070
		public void PlayBuySuccess(Graphic sweepTarget); // 0x0000000180CB9070-0x0000000180CB9520
		public void PlayWalletChange(UnityEngine.UI.Text target, long value); // 0x0000000180CB9520-0x0000000180CB9710
	}
}
