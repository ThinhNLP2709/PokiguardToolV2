/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public abstract class TMP_InputValidator : ScriptableObject // TypeDefIndex: 11852
	{
		// Constructors
		protected TMP_InputValidator(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public abstract char Validate(ref string text, ref int pos, char ch);
	}
}
