/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeLastChat : MonoBehaviour // TypeDefIndex: 2209
	{
		// Fields
		private const int MAX_CHARS = 30; // Metadata: 0x0068E1D0
		private const float SHOW_SEC = 5f; // Metadata: 0x0068E1D1
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
		public bool IsShowing { get; } // 0x0000000180782640-0x0000000180782650 
	
		// Constructors
		public PokyHomeLastChat(); // 0x0000000180782620-0x0000000180782640
	
		// Methods
		private void Awake(); // 0x0000000180781BC0-0x0000000180781C80
		private void OnEnable(); // 0x0000000180781FD0-0x0000000180781FE0
		private void OnDisable(); // 0x0000000180781FC0-0x0000000180781FD0
		private void OnDestroy(); // 0x0000000180781FC0-0x0000000180781FD0
		private void Update(); // 0x0000000180782520-0x0000000180782620
		public void ShowMessage(string user, string message); // 0x00000001807822C0-0x0000000180782440
		public void HideNow(); // 0x0000000180781E80-0x0000000180781EA0
		private void SetVisible(bool on); // 0x0000000180782190-0x00000001807822C0
		private void Hook(); // 0x0000000180781EA0-0x0000000180781FC0
		private void Unhook(); // 0x0000000180782440-0x0000000180782520
		private void HandleMessage(ChatMessageDTO m); // 0x0000000180781C80-0x0000000180781E80
		public static string Sanitize(string raw, int max); // 0x0000000180781FE0-0x0000000180782190
	}
}
