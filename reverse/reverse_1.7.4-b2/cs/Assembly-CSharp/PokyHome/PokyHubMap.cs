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
	[CreateAssetMenu(fileName = "PokyHubMap", menuName = "Pokiguard/PokyHub Map")]
	public class PokyHubMap : ScriptableObject // TypeDefIndex: 2186
	{
		// Fields
		public List<PokyHubRoute> routes; // 0x18
		private static readonly string[] HIDDEN_INFO_SLOTS; // 0x00
	
		// Constructors
		public PokyHubMap(); // 0x0000000180773AA0-0x0000000180773B20
		static PokyHubMap(); // 0x0000000180773850-0x0000000180773AA0
	
		// Methods
		public PokyHubRoute Find(string nodeId); // 0x0000000180494340-0x0000000180494420
		public static string LabelOf(PokyHubRoute r); // 0x0000000180773660-0x0000000180773720
		public static List<PokyHubRoute> BuildDefaults(); // 0x00000001807718F0-0x0000000180773660
		private static PokyHubRoute R(string nodeId, string routeKey, string label, string flagKey = null, PokyNotifySource notify = PokyNotifySource.None /* Metadata: 0x0068E102 */, string labelKey = null); // 0x0000000180773720-0x0000000180773850
	}
}
