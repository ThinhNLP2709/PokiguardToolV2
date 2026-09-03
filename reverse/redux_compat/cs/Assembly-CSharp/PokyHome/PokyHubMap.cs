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
	[CreateAssetMenu(fileName = "PokyHubMap", menuName = "Pokiguard/PokyHub Map")]
	public class PokyHubMap : ScriptableObject // TypeDefIndex: 1859
	{
		// Fields
		public List<PokyHubRoute> routes; // 0x18
		private static readonly string[] HIDDEN_INFO_SLOTS; // 0x00
	
		// Constructors
		public PokyHubMap(); // 0x0000000180637060-0x00000001806370E0
		static PokyHubMap(); // 0x0000000180636E10-0x0000000180637060
	
		// Methods
		public PokyHubRoute Find(string nodeId); // 0x00000001803B4A00-0x00000001803B4AE0
		public static string LabelOf(PokyHubRoute r); // 0x0000000180636C20-0x0000000180636CE0
		public static List<PokyHubRoute> BuildDefaults(); // 0x0000000180634F20-0x0000000180636C20
		private static PokyHubRoute R(string nodeId, string routeKey, string label, string flagKey = null, PokyNotifySource notify = PokyNotifySource.None /* Metadata: 0x0064DC82 */, string labelKey = null); // 0x0000000180636CE0-0x0000000180636E10
	}
}
