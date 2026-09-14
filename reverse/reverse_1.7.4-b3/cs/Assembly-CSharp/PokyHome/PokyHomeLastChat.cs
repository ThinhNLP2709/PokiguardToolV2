/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeLastChat : MonoBehaviour // TypeDefIndex: 2645
	{
		// Fields
		private const int MAX_CHARS = 30; // Metadata: 0x005F12EE
		private const float SHOW_SEC = 5f; // Metadata: 0x005F12EF
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
		public bool IsShowing { get; } // 0x0000000180C22B00-0x0000000180C22B10 
	
		// Constructors
		public PokyHomeLastChat(); // 0x0000000180C23650-0x0000000180C236B0
	
		// Methods
		private void Awake(); // 0x0000000180C22810-0x0000000180C229E0
		private void OnEnable(); // 0x0000000180C229E0-0x0000000180C229F0
		private void OnDisable(); // 0x0000000180C229F0-0x0000000180C22A00
		private void OnDestroy(); // 0x0000000180C229F0-0x0000000180C22A00
		private void Update(); // 0x0000000180C22A00-0x0000000180C22B00
		public void ShowMessage(string user, string message); // 0x0000000180C22B10-0x0000000180C22D90
		public void HideNow(); // 0x0000000180C22D90-0x0000000180C22DB0
		private void SetVisible(bool on); // 0x0000000180C22DB0-0x0000000180C22F50
		private void Hook(); // 0x0000000180C22F50-0x0000000180C23140
		private void Unhook(); // 0x0000000180C23140-0x0000000180C232B0
		private void HandleMessage(ChatMessageDTO m); // 0x0000000180C232B0-0x0000000180C23480
		public static string Sanitize(string raw, int max); // 0x0000000180C23480-0x0000000180C23650
	}
}
