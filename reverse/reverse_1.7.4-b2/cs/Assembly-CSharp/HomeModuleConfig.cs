/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[CreateAssetMenu(fileName = "HomeModuleConfig", menuName = "Pokiguard/Home Module Config")]
public class HomeModuleConfig : ScriptableObject // TypeDefIndex: 808
{
	// Fields
	public List<HomeModuleDef> modules; // 0x18

	// Constructors
	public HomeModuleConfig(); // 0x00000001804945D0-0x0000000180494650

	// Methods
	public HomeModuleDef Find(string id); // 0x0000000180494340-0x0000000180494420
	public static List<HomeModuleDef> BuildDefaults(); // 0x0000000180492C40-0x0000000180494340
	private static void AddB(List<HomeModuleDef> list, string id, string sprite, int requireLevel, string route); // 0x00000001804929D0-0x0000000180492B00
	private static void Add(List<HomeModuleDef> list, string id, string locKey, string sprite, int requireLevel, string route, HomeNotifySource notify = HomeNotifySource.None /* Metadata: 0x0068BC54 */); // 0x0000000180492B00-0x0000000180492C40
	private static void Push(List<HomeModuleDef> list, string id, string label, string sprite, int requireLevel, string route, HomeNotifySource notify); // 0x0000000180494420-0x00000001804945D0
}

