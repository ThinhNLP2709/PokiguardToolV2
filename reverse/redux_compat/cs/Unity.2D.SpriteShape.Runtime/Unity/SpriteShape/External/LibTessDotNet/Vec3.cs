/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal struct Vec3 // TypeDefIndex: 13965
	{
		// Fields
		public static readonly Vec3 Zero; // 0x00
		public float X; // 0x00
		public float Y; // 0x04
		public float Z; // 0x08
	
		// Properties
		public float this[int index] { get => default; set {} } // 0x0000000181C60A10-0x0000000181C60A90 0x0000000181C60A90-0x0000000181C60B10
	
		// Constructors
		static Vec3(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		public static void Sub(ref Vec3 lhs, ref Vec3 rhs, out Vec3 result); // 0x0000000181C60930-0x0000000181C60960
		public static void Neg(ref Vec3 v); // 0x0000000181C60840-0x0000000181C60870
		public static void Dot(ref Vec3 u, ref Vec3 v, out float dot); // 0x0000000181C60770-0x0000000181C607A0
		public static void Normalize(ref Vec3 v); // 0x0000000181C60870-0x0000000181C60930
		public static int LongAxis(ref Vec3 v); // 0x0000000181C607A0-0x0000000181C60840
		public override string ToString(); // 0x0000000181C60960-0x0000000181C60A10
	}
}
