/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[CreateAssetMenu(fileName = "HomeModuleConfig", menuName = "Pokiguard/Home Module Config")]
public class HomeModuleConfig : ScriptableObject // TypeDefIndex: 975
{
	// Fields
	public List<HomeModuleDef> modules; // 0x18

	// Constructors
	public HomeModuleConfig(); // 0x00000001805E9430-0x00000001805E9500

	// Methods
	public HomeModuleDef Find(string id); // 0x00000001805E70F0-0x00000001805E7220
	public static List<HomeModuleDef> BuildDefaults(); // 0x00000001805E7220-0x00000001805E8E60
	private static void AddB(List<HomeModuleDef> list, string id, string sprite, int requireLevel, string route); // 0x00000001805E8E60-0x00000001805E8FB0
	private static void Add(List<HomeModuleDef> list, string id, string locKey, string sprite, int requireLevel, string route, HomeNotifySource notify = HomeNotifySource.None /* Metadata: 0x005EF1BB */); // 0x00000001805E8FB0-0x00000001805E9110
	private static void Push(List<HomeModuleDef> list, string id, string label, string sprite, int requireLevel, string route, HomeNotifySource notify); // 0x00000001805E9110-0x00000001805E9430
}

