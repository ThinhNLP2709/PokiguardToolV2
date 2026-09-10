/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	public class ShopAvatarTabBar // TypeDefIndex: 2331
	{
		// Fields
		public const string N_SCROLL = "sec_TabScroll"; // Metadata: 0x0068E948
		public const string N_CONTENT = "TabContent"; // Metadata: 0x0068E956
		public const string N_PREFIX = "btn_Tab_"; // Metadata: 0x0068E961
		public const string N_BG = "img_Bg"; // Metadata: 0x0068E96A
		public const string N_ON = "img_On"; // Metadata: 0x0068E971
		public const string N_LABEL = "txt_Label"; // Metadata: 0x0068E978
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
		public int Selection { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C660-0x000000018039C670 0x000000018039DCC0-0x000000018039DCD0
		public bool PortraitVisible { get; } // 0x00000001807C5E30-0x00000001807C5F40 
	
		// Events
		public event Action<int> Selected {
			add; // 0x00000001807C5D70-0x00000001807C5E30
			remove; // 0x00000001807C5F40-0x00000001807C6000
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass21_0 // TypeDefIndex: 2332
		{
			// Fields
			public int captured; // 0x10
			public ShopAvatarTabBar __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass21_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _AutoWire_b__0(); // 0x00000001807C6EB0-0x00000001807C6EE0
		}
	
		// Constructors
		public ShopAvatarTabBar(); // 0x00000001807C5C00-0x00000001807C5D70
		static ShopAvatarTabBar(); // 0x00000001807C5BA0-0x00000001807C5C00
	
		// Methods
		public void AutoWire(Transform panelRoot, Action<string> reportMissing); // 0x00000001807C4C00-0x00000001807C5310
		public void RefreshLabels(); // 0x00000001807C5390-0x00000001807C5560
		private void Raise(int index); // 0x00000001807C5310-0x00000001807C5390
		public void SetPortraitVisible(bool on); // 0x00000001807C5A50-0x00000001807C5BA0
		public void Select(int index); // 0x00000001807C57F0-0x00000001807C5A50
		private void ScrollTo(int index); // 0x00000001807C5560-0x00000001807C57F0
	}
}
