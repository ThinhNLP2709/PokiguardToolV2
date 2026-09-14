/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	public static class PokyUpgradeFxInjector // TypeDefIndex: 2731
	{
		// Fields
		private static readonly Target[] Targets; // 0x00
	
		// Nested types
		private struct Target // TypeDefIndex: 2732
		{
			// Fields
			public string PanelKey; // 0x00
			public string Node; // 0x08
			public PokyUpgradeFx.Kind Kind; // 0x10
			public float Scale; // 0x14
	
			// Constructors
			public Target(string panelKey, string node, PokyUpgradeFx.Kind kind, float scale); // 0x0000000180C74310-0x0000000180C743E0
		}
	
		// Constructors
		static PokyUpgradeFxInjector(); // 0x0000000180C73E10-0x0000000180C74310
	
		// Methods
		public static int Apply(GameObject root, string panelKey); // 0x0000000180C734E0-0x0000000180C73C20
		private static Transform FindDeep(Transform root, string name); // 0x0000000180C73C20-0x0000000180C73E10
	}
}
