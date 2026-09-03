/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class RemoteEventPanelController : MonoBehaviour // TypeDefIndex: 1503
{
	// Fields
	[Header("N\u1ED9i dung")]
	public UnityEngine.UI.Text titleText; // 0x20
	public UnityEngine.UI.Text bodyText; // 0x28
	public Image bannerImage; // 0x30
	[Header("N\u00FAt")]
	public Button ctaButton; // 0x38
	public UnityEngine.UI.Text ctaLabel; // 0x40
	public Button closeButton; // 0x48
	[Header("Hi\u1EC7u \u1EE9ng \u2014 T\u00D9Y CH\u1ECCN")]
	public CanvasGroup canvasGroup; // 0x50
	private RemoteEventItem _event; // 0x58
	private Action<RemoteEventItem> _onCta; // 0x60

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1504
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__14_0; // 0x08

		// Constructors
		static __c(); // 0x000000018057E150-0x000000018057E1C0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Close_b__14_0(); // 0x000000018057DDE0-0x000000018057DE90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1505
	{
		// Fields
		public Action<RemoteEventItem> cb; // 0x10
		public RemoteEventItem ev; // 0x18

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnCta_b__0(); // 0x000000018057DF00-0x000000018057DFE0
	}

	// Constructors
	public RemoteEventPanelController(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Show(RemoteEventItem ev, Action<RemoteEventItem> onCta); // 0x0000000180572FA0-0x0000000180573250
	private void ApplyBanner(RemoteEventItem ev); // 0x0000000180572BF0-0x0000000180572CF0
	private void WireButtons(RemoteEventItem ev); // 0x0000000180573250-0x0000000180573500
	private static string LabelFor(string ctaType); // 0x0000000180572E20-0x0000000180572E90
	private void OnCta(); // 0x0000000180572E90-0x0000000180572FA0
	private void Close(); // 0x0000000180572CF0-0x0000000180572E20
}

