/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHubLegacyShell : MonoBehaviour // TypeDefIndex: 2619
	{
		// Fields
		public static readonly string[] LEGACY_NODES; // 0x00
		private readonly List<Entry> _entries; // 0x20
		private Image _canvasBg; // 0x28
		private bool _canvasBgWasEnabled; // 0x30
		private bool _hidden; // 0x31
	
		// Properties
		public bool IsHidden { get; } // 0x0000000180C0CC30-0x0000000180C0CC40 
		public int HiddenCount { get; } // 0x0000000180C0CC40-0x0000000180C0CC60 
	
		// Nested types
		private struct Entry // TypeDefIndex: 2620
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
		public PokyHubLegacyShell(); // 0x0000000180C0E390-0x0000000180C0E510
		static PokyHubLegacyShell(); // 0x0000000180C0E510-0x0000000180C0E6A0
	
		// Methods
		public void Hide(Transform hubCanvasRoot); // 0x0000000180C0CC60-0x0000000180C0D460
		public void Restore(); // 0x0000000180C0D460-0x0000000180C0D760
		private void OnDestroy(); // 0x0000000180C0D760-0x0000000180C0D770
		private static Entry HideOne(GameObject go); // 0x0000000180C0D770-0x0000000180C0DF70
		private static void RestoreOne(Entry e); // 0x0000000180C0DF70-0x0000000180C0E390
	}
}
