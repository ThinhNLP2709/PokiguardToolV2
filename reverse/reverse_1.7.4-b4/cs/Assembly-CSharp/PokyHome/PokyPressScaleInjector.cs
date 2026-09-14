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
	public static class PokyPressScaleInjector // TypeDefIndex: 2693
	{
		// Fields
		private static readonly HashSet<string> PanelBlacklist; // 0x00
		private static readonly string[] BranchBlacklist; // 0x08
		private static readonly string[] SelfAnimatedComponents; // 0x10
	
		// Properties
		private static bool FxEnabled { get; } // 0x0000000180C51EC0-0x0000000180C51F30 
	
		// Constructors
		static PokyPressScaleInjector(); // 0x0000000180C529C0-0x0000000180C52EF0
	
		// Methods
		public static int Apply(GameObject root, string panelKey = null); // 0x0000000180C519B0-0x0000000180C51EC0
		private static bool TryAttach(Button btn, Transform panelRoot); // 0x0000000180C51F30-0x0000000180C529C0
	}
}
