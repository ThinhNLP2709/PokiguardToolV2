/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class ChatImageViewer : MonoBehaviour // TypeDefIndex: 442
{
	// Fields
	public const int SORTING_ORDER = 9400; // Metadata: 0x0068B2A3
	private const float OPEN_SECONDS = 0.18f; // Metadata: 0x0068B2A7
	private const float DIM_ALPHA = 0.85f; // Metadata: 0x0068B2AB
	private static ChatImageViewer _instance; // 0x00
	private RectTransform _panel; // 0x20
	private Image _photo; // 0x28
	private UnityEngine.UI.Text _txtExpire; // 0x30
	private CanvasGroup _group; // 0x38
	private string _currentId; // 0x40

	// Properties
	public static bool IsShowing { get; } // 0x0000000180371940-0x00000001803719F0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 443
	{
		// Fields
		public ChatImageViewer __4__this; // 0x10
		public string wanted; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Present_b__0(Texture2D tex); // 0x000000018038E600-0x000000018038E7A0
		internal void _Present_b__1(); // 0x000000018038E7A0-0x000000018038E870
	}

	// Constructors
	public ChatImageViewer(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void Show(string id, int w, int h, long expiresAtMs); // 0x00000001803716D0-0x0000000180371940
	public static void Hide(); // 0x0000000180370AA0-0x0000000180370C00
	private static ChatImageViewer Resolve(); // 0x0000000180371590-0x00000001803716D0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetOnPlay(); // 0x0000000180371540-0x0000000180371590
	private void Build(); // 0x000000018036FF40-0x0000000180370AA0
	private void Present(string id, int w, int h, long expiresAtMs); // 0x0000000180370F20-0x0000000180371540
	private void PlayOpenFx(); // 0x0000000180370D70-0x0000000180370F20
	private static GameObject NewChild(Transform parent, string name); // 0x0000000180370C00-0x0000000180370D70
}

