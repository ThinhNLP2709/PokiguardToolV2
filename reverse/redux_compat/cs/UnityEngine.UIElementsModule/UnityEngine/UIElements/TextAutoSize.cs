/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public struct TextAutoSize : IEquatable<UnityEngine.UIElements.TextAutoSize> // TypeDefIndex: 4848
	{
		// Fields
		private Length m_MinSize; // 0x00
		private Length m_MaxSize; // 0x08
		private TextAutoSizeMode m_Mode; // 0x10
	
		// Properties
		public TextAutoSizeMode mode { [IsReadOnly] get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public Length minSize { [IsReadOnly] get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
		public Length maxSize { [IsReadOnly] get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181663F00-0x0000000181663F10
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<TextAutoSize> // TypeDefIndex: 4849
		{
			// Nested types
			private class ModeProperty : Property<TextAutoSize, TextAutoSizeMode> // TypeDefIndex: 4850
			{
				// Fields
				[CompilerGenerated]
				private readonly string _Name_k__BackingField; // 0x18
				[CompilerGenerated]
				private readonly bool _IsReadOnly_k__BackingField; // 0x20
	
				// Properties
				public override string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				public override bool IsReadOnly { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
				// Constructors
				public ModeProperty(); // 0x00000001823CEFD0-0x00000001823CF020
	
				// Methods
				public override TextAutoSizeMode GetValue(ref TextAutoSize container); // 0x0000000180A3D7F0-0x0000000180A3D800
				public override void SetValue(ref TextAutoSize container, TextAutoSizeMode value); // 0x000000018132C240-0x000000018132C250
			}
	
			private class MinSizeProperty : Property<TextAutoSize, Length> // TypeDefIndex: 4851
			{
				// Fields
				[CompilerGenerated]
				private readonly string _Name_k__BackingField; // 0x18
				[CompilerGenerated]
				private readonly bool _IsReadOnly_k__BackingField; // 0x20
	
				// Properties
				public override string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				public override bool IsReadOnly { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
				// Constructors
				public MinSizeProperty(); // 0x00000001823CEF80-0x00000001823CEFD0
	
				// Methods
				public override Length GetValue(ref TextAutoSize container); // 0x0000000180691EA0-0x0000000180691EB0
				public override void SetValue(ref TextAutoSize container, Length value); // 0x00000001823CEF70-0x00000001823CEF80
			}
	
			private class MaxSizeProperty : Property<TextAutoSize, Length> // TypeDefIndex: 4852
			{
				// Fields
				[CompilerGenerated]
				private readonly string _Name_k__BackingField; // 0x18
				[CompilerGenerated]
				private readonly bool _IsReadOnly_k__BackingField; // 0x20
	
				// Properties
				public override string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				public override bool IsReadOnly { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
				// Constructors
				public MaxSizeProperty(); // 0x00000001823CEF20-0x00000001823CEF70
	
				// Methods
				public override Length GetValue(ref TextAutoSize container); // 0x0000000181B55CB0-0x0000000181B55CC0
				public override void SetValue(ref TextAutoSize container, Length value); // 0x00000001823CEF10-0x00000001823CEF20
			}
	
			// Constructors
			public PropertyBag(); // 0x00000001823CF250-0x00000001823CF420
		}
	
		// Constructors
		public TextAutoSize(TextAutoSizeMode mode, Length minSize, Length maxSize); // 0x00000001823CFC80-0x00000001823CFC90
	
		// Methods
		public static TextAutoSize None(); // 0x00000001823CFC30-0x00000001823CFC80
		public bool Equals(TextAutoSize other); // 0x00000001823CFAA0-0x00000001823CFB10
		public override bool Equals(object obj); // 0x00000001823CFB10-0x00000001823CFBD0
		public override int GetHashCode(); // 0x00000001823CFBD0-0x00000001823CFC30
		public static bool operator ==(TextAutoSize left, TextAutoSize right); // 0x00000001823CFC90-0x00000001823CFD00
		public static bool operator !=(TextAutoSize left, TextAutoSize right); // 0x00000001823CFD00-0x00000001823CFD70
	}
}
