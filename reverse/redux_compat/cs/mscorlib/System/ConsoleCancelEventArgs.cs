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

namespace System
{
	[Serializable]
	public sealed class ConsoleCancelEventArgs : EventArgs // TypeDefIndex: 2379
	{
		// Fields
		private readonly ConsoleSpecialKey _type; // 0x10
		[CompilerGenerated]
		private bool _Cancel_k__BackingField; // 0x14
	
		// Properties
		public bool Cancel { [CompilerGenerated] get; } // 0x0000000181102980-0x0000000181102990 
	
		// Constructors
		internal ConsoleCancelEventArgs(ConsoleSpecialKey type); // 0x0000000181615530-0x0000000181615590
		internal ConsoleCancelEventArgs(); // 0x0000000181615590-0x00000001816155C0
	}
}
