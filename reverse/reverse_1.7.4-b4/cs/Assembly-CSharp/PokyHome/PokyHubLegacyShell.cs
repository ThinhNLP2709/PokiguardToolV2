/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHubLegacyShell : MonoBehaviour // TypeDefIndex: 2626
	{
		// Fields
		public static readonly string[] LEGACY_NODES; // 0x00
		private readonly List<Entry> _entries; // 0x20
		private Image _canvasBg; // 0x28
		private bool _canvasBgWasEnabled; // 0x30
		private bool _hidden; // 0x31
	
		// Properties
		public bool IsHidden { get; } // 0x0000000180C1A070-0x0000000180C1A080 
		public int HiddenCount { get; } // 0x0000000180C1A080-0x0000000180C1A0A0 
	
		// Nested types
		private struct Entry // TypeDefIndex: 2627
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
		public PokyHubLegacyShell(); // 0x0000000180C1B7D0-0x0000000180C1B950
		static PokyHubLegacyShell(); // 0x0000000180C1B950-0x0000000180C1BAE0
	
		// Methods
		public void Hide(Transform hubCanvasRoot); // 0x0000000180C1A0A0-0x0000000180C1A8A0
		public void Restore(); // 0x0000000180C1A8A0-0x0000000180C1ABA0
		private void OnDestroy(); // 0x0000000180C1ABA0-0x0000000180C1ABB0
		private static Entry HideOne(GameObject go); // 0x0000000180C1ABB0-0x0000000180C1B3B0
		private static void RestoreOne(Entry e); // 0x0000000180C1B3B0-0x0000000180C1B7D0
	}
}
