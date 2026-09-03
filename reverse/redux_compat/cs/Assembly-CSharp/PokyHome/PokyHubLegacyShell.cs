/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHubLegacyShell : MonoBehaviour // TypeDefIndex: 1856
	{
		// Fields
		public static readonly string[] LEGACY_NODES; // 0x00
		private readonly List<Entry> _entries; // 0x20
		private Image _canvasBg; // 0x28
		private bool _canvasBgWasEnabled; // 0x30
		private bool _hidden; // 0x31
	
		// Properties
		public bool IsHidden { get; } // 0x0000000180634F10-0x0000000180634F20 
		public int HiddenCount { get; } // 0x0000000180634EF0-0x0000000180634F10 
	
		// Nested types
		private struct Entry // TypeDefIndex: 1857
		{
			// Fields
			public Canvas canvas; // 0x00
			public bool canvasWasEnabled; // 0x08
			public bool canvasAdded; // 0x09
			public CanvasGroup group; // 0x10
			public bool groupWasBlocking; // 0x18
			public bool groupWasInteractable; // 0x19
			public bool groupAdded; // 0x1A
			public GraphicRaycaster raycaster; // 0x20
			public bool raycasterWasEnabled; // 0x28
		}
	
		// Constructors
		public PokyHubLegacyShell(); // 0x0000000180634E70-0x0000000180634EF0
		static PokyHubLegacyShell(); // 0x0000000180634D20-0x0000000180634E70
	
		// Methods
		public void Hide(Transform hubCanvasRoot); // 0x0000000180634510-0x0000000180634910
		public void Restore(); // 0x0000000180634A60-0x0000000180634D20
		private void OnDestroy(); // 0x0000000180634910-0x0000000180634920
		private static Entry HideOne(GameObject go); // 0x00000001806342D0-0x0000000180634510
		private static void RestoreOne(Entry e); // 0x0000000180634920-0x0000000180634A60
	}
}
