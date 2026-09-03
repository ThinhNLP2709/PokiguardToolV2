/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[IsReadOnly]
	[VisibleToOtherModules(new string[3] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule", "UnityEditor.GraphToolsFoundationModule" })]
	internal struct RenderedText : IEquatable<UnityEngine.TextCore.Text.RenderedText>, IEquatable<string> // TypeDefIndex: 12692
	{
		// Fields
		public readonly string value; // 0x00
		public readonly int valueStart; // 0x08
		public readonly int valueLength; // 0x0C
		public readonly string suffix; // 0x10
		public readonly char repeat; // 0x18
		public readonly int repeatCount; // 0x1C
	
		// Properties
		public int CharacterCount { get; } // 0x0000000182333ED0-0x0000000182333EF0 
	
		// Nested types
		public struct Enumerator // TypeDefIndex: 12693
		{
			// Fields
			private readonly RenderedText m_Source; // 0x00
			private int m_Stage; // 0x20
			private int m_StageIndex; // 0x24
			private char m_Current; // 0x28
	
			// Properties
			public char Current { get; } // 0x0000000182330C20-0x0000000182330C30 
	
			// Constructors
			public Enumerator([IsReadOnly] in RenderedText source); // 0x0000000182330BF0-0x0000000182330C20
	
			// Methods
			public bool MoveNext(); // 0x0000000182330B30-0x0000000182330BF0
		}
	
		// Constructors
		public RenderedText(string value); // 0x0000000182333C10-0x0000000182333CD0
		public RenderedText(string value, string suffix); // 0x0000000182333D90-0x0000000182333E60
		public RenderedText(string value, int start, int length, string suffix = null); // 0x0000000182333CD0-0x0000000182333D90
		public RenderedText(char repeat, int repeatCount, string suffix = null); // 0x0000000182333E60-0x0000000182333ED0
	
		// Methods
		public Enumerator GetEnumerator(); // 0x0000000182333B20-0x0000000182333B60
		public string CreateString(); // 0x0000000182333610-0x00000001823337A0
		public bool Equals(RenderedText other); // 0x00000001823337A0-0x0000000182333820
		public bool Equals(string other); // 0x0000000182333A20-0x0000000182333B20
		public override bool Equals(object obj); // 0x0000000182333820-0x0000000182333A20
		public override int GetHashCode(); // 0x0000000182333B60-0x0000000182333C10
	}
}
