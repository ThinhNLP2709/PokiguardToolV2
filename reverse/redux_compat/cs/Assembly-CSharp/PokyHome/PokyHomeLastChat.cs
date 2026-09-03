/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeLastChat : MonoBehaviour // TypeDefIndex: 1882
	{
		// Fields
		private const int MAX_CHARS = 30; // Metadata: 0x0064DD50
		private const float SHOW_SEC = 5f; // Metadata: 0x0064DD51
		[Tooltip("Node hi\u1EC7n/\u1EA9n (b\u1EA3n g\u1ED1c: ch\u00EDnh node LastChat).")]
		public GameObject root; // 0x20
		[Tooltip("D\u00F2ng ch\u1EEF (node \'Text\').")]
		public UnityEngine.UI.Text text; // 0x28
		private ChatService _service; // 0x30
		private bool _hooked; // 0x38
		private float _hideAt; // 0x3C
		private float _retryAt; // 0x40
		private Graphic[] _faces; // 0x48
	
		// Properties
		public bool IsShowing { get; } // 0x000000018062DCF0-0x000000018062DD00 
	
		// Constructors
		public PokyHomeLastChat(); // 0x000000018062DCD0-0x000000018062DCF0
	
		// Methods
		private void Awake(); // 0x000000018062D2F0-0x000000018062D3B0
		private void OnEnable(); // 0x000000018062D700-0x000000018062D710
		private void OnDisable(); // 0x000000018062D6F0-0x000000018062D700
		private void OnDestroy(); // 0x000000018062D6F0-0x000000018062D700
		private void Update(); // 0x000000018062DC50-0x000000018062DCD0
		public void ShowMessage(string user, string message); // 0x000000018062D9F0-0x000000018062DB70
		public void HideNow(); // 0x000000018062D5B0-0x000000018062D5D0
		private void SetVisible(bool on); // 0x000000018062D8C0-0x000000018062D9F0
		private void Hook(); // 0x000000018062D5D0-0x000000018062D6F0
		private void Unhook(); // 0x000000018062DB70-0x000000018062DC50
		private void HandleMessage(ChatMessageDTO m); // 0x000000018062D3B0-0x000000018062D5B0
		public static string Sanitize(string raw, int max); // 0x000000018062D710-0x000000018062D8C0
	}
}
