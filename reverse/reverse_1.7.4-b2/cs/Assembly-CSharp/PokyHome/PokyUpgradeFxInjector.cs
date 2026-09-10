/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	public static class PokyUpgradeFxInjector // TypeDefIndex: 2288
	{
		// Fields
		private static readonly Target[] Targets; // 0x00
	
		// Nested types
		private struct Target // TypeDefIndex: 2289
		{
			// Fields
			public string PanelKey; // 0x00
			public string Node; // 0x08
			public PokyUpgradeFx.Kind Kind; // 0x10
			public float Scale; // 0x14
	
			// Constructors
			public Target(string panelKey, string node, PokyUpgradeFx.Kind kind, float scale); // 0x00000001807A9140-0x00000001807A9190
		}
	
		// Constructors
		static PokyUpgradeFxInjector(); // 0x00000001807A7DB0-0x00000001807A7FC0
	
		// Methods
		public static int Apply(GameObject root, string panelKey); // 0x00000001807A7770-0x00000001807A7C90
		private static Transform FindDeep(Transform root, string name); // 0x00000001807A7C90-0x00000001807A7DB0
	}
}
