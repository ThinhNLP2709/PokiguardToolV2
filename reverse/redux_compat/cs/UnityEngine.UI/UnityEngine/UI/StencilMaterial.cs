/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public static class StencilMaterial // TypeDefIndex: 13123
	{
		// Fields
		private static readonly List<MatEntry> m_List; // 0x00
	
		// Nested types
		private class MatEntry // TypeDefIndex: 13124
		{
			// Fields
			public Material baseMat; // 0x10
			public Material customMat; // 0x18
			public int count; // 0x20
			public int stencilId; // 0x24
			public StencilOp operation; // 0x28
			public CompareFunction compareFunction; // 0x2C
			public int readMask; // 0x30
			public int writeMask; // 0x34
			public bool useAlphaClip; // 0x38
			public ColorWriteMask colorMask; // 0x3C
	
			// Constructors
			public MatEntry(); // 0x0000000182599320-0x0000000182599330
		}
	
		// Constructors
		static StencilMaterial(); // 0x00000001825A8FD0-0x00000001825A9060
	
		// Methods
		public static Material Add(Material baseMat, int stencilID, StencilOp operation, CompareFunction compareFunction, ColorWriteMask colorWriteMask); // 0x00000001825A81B0-0x00000001825A8250
		private static void LogWarningWhenNotInBatchmode(string warning, UnityEngine.Object context); // 0x00000001825A8DE0-0x00000001825A8E70
		public static Material Add(Material baseMat, int stencilID, StencilOp operation, CompareFunction compareFunction, ColorWriteMask colorWriteMask, int readMask, int writeMask); // 0x00000001825A8250-0x00000001825A8C40
		public static void Remove(Material customMat); // 0x00000001825A8E70-0x00000001825A8FD0
		public static void ClearAll(); // 0x00000001825A8C40-0x00000001825A8DE0
	}
}
