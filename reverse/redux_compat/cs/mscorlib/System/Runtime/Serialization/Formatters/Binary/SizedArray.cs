/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	[Serializable]
	internal sealed class SizedArray : ICloneable // TypeDefIndex: 3107
	{
		// Fields
		internal object[] objects; // 0x10
		internal object[] negObjects; // 0x18
	
		// Properties
		internal object this[int index] { get => default; set {} } // 0x000000018151B310-0x000000018151B380 0x000000018151B380-0x000000018151B4B0
	
		// Constructors
		internal SizedArray(); // 0x000000018151B130-0x000000018151B1B0
		internal SizedArray(int length); // 0x000000018151B1B0-0x000000018151B230
		private SizedArray(SizedArray sizedArray); // 0x000000018151B230-0x000000018151B310
	
		// Methods
		public object Clone(); // 0x000000018151AE50-0x000000018151AF50
		internal void IncreaseCapacity(int index); // 0x000000018151AF50-0x000000018151B130
	}
}
