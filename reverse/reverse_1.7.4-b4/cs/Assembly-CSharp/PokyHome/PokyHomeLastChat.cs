/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeLastChat : MonoBehaviour // TypeDefIndex: 2652
	{
		// Fields
		private const int MAX_CHARS = 30; // Metadata: 0x005F2705
		private const float SHOW_SEC = 5f; // Metadata: 0x005F2706
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
		public bool IsShowing { get; } // 0x0000000180C302E0-0x0000000180C302F0 
	
		// Constructors
		public PokyHomeLastChat(); // 0x0000000180C30E30-0x0000000180C30E90
	
		// Methods
		private void Awake(); // 0x0000000180C2FFF0-0x0000000180C301C0
		private void OnEnable(); // 0x0000000180C301C0-0x0000000180C301D0
		private void OnDisable(); // 0x0000000180C301D0-0x0000000180C301E0
		private void OnDestroy(); // 0x0000000180C301D0-0x0000000180C301E0
		private void Update(); // 0x0000000180C301E0-0x0000000180C302E0
		public void ShowMessage(string user, string message); // 0x0000000180C302F0-0x0000000180C30570
		public void HideNow(); // 0x0000000180C30570-0x0000000180C30590
		private void SetVisible(bool on); // 0x0000000180C30590-0x0000000180C30730
		private void Hook(); // 0x0000000180C30730-0x0000000180C30920
		private void Unhook(); // 0x0000000180C30920-0x0000000180C30A90
		private void HandleMessage(ChatMessageDTO m); // 0x0000000180C30A90-0x0000000180C30C60
		public static string Sanitize(string raw, int max); // 0x0000000180C30C60-0x0000000180C30E30
	}
}
