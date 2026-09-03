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
	public class Random // TypeDefIndex: 2325
	{
		// Fields
		private int _inext; // 0x10
		private int _inextp; // 0x14
		private int[] _seedArray; // 0x18
		[ThreadStatic]
		private static Random t_threadRandom; // 0x80000000
		private static readonly Random s_globalRandom; // 0x00
	
		// Constructors
		public Random(); // 0x0000000181619AA0-0x0000000181619B00
		public Random(int Seed); // 0x0000000181619B00-0x0000000181619D40
		static Random(); // 0x0000000181619A10-0x0000000181619AA0
	
		// Methods
		protected virtual double Sample(); // 0x00000001816199F0-0x0000000181619A10
		private int InternalSample(); // 0x0000000181619610-0x00000001816196A0
		private static int GenerateSeed(); // 0x0000000181619420-0x00000001816195C0
		private static int GenerateGlobalSeed(); // 0x00000001815FB3A0-0x00000001815FB3D0
		public virtual int Next(); // 0x00000001816199E0-0x00000001816199F0
		private double GetSampleForLargeRange(); // 0x00000001816195C0-0x0000000181619610
		public virtual int Next(int minValue, int maxValue); // 0x00000001816197E0-0x0000000181619920
		public virtual int Next(int maxValue); // 0x0000000181619920-0x00000001816199E0
		public virtual double NextDouble(); // 0x00000001816197C0-0x00000001816197E0
		public virtual void NextBytes(byte[] buffer); // 0x00000001816196A0-0x00000001816197C0
	}
}
