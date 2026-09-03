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
	internal struct InheritedData : IStyleDataGroup<InheritedData>, IEquatable<InheritedData> // TypeDefIndex: 4623
	{
		// Fields
		public Color color; // 0x00
		public UnmanagedMaterialDefinition unityMaterial; // 0x10
		public Color unityTextOutlineColor; // 0x20
		public Length fontSize; // 0x30
		public Length letterSpacing; // 0x38
		public EntityId unityFont; // 0x40
		public EntityId unityFontDefinition; // 0x48
		public Length unityParagraphSpacing; // 0x50
		public Length wordSpacing; // 0x58
		public TextShadow textShadow; // 0x60
		public EditorTextRenderingMode unityEditorTextRenderingMode; // 0x7C
		public FontStyle unityFontStyleAndWeight; // 0x80
		public TextAnchor unityTextAlign; // 0x84
		public TextAutoSize unityTextAutoSize; // 0x88
		public TextGeneratorType unityTextGenerator; // 0x9C
		public float unityTextOutlineWidth; // 0xA0
		public Visibility visibility; // 0xA4
		public WhiteSpace whiteSpace; // 0xA8
	
		// Methods
		public InheritedData GetDefault(); // 0x0000000182542030-0x0000000182542050
		public InheritedData Copy(); // 0x0000000182541CF0-0x0000000182541E00
		public void CopyFrom(ref InheritedData other); // 0x0000000182541BF0-0x0000000182541CF0
		public void Dispose(); // 0x0000000182541E00-0x0000000182541E10
		public static bool operator ==(InheritedData lhs, InheritedData rhs); // 0x00000001825422B0-0x0000000182543440
		public bool Equals(InheritedData other); // 0x0000000182541E10-0x0000000182541F20
		public override bool Equals(object obj); // 0x0000000182541F20-0x0000000182542030
		public override int GetHashCode(); // 0x0000000182542050-0x00000001825422B0
	}
}
