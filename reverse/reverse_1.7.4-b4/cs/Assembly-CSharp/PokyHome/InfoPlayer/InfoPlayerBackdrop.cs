/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerBackdrop : MonoBehaviour // TypeDefIndex: 2818
	{
		// Fields
		public const string NODE_NAME = "img_Backdrop"; // Metadata: 0x005F308B
		public const string N_SOURCE = "img_Background"; // Metadata: 0x005F3098
		public const string N_FILL = "img_Fill"; // Metadata: 0x005F30A7
		public static readonly Vector2 ART_SIZE; // 0x00
		private RectTransform _rt; // 0x20
		private RectTransform _fill; // 0x28
		private RectTransform _parent; // 0x30
		private Vector2 _artSize; // 0x38
		private float _lastW; // 0x40
		private float _lastH; // 0x44
		private Vector2 _wantSize; // 0x48
		public const int SHELL_SIBLING = 1; // Metadata: 0x005F30B0
	
		// Properties
		public Image Fill { get; } // 0x0000000180CF7D30-0x0000000180CF7E50 
		private Vector2 ArtSize { get; } // 0x0000000180CF7E50-0x0000000180CF7EF0 
	
		// Constructors
		public InfoPlayerBackdrop(); // 0x0000000180CFA0C0-0x0000000180CFA130
		static InfoPlayerBackdrop(); // 0x0000000180CFA130-0x0000000180CFA180
	
		// Methods
		public static InfoPlayerBackdrop Ensure(Transform popupRoot); // 0x0000000180CF7EF0-0x0000000180CF83C0
		public static InfoPlayerBackdrop Create(Transform root, Vector2 artSize, int siblingIndex); // 0x0000000180CF83C0-0x0000000180CF8640
		public static Image EnsureShell(Transform popupRoot); // 0x0000000180CF8640-0x0000000180CF8780
		private static InfoPlayerBackdrop Find(Transform root); // 0x0000000180CF8780-0x0000000180CF8910
		private static InfoPlayerBackdrop Build(Transform root, int siblingIndex, Vector2 artSize); // 0x0000000180CF8910-0x0000000180CF9330
		private void OnEnable(); // 0x0000000180CF9330-0x0000000180CF9620
		private void LateUpdate(); // 0x0000000180CF9620-0x0000000180CF99D0
		public void Refit(); // 0x0000000180CF99D0-0x0000000180CFA0C0
	}
}
