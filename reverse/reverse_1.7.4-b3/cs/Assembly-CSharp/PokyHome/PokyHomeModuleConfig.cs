/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[CreateAssetMenu(fileName = "PokyHomeModuleConfig", menuName = "Pokiguard/PokyHome Module Config")]
	public class PokyHomeModuleConfig : ScriptableObject // TypeDefIndex: 2650
	{
		// Fields
		public List<PokyHomeModuleDef> modules; // 0x18
		private static readonly string[] INFO_SLOTS; // 0x00
	
		// Constructors
		public PokyHomeModuleConfig(); // 0x0000000180C26CC0-0x0000000180C26D90
		static PokyHomeModuleConfig(); // 0x0000000180C26D90-0x0000000180C27120
	
		// Methods
		public PokyHomeModuleDef Find(string id); // 0x00000001805E70F0-0x00000001805E7220
		public static List<PokyHomeModuleDef> BuildDefaults(); // 0x0000000180C25100-0x0000000180C269A0
		private static PokyHomeModuleDef M(string id, string labelKey, string sprite, string gray, int level, string route, PokyNotifySource notify = PokyNotifySource.None /* Metadata: 0x005F12F6 */); // 0x0000000180C269A0-0x0000000180C26CC0
	}
}
