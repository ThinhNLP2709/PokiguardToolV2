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
	[CreateAssetMenu(fileName = "PokyHomeModuleConfig", menuName = "Pokiguard/PokyHome Module Config")]
	public class PokyHomeModuleConfig : ScriptableObject // TypeDefIndex: 1887
	{
		// Fields
		public List<PokyHomeModuleDef> modules; // 0x18
		private static readonly string[] INFO_SLOTS; // 0x00
	
		// Constructors
		public PokyHomeModuleConfig(); // 0x0000000180630D00-0x0000000180630D80
		static PokyHomeModuleConfig(); // 0x0000000180630960-0x0000000180630D00
	
		// Methods
		public PokyHomeModuleDef Find(string id); // 0x00000001803B4A00-0x00000001803B4AE0
		public static List<PokyHomeModuleDef> BuildDefaults(); // 0x000000018062F220-0x0000000180630810
		private static PokyHomeModuleDef M(string id, string labelKey, string sprite, string gray, int level, string route, PokyNotifySource notify = PokyNotifySource.None /* Metadata: 0x0064DD6B */); // 0x0000000180630810-0x0000000180630960
	}
}
