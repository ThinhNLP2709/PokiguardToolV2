/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class RemoteEventPanelController : MonoBehaviour // TypeDefIndex: 1755
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
	private sealed class __c // TypeDefIndex: 1756
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action __9__14_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180688150-0x00000001806881C0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Close_b__14_0(); // 0x0000000180687310-0x00000001806873C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1757
	{
		// Fields
		public Action<RemoteEventItem> cb; // 0x10
		public RemoteEventItem ev; // 0x18

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnCta_b__0(); // 0x0000000180687AA0-0x0000000180687B80
	}

	// Constructors
	public RemoteEventPanelController(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void Show(RemoteEventItem ev, Action<RemoteEventItem> onCta); // 0x0000000180680410-0x00000001806806C0
	private void ApplyBanner(RemoteEventItem ev); // 0x0000000180680060-0x0000000180680160
	private void WireButtons(RemoteEventItem ev); // 0x00000001806806C0-0x0000000180680970
	private static string LabelFor(string ctaType); // 0x0000000180680290-0x0000000180680300
	private void OnCta(); // 0x0000000180680300-0x0000000180680410
	private void Close(); // 0x0000000180680160-0x0000000180680290
}

