/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	public class ShopAvatarTabBar // TypeDefIndex: 2773
	{
		// Fields
		private static readonly Color LabelOn; // 0x00
		private static readonly Color LabelOff; // 0x10
		private readonly Button[] _buttons; // 0x10
		private readonly GameObject[] _marks; // 0x18
		private readonly UnityEngine.UI.Text[] _labels; // 0x20
		private readonly RectTransform[] _rects; // 0x28
		private ScrollRect _scroll; // 0x30
		private RectTransform _content; // 0x38
		[CompilerGenerated]
		private int _Selection_k__BackingField; // 0x40
		[CompilerGenerated]
		private Action<int> Selected; // 0x48
	
		// Properties
		private int Selection { [CompilerGenerated] set; } // 0x00000001803C6CB0-0x00000001803C6CC0
	
		// Events
		public event Action<int> Selected {
			add; // 0x0000000180CC1990-0x0000000180CC1AB0
			remove; // 0x0000000180CC1AB0-0x0000000180CC1BD0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass21_0 // TypeDefIndex: 2774
		{
			// Fields
			public int captured; // 0x10
			public ShopAvatarTabBar __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass21_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _AutoWire_b__0(); // 0x0000000180CC38B0-0x0000000180CC38E0
		}
	
		// Constructors
		public ShopAvatarTabBar(); // 0x0000000180CC35A0-0x0000000180CC3850
		static ShopAvatarTabBar(); // 0x0000000180CC3850-0x0000000180CC38B0
	
		// Methods
		public void AutoWire(Transform panelRoot, Action<string> reportMissing); // 0x0000000180CC1BD0-0x0000000180CC27C0
		public void RefreshLabels(); // 0x0000000180CC27C0-0x0000000180CC2A00
		private void Raise(int index); // 0x0000000180CC2A00-0x0000000180CC2A80
		public void SetPortraitVisible(bool on); // 0x0000000180CC2A80-0x0000000180CC2D10
		public void Select(int index); // 0x0000000180CC2D10-0x0000000180CC3050
		private void ScrollTo(int index); // 0x0000000180CC3050-0x0000000180CC35A0
	}
}
