/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	public static class PokyUpgradeFxInjector // TypeDefIndex: 1962
	{
		// Fields
		private static readonly Target[] Targets; // 0x00
	
		// Nested types
		private struct Target // TypeDefIndex: 1963
		{
			// Fields
			public string PanelKey; // 0x00
			public string Node; // 0x08
			public PokyUpgradeFx.Kind Kind; // 0x10
			public float Scale; // 0x14
	
			// Constructors
			public Target(string panelKey, string node, PokyUpgradeFx.Kind kind, float scale); // 0x000000018066BA70-0x000000018066BAC0
		}
	
		// Constructors
		static PokyUpgradeFxInjector(); // 0x000000018066A810-0x000000018066AA20
	
		// Methods
		public static int Apply(GameObject root, string panelKey); // 0x000000018066A1D0-0x000000018066A6F0
		private static Transform FindDeep(Transform root, string name); // 0x000000018066A6F0-0x000000018066A810
	}
}
