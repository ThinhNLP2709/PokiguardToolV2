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
	public class PokyHubShell : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1868
	{
		// Fields
		private static readonly string[] RETURN_FLAGS; // 0x00
		[CompilerGenerated]
		private static PokyHubShell _Instance_k__BackingField; // 0x08
		[Header("Th\u00E0nh ph\u1EA7n c\u1EE7a v\u1ECF")]
		public PokyHubBinder binder; // 0x20
		public PokyHubActions actions; // 0x28
		public PokyHubLegacyShell legacyShell; // 0x30
		public PokyHomeFeatureRouter router; // 0x38
		public PokySettingsPopup settings; // 0x40
		[Header("Canvas g\u1ED1c c\u1EE7a v\u1ECF (builder \u0111i\u1EC1n \u2014 worldCamera g\u00E1n l\u00FAc ch\u1EA1y)")]
		public Canvas[] rootCanvases; // 0x48
		[Header("Hi\u1EC7u \u1EE9ng treo \u0111\u01B0\u1EE3c khi v\u00E0o tr\u1EADn")]
		public PokyHomeFloatAnim[] floatAnims; // 0x50
		public PokyHomeCampaignPortal[] portals; // 0x58
		public PokyHomeEventStrip eventStrip; // 0x60
		public HomeHorizontalScroller scroller; // 0x68
		[Tooltip("Nh\u00F3m UI pop-in nh\u1EB9 l\u00FAc v\u1ECF hi\u1EC7n ra (Bottom / LeftUI / RightUI).")]
		public RectTransform[] uiGroups; // 0x70
		private bool _registered; // 0x78
		private bool _returningFromMatch; // 0x79
		private bool _suspended; // 0x7A
		private bool _bound; // 0x7B
	
		// Properties
		public static PokyHubShell Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018063A600-0x000000018063A650 0x000000018063A650-0x000000018063A6C0
	
		// Constructors
		public PokyHubShell(); // 0x00000001802E7A70-0x00000001802E7BC0
		static PokyHubShell(); // 0x000000018063A4B0-0x000000018063A600
	
		// Methods
		private void Awake(); // 0x0000000180639730-0x0000000180639850
		public void BindToHub(); // 0x0000000180639850-0x00000001806399D0
		private void OnEnable(); // 0x0000000180639C70-0x0000000180639CD0
		private void OnDisable(); // 0x0000000180639C10-0x0000000180639C70
		private void Start(); // 0x000000018063A150-0x000000018063A1F0
		private void OnDestroy(); // 0x00000001806399D0-0x0000000180639C10
		private void WireCamera(Transform hubCanvasRoot); // 0x000000018063A1F0-0x000000018063A4B0
		private void PlayEnterAnimation(); // 0x0000000180639D10-0x0000000180639FA0
		public void OnHubSuspend(); // 0x0000000180639CF0-0x0000000180639D10
		public void OnHubResume(); // 0x0000000180639CD0-0x0000000180639CF0
		private void SetFxRunning(bool on); // 0x0000000180639FA0-0x000000018063A150
	}
}
