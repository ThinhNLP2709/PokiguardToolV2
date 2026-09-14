/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class ChatImageViewer : MonoBehaviour // TypeDefIndex: 496
{
	// Fields
	public const int SORTING_ORDER = 9400; // Metadata: 0x005EE173
	private const float OPEN_SECONDS = 0.18f; // Metadata: 0x005EE177
	private const float DIM_ALPHA = 0.85f; // Metadata: 0x005EE17B
	private static ChatImageViewer _instance; // 0x00
	private RectTransform _panel; // 0x20
	private Image _photo; // 0x28
	private UnityEngine.UI.Text _txtExpire; // 0x30
	private CanvasGroup _group; // 0x38
	private string _currentId; // 0x40

	// Properties
	public static bool IsShowing { get; } // 0x0000000180399F00-0x000000018039A080 

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
		internal void _Present_b__0(Texture2D tex); // 0x000000018039C150-0x000000018039C400
		internal void _Present_b__1(); // 0x000000018039C400-0x000000018039C580
	}

	// Constructors
	public ChatImageViewer(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Show(string id, int w, int h, long expiresAtMs); // 0x000000018039A080-0x000000018039A260
	public static void Hide(); // 0x000000018039A260-0x000000018039A530
	private static ChatImageViewer Resolve(); // 0x000000018039A530-0x000000018039A7B0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetOnPlay(); // 0x000000018039A7B0-0x000000018039A850
	private void Build(); // 0x000000018039A850-0x000000018039B6D0
	private void Present(string id, int w, int h, long expiresAtMs); // 0x000000018039B6D0-0x000000018039BB30
	private void PlayOpenFx(); // 0x000000018039BB30-0x000000018039BED0
	private static GameObject NewChild(Transform parent, string name); // 0x000000018039BED0-0x000000018039C150
}

