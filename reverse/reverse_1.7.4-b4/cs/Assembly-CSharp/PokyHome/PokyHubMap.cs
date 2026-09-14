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
	[CreateAssetMenu(fileName = "PokyHubMap", menuName = "Pokiguard/PokyHub Map")]
	public class PokyHubMap : ScriptableObject // TypeDefIndex: 2629
	{
		// Fields
		public List<PokyHubRoute> routes; // 0x18
		private static readonly string[] HIDDEN_INFO_SLOTS; // 0x00
	
		// Constructors
		public PokyHubMap(); // 0x0000000180C1D720-0x0000000180C1D7F0
		static PokyHubMap(); // 0x0000000180C1D7F0-0x0000000180C1DA60
	
		// Methods
		public PokyHubRoute Find(string nodeId); // 0x00000001805E8A70-0x00000001805E8BA0
		public static string LabelOf(PokyHubRoute r); // 0x0000000180C1BAE0-0x0000000180C1BBB0
		public static List<PokyHubRoute> BuildDefaults(); // 0x0000000180C1BBB0-0x0000000180C1D4B0
		private static PokyHubRoute R(string nodeId, string routeKey, string label, string flagKey = null, PokyNotifySource notify = PokyNotifySource.None /* Metadata: 0x005F2637 */, string labelKey = null); // 0x0000000180C1D4B0-0x0000000180C1D720
	}
}
