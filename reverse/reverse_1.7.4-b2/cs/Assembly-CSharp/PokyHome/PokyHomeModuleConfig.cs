/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[CreateAssetMenu(fileName = "PokyHomeModuleConfig", menuName = "Pokiguard/PokyHome Module Config")]
	public class PokyHomeModuleConfig : ScriptableObject // TypeDefIndex: 2214
	{
		// Fields
		public List<PokyHomeModuleDef> modules; // 0x18
		private static readonly string[] INFO_SLOTS; // 0x00
	
		// Constructors
		public PokyHomeModuleConfig(); // 0x00000001807856B0-0x0000000180785730
		static PokyHomeModuleConfig(); // 0x0000000180785310-0x00000001807856B0
	
		// Methods
		public PokyHomeModuleDef Find(string id); // 0x0000000180494340-0x0000000180494420
		public static List<PokyHomeModuleDef> BuildDefaults(); // 0x0000000180783B70-0x00000001807851C0
		private static PokyHomeModuleDef M(string id, string labelKey, string sprite, string gray, int level, string route, PokyNotifySource notify = PokyNotifySource.None /* Metadata: 0x0068E1EB */); // 0x00000001807851C0-0x0000000180785310
	}
}
