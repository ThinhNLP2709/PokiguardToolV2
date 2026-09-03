/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

[Serializable]
public class PackedPlayModeBuildLogs // TypeDefIndex: 14024
{
	// Fields
	[SerializeField]
	private List<RuntimeBuildLog> m_RuntimeBuildLogs; // 0x10

	// Properties
	public List<RuntimeBuildLog> RuntimeBuildLogs { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0

	// Nested types
	[Serializable]
	public struct RuntimeBuildLog // TypeDefIndex: 14025
	{
		// Fields
		public LogType Type; // 0x00
		public string Message; // 0x08

		// Constructors
		public RuntimeBuildLog(LogType type, string message); // 0x0000000180F37790-0x0000000180F377B0
	}

	// Constructors
	public PackedPlayModeBuildLogs(); // 0x0000000181C7E1C0-0x0000000181C7E240
}

