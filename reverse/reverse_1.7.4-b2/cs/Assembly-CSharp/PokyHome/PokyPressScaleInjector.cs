/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	public static class PokyPressScaleInjector // TypeDefIndex: 2250
	{
		// Fields
		public const string FX_SKIN_KEY = "UiFx"; // Metadata: 0x0068E468
		private static readonly HashSet<string> PanelBlacklist; // 0x00
		private static readonly string[] BranchBlacklist; // 0x08
		private static readonly string[] SelfAnimatedComponents; // 0x10
	
		// Properties
		private static bool FxEnabled { get; } // 0x000000018078F650-0x000000018078F6B0 
	
		// Constructors
		static PokyPressScaleInjector(); // 0x000000018078F230-0x000000018078F650
	
		// Methods
		public static int Apply(GameObject root, string panelKey = null); // 0x000000018078EA70-0x000000018078EDE0
		private static bool TryAttach(Button btn, Transform panelRoot); // 0x000000018078EDE0-0x000000018078F230
	}
}
