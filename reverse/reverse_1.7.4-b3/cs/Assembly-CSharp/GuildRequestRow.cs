/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildRequestRow : MonoBehaviour // TypeDefIndex: 917
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtOnline; // 0x28
	[SerializeField]
	private Button btnView; // 0x30
	[SerializeField]
	private Button btnAgree; // 0x38
	[SerializeField]
	private Button btnDecline; // 0x40
	private static readonly Color DOT_ONLINE; // 0x00
	private static readonly Color DOT_OFFLINE; // 0x10
	private bool _wired; // 0x48
	private GuildRequestItem _data; // 0x50

	// Properties
	public GuildRequestItem Data { get; } // 0x00000001802D8BF0-0x00000001802D8C00 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 918
	{
		// Fields
		public Action<GuildRequestItem> onAgree; // 0x10
		public GuildRequestRow __4__this; // 0x18
		public Action<GuildRequestItem> onDecline; // 0x20
		public Action<GuildRequestItem> onView; // 0x28

		// Constructors
		public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x000000018059E640-0x000000018059E680
		internal void _Bind_b__1(); // 0x000000018059E680-0x000000018059E6C0
		internal void _Bind_b__2(); // 0x000000018059E6C0-0x000000018059E700
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 919
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 from; // 0x18
		public CanvasGroup cg; // 0x20
		public GuildRequestRow __4__this; // 0x28
		public Action onDone; // 0x30

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayResolvedFx_b__0(float k); // 0x000000018059E700-0x000000018059E930
		internal void _PlayResolvedFx_b__1(); // 0x000000018059E930-0x000000018059EBD0
	}

	// Constructors
	public GuildRequestRow(); // 0x000000018028A560-0x000000018028A5B0
	static GuildRequestRow(); // 0x000000018059E5E0-0x000000018059E640

	// Methods
	private void Awake(); // 0x000000018059CEF0-0x000000018059CF00
	private void EnsureWired(); // 0x000000018059CF00-0x000000018059D720
	public void Bind(GuildRequestItem data, bool canManage, Action<GuildRequestItem> onAgree, Action<GuildRequestItem> onDecline, Action<GuildRequestItem> onView); // 0x000000018059D720-0x000000018059DDA0
	public void SetInteractable(bool on); // 0x000000018059DDA0-0x000000018059DF60
	public void PlayResolvedFx(Action onDone); // 0x000000018059DF60-0x000000018059E5E0
}

