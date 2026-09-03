/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[DebuggerDisplay("Size = {size} Capacity = {capacity}")]
	public class DynamicString : DynamicArray<char> // TypeDefIndex: 5372
	{
		// Constructors
		public DynamicString(); // 0x0000000181E49030-0x0000000181E49070
		public DynamicString(string s); // 0x0000000181E48F70-0x0000000181E49030
		public DynamicString(int capacity); // 0x0000000181E49070-0x0000000181E490C0
	
		// Methods
		public void Append(string s); // 0x0000000181E48E70-0x0000000181E48F40
		public void Append(DynamicString s); // 0x0000000181E48E20-0x0000000181E48E70
		public override string ToString(); // 0x0000000181E48F40-0x0000000181E48F70
	}
}
