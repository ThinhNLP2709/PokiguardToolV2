/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeLockState : MonoBehaviour // TypeDefIndex: 2654
	{
		// Fields
		[Tooltip("G\u1ED1c c\u00E2y UI \u0111\u1EC3 qu\u00E9t view. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
		public Transform root; // 0x20
		private readonly List<PokyHomeModuleView> _views; // 0x28
		private int _level; // 0x30
	
		// Properties
		public int ViewCount { get; } // 0x0000000180C31F60-0x0000000180C31F80 
		public int Level { get; } // 0x00000001803C6C60-0x00000001803C6C70 
		public IReadOnlyList<PokyHomeModuleView> Views { get; } // 0x00000001802A8730-0x00000001802A8740 
	
		// Constructors
		public PokyHomeLockState(); // 0x0000000180C327D0-0x0000000180C328D0
	
		// Methods
		private void Awake(); // 0x0000000180C31F80-0x0000000180C320D0
		public void Collect(); // 0x0000000180C31F80-0x0000000180C320D0
		public void Apply(int userLevel); // 0x0000000180C320D0-0x0000000180C32270
		public PokyHomeModuleView Find(string moduleId); // 0x0000000180C32270-0x0000000180C32460
		public void SetNotify(PokyNotifySource src, int count); // 0x0000000180C32460-0x0000000180C32630
		public bool HasSource(PokyNotifySource src); // 0x0000000180C32630-0x0000000180C327D0
	}
}
