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
	public static class PokyPressScaleInjector // TypeDefIndex: 1924
	{
		// Fields
		public const string FX_SKIN_KEY = "UiFx"; // Metadata: 0x0064DFE8
		private static readonly HashSet<string> PanelBlacklist; // 0x00
		private static readonly string[] BranchBlacklist; // 0x08
		private static readonly string[] SelfAnimatedComponents; // 0x10
	
		// Properties
		private static bool FxEnabled { get; } // 0x000000018064B090-0x000000018064B0F0 
	
		// Constructors
		static PokyPressScaleInjector(); // 0x000000018064AC70-0x000000018064B090
	
		// Methods
		public static int Apply(GameObject root, string panelKey = null); // 0x000000018064A4B0-0x000000018064A820
		private static bool TryAttach(Button btn, Transform panelRoot); // 0x000000018064A820-0x000000018064AC70
	}
}
