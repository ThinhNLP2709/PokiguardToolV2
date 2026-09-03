/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[CreateAssetMenu(fileName = "HomeModuleConfig", menuName = "Pokiguard/Home Module Config")]
public class HomeModuleConfig : ScriptableObject // TypeDefIndex: 612
{
	// Fields
	public List<HomeModuleDef> modules; // 0x18

	// Constructors
	public HomeModuleConfig(); // 0x00000001803B4C90-0x00000001803B4D10

	// Methods
	public HomeModuleDef Find(string id); // 0x00000001803B4A00-0x00000001803B4AE0
	public static List<HomeModuleDef> BuildDefaults(); // 0x00000001803B3300-0x00000001803B4A00
	private static void AddB(List<HomeModuleDef> list, string id, string sprite, int requireLevel, string route); // 0x00000001803B3090-0x00000001803B31C0
	private static void Add(List<HomeModuleDef> list, string id, string locKey, string sprite, int requireLevel, string route, HomeNotifySource notify = HomeNotifySource.None /* Metadata: 0x0064C629 */); // 0x00000001803B31C0-0x00000001803B3300
	private static void Push(List<HomeModuleDef> list, string id, string label, string sprite, int requireLevel, string route, HomeNotifySource notify); // 0x00000001803B4AE0-0x00000001803B4C90
}

