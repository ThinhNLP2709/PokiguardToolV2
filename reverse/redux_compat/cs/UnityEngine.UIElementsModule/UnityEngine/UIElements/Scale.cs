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
	public struct Scale : IEquatable<Scale> // TypeDefIndex: 4653
	{
		// Fields
		[SerializeField]
		private Vector3 m_Scale; // 0x00
		[SerializeField]
		private bool m_IsNone; // 0x0C
	
		// Properties
		public Vector3 value { get; set; } // 0x0000000181D8BE70-0x0000000181D8BE90 0x0000000181D8BED0-0x0000000181D8BEE0
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<Scale> // TypeDefIndex: 4654
		{
			// Nested types
			private class ValueProperty : Property<Scale, Vector3> // TypeDefIndex: 4655
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
				public ValueProperty(); // 0x0000000182571250-0x00000001825712A0
	
				// Methods
				public override Vector3 GetValue(ref Scale container); // 0x0000000180F61100-0x0000000180F61120
				public override void SetValue(ref Scale container, Vector3 value); // 0x00000001822D9680-0x00000001822D96A0
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255E770-0x000000018255E860
		}
	
		// Constructors
		public Scale(Vector3 scale); // 0x0000000181EEF9F0-0x0000000181EEFA10
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal static Scale Initial(); // 0x000000018255F460-0x000000018255F490
		public static Scale None(); // 0x000000018255F490-0x000000018255F4E0
		public static bool operator ==(Scale lhs, Scale rhs); // 0x000000018255F4F0-0x000000018255F550
		public static bool operator !=(Scale lhs, Scale rhs); // 0x000000018255F550-0x000000018255F5B0
		public bool Equals(Scale other); // 0x000000018255F2D0-0x000000018255F330
		public override bool Equals(object obj); // 0x000000018255F330-0x000000018255F400
		public override int GetHashCode(); // 0x000000018255F400-0x000000018255F460
		public override string ToString(); // 0x000000018255F4E0-0x000000018255F4F0
	}
}
