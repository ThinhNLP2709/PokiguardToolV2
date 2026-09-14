/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	public static class PokyUpgradeFxInjector // TypeDefIndex: 2724
	{
		// Fields
		private static readonly Target[] Targets; // 0x00
	
		// Nested types
		private struct Target // TypeDefIndex: 2725
		{
			// Fields
			public string PanelKey; // 0x00
			public string Node; // 0x08
			public PokyUpgradeFx.Kind Kind; // 0x10
			public float Scale; // 0x14
	
			// Constructors
			public Target(string panelKey, string node, PokyUpgradeFx.Kind kind, float scale); // 0x0000000180C66D50-0x0000000180C66E20
		}
	
		// Constructors
		static PokyUpgradeFxInjector(); // 0x0000000180C66850-0x0000000180C66D50
	
		// Methods
		public static int Apply(GameObject root, string panelKey); // 0x0000000180C65F20-0x0000000180C66660
		private static Transform FindDeep(Transform root, string name); // 0x0000000180C66660-0x0000000180C66850
	}
}
