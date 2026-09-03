/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct Cursor : IEquatable<Cursor> // TypeDefIndex: 3930
	{
		// Fields
		[SerializeField]
		private EntityId m_Texture; // 0x00
		private int m_DefaultCursorId; // 0x08
		private int __dummy; // 0x0C
		[SerializeField]
		private Vector2 m_Hotspot; // 0x10
	
		// Properties
		public Texture2D texture { get; set; } // 0x000000018239B720-0x000000018239B780 0x000000018239B800-0x000000018239B890
		public Vector2 hotspot { get; set; } // 0x0000000180719040-0x0000000180719060 0x0000000180719060-0x0000000180719070
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal int defaultCursorId { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		internal EntityId textureId { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<Cursor> // TypeDefIndex: 3931
		{
			// Nested types
			private class TextureProperty : Property<Cursor, Texture2D> // TypeDefIndex: 3932
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
				public TextureProperty(); // 0x00000001823AF6F0-0x00000001823AF740
	
				// Methods
				public override Texture2D GetValue(ref Cursor container); // 0x00000001823AF600-0x00000001823AF660
				public override void SetValue(ref Cursor container, Texture2D value); // 0x00000001823AF660-0x00000001823AF6F0
			}
	
			private class HotspotProperty : Property<Cursor, Vector2> // TypeDefIndex: 3933
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
				public HotspotProperty(); // 0x000000018239F6F0-0x000000018239F740
	
				// Methods
				public override Vector2 GetValue(ref Cursor container); // 0x000000018239F6C0-0x000000018239F6E0
				public override void SetValue(ref Cursor container, Vector2 value); // 0x000000018239F6E0-0x000000018239F6F0
			}
	
			private class DefaultCursorIdProperty : Property<Cursor, int> // TypeDefIndex: 3934
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
				public DefaultCursorIdProperty(); // 0x000000018239B890-0x000000018239B8E0
	
				// Methods
				public override int GetValue(ref Cursor container); // 0x000000018132C0F0-0x000000018132C100
				public override void SetValue(ref Cursor container, int value); // 0x000000018132C190-0x000000018132C1A0
			}
	
			// Constructors
			public PropertyBag(); // 0x00000001823A13D0-0x00000001823A15B0
		}
	
		// Methods
		public override bool Equals(object obj); // 0x000000018239B2E0-0x000000018239B380
		public bool Equals(Cursor other); // 0x000000018239B380-0x000000018239B4D0
		public override int GetHashCode(); // 0x000000018239B4D0-0x000000018239B670
		public static bool operator ==(Cursor style1, Cursor style2); // 0x000000018239B780-0x000000018239B7B0
		public static bool operator !=(Cursor style1, Cursor style2); // 0x000000018239B7B0-0x000000018239B800
		public override string ToString(); // 0x000000018239B670-0x000000018239B720
	}
}
