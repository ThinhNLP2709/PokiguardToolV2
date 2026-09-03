/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public abstract class EventArg // TypeDefIndex: 3977
	{
		// Fields
		private static int s_NextId; // 0x00
		internal readonly int m_Id; // 0x10
	
		// Constructors
		internal EventArg(int id); // 0x00000001802F9040-0x00000001802F9070
		static EventArg(); // 0x000000018239D360-0x000000018239D3A0
	
		// Methods
		public static EventArg<TArg> Create<TArg>();
	}
}
