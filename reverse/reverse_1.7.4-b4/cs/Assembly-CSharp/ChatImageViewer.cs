/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class ChatImageViewer : MonoBehaviour // TypeDefIndex: 496
{
	// Fields
	public const int SORTING_ORDER = 9400; // Metadata: 0x005EF543
	private const float OPEN_SECONDS = 0.18f; // Metadata: 0x005EF547
	private const float DIM_ALPHA = 0.85f; // Metadata: 0x005EF54B
	private static ChatImageViewer _instance; // 0x00
	private RectTransform _panel; // 0x20
	private Image _photo; // 0x28
	private UnityEngine.UI.Text _txtExpire; // 0x30
	private CanvasGroup _group; // 0x38
	private string _currentId; // 0x40

	// Properties
	public static bool IsShowing { get; } // 0x000000018039A0D0-0x000000018039A250 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 497
	{
		// Fields
		public ChatImageViewer __4__this; // 0x10
		public string wanted; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Present_b__0(Texture2D tex); // 0x000000018039C320-0x000000018039C5D0
		internal void _Present_b__1(); // 0x000000018039C5D0-0x000000018039C750
	}

	// Constructors
	public ChatImageViewer(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Show(string id, int w, int h, long expiresAtMs); // 0x000000018039A250-0x000000018039A430
	public static void Hide(); // 0x000000018039A430-0x000000018039A700
	private static ChatImageViewer Resolve(); // 0x000000018039A700-0x000000018039A980
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetOnPlay(); // 0x000000018039A980-0x000000018039AA20
	private void Build(); // 0x000000018039AA20-0x000000018039B8A0
	private void Present(string id, int w, int h, long expiresAtMs); // 0x000000018039B8A0-0x000000018039BD00
	private void PlayOpenFx(); // 0x000000018039BD00-0x000000018039C0A0
	private static GameObject NewChild(Transform parent, string name); // 0x000000018039C0A0-0x000000018039C320
}

