/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class HWStack : ICloneable // TypeDefIndex: 6849
	{
		// Fields
		private object[] stack; // 0x10
		private int growthRate; // 0x18
		private int used; // 0x1C
		private int size; // 0x20
		private int limit; // 0x24
	
		// Properties
		internal object this[int index] { get => default; set {} } // 0x0000000181A7F690-0x0000000181A7F710 0x0000000181A7F710-0x0000000181A7F7E0
		internal int Length { get; } // 0x0000000180B232F0-0x0000000180B23300 
	
		// Constructors
		internal HWStack(int GrowthRate); // 0x0000000181A7F610-0x0000000181A7F690
		internal HWStack(int GrowthRate, int limit); // 0x0000000181A7F590-0x0000000181A7F610
		private HWStack(object[] stack, int growthRate, int used, int size); // 0x0000000181A7F530-0x0000000181A7F590
	
		// Methods
		internal object Push(); // 0x0000000181A7F400-0x0000000181A7F530
		internal object Pop(); // 0x0000000181A7F3C0-0x0000000181A7F400
		internal object Peek(); // 0x0000000181A7F380-0x0000000181A7F3C0
		internal void AddToTop(object o); // 0x0000000181A7F1E0-0x0000000181A7F270
		public object Clone(); // 0x0000000181A7F270-0x0000000181A7F380
	}
}
