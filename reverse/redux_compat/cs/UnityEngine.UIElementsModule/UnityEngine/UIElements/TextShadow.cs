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
	[Serializable]
	public struct TextShadow : IEquatable<TextShadow> // TypeDefIndex: 4855
	{
		// Fields
		public Color color; // 0x00
		public Vector2 offset; // 0x10
		public float blurRadius; // 0x18
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<TextShadow> // TypeDefIndex: 4856
		{
			// Nested types
			private class OffsetProperty : Property<TextShadow, Vector2> // TypeDefIndex: 4857
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
				public OffsetProperty(); // 0x00000001823CF020-0x00000001823CF070
	
				// Methods
				public override Vector2 GetValue(ref TextShadow container); // 0x000000018239F6C0-0x000000018239F6E0
				public override void SetValue(ref TextShadow container, Vector2 value); // 0x000000018239F6E0-0x000000018239F6F0
			}
	
			private class BlurRadiusProperty : Property<TextShadow, float> // TypeDefIndex: 4858
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
				public BlurRadiusProperty(); // 0x00000001823CD7A0-0x00000001823CD7F0
	
				// Methods
				public override float GetValue(ref TextShadow container); // 0x00000001823CD780-0x00000001823CD790
				public override void SetValue(ref TextShadow container, float value); // 0x00000001823CD790-0x00000001823CD7A0
			}
	
			private class ColorProperty : Property<TextShadow, Color> // TypeDefIndex: 4859
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
				public ColorProperty(); // 0x00000001823CD800-0x00000001823CD850
	
				// Methods
				public override Color GetValue(ref TextShadow container); // 0x0000000180D96A60-0x0000000180D96A70
				public override void SetValue(ref TextShadow container, Color value); // 0x00000001823CD7F0-0x00000001823CD800
			}
	
			// Constructors
			public PropertyBag(); // 0x00000001823CF420-0x00000001823CF600
		}
	
		// Methods
		public override bool Equals(object obj); // 0x00000001823CFD70-0x00000001823CFE10
		public bool Equals(TextShadow other); // 0x00000001823CFE10-0x00000001823CFED0
		public override int GetHashCode(); // 0x00000001823CFED0-0x00000001823CFF90
		public static bool operator ==(TextShadow style1, TextShadow style2); // 0x00000001823D0140-0x00000001823D0170
		public static bool operator !=(TextShadow style1, TextShadow style2); // 0x00000001823D0170-0x00000001823D0240
		public override string ToString(); // 0x00000001823D0080-0x00000001823D0140
		internal static TextShadow LerpUnclamped(TextShadow a, TextShadow b, float t); // 0x00000001823CFF90-0x00000001823D0080
	}
}
