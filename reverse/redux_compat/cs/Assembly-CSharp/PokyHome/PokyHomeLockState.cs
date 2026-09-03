/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeLockState : MonoBehaviour // TypeDefIndex: 1884
	{
		// Fields
		[Tooltip("G\u1ED1c c\u00E2y UI \u0111\u1EC3 qu\u00E9t view. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
		public Transform root; // 0x20
		private readonly List<PokyHomeModuleView> _views; // 0x28
		private int _level; // 0x30
	
		// Properties
		public int ViewCount { get; } // 0x000000018062F200-0x000000018062F220 
		public int Level { get; } // 0x000000018033D100-0x000000018033D110 
		public IReadOnlyList<PokyHomeModuleView> Views { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public PokyHomeLockState(); // 0x000000018062F180-0x000000018062F200
	
		// Methods
		private void Awake(); // 0x000000018062ED50-0x000000018062EE20
		public void Collect(); // 0x000000018062ED50-0x000000018062EE20
		public void Apply(int userLevel); // 0x000000018062EC50-0x000000018062ED50
		public PokyHomeModuleView Find(string moduleId); // 0x000000018062EE20-0x000000018062EF50
		public void SetNotify(PokyNotifySource src, int count); // 0x000000018062F050-0x000000018062F180
		public bool HasSource(PokyNotifySource src); // 0x000000018062EF50-0x000000018062F050
	}
}
