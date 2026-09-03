/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public class FastAction // TypeDefIndex: 11767
	{
		// Fields
		private LinkedList<Action> delegates; // 0x10
		private Dictionary<Action, LinkedListNode<Action>> lookup; // 0x18
	
		// Constructors
		public FastAction(); // 0x000000018206CF90-0x000000018206D040
	
		// Methods
		public void Add(Action rhs); // 0x000000018206CDB0-0x000000018206CE70
		public void Remove(Action rhs); // 0x000000018206CED0-0x000000018206CF90
		public void Call(); // 0x000000018206CE70-0x000000018206CED0
	}
}
