/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerBackdrop : MonoBehaviour // TypeDefIndex: 2811
	{
		// Fields
		public const string NODE_NAME = "img_Backdrop"; // Metadata: 0x005F1C74
		public const string N_SOURCE = "img_Background"; // Metadata: 0x005F1C81
		public const string N_FILL = "img_Fill"; // Metadata: 0x005F1C90
		public static readonly Vector2 ART_SIZE; // 0x00
		private RectTransform _rt; // 0x20
		private RectTransform _fill; // 0x28
		private RectTransform _parent; // 0x30
		private Vector2 _artSize; // 0x38
		private float _lastW; // 0x40
		private float _lastH; // 0x44
		private Vector2 _wantSize; // 0x48
		public const int SHELL_SIBLING = 1; // Metadata: 0x005F1C99
	
		// Properties
		public Image Fill { get; } // 0x0000000180CEA4B0-0x0000000180CEA5D0 
		private Vector2 ArtSize { get; } // 0x0000000180CEA5D0-0x0000000180CEA670 
	
		// Constructors
		public InfoPlayerBackdrop(); // 0x0000000180CEC840-0x0000000180CEC8B0
		static InfoPlayerBackdrop(); // 0x0000000180CEC8B0-0x0000000180CEC900
	
		// Methods
		public static InfoPlayerBackdrop Ensure(Transform popupRoot); // 0x0000000180CEA670-0x0000000180CEAB40
		public static InfoPlayerBackdrop Create(Transform root, Vector2 artSize, int siblingIndex); // 0x0000000180CEAB40-0x0000000180CEADC0
		public static Image EnsureShell(Transform popupRoot); // 0x0000000180CEADC0-0x0000000180CEAF00
		private static InfoPlayerBackdrop Find(Transform root); // 0x0000000180CEAF00-0x0000000180CEB090
		private static InfoPlayerBackdrop Build(Transform root, int siblingIndex, Vector2 artSize); // 0x0000000180CEB090-0x0000000180CEBAB0
		private void OnEnable(); // 0x0000000180CEBAB0-0x0000000180CEBDA0
		private void LateUpdate(); // 0x0000000180CEBDA0-0x0000000180CEC150
		public void Refit(); // 0x0000000180CEC150-0x0000000180CEC840
	}
}
