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
	public struct StyleTransformOrigin : IStyleValue<TransformOrigin>, IEquatable<StyleTransformOrigin> // TypeDefIndex: 4677
	{
		// Fields
		[SerializeField]
		private TransformOrigin m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x14
	
		// Properties
		public TransformOrigin value { get; set; } // 0x000000018256D9E0-0x000000018256DAC0 0x0000000182562850-0x0000000182562870
		public StyleKeyword keyword { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
	
		// Constructors
		public StyleTransformOrigin(TransformOrigin v); // 0x0000000182562850-0x0000000182562870
		public StyleTransformOrigin(StyleKeyword keyword); // 0x0000000182562840-0x0000000182562850
		internal StyleTransformOrigin(TransformOrigin v, StyleKeyword keyword); // 0x0000000182562820-0x0000000182562840
	
		// Methods
		public static bool operator ==(StyleTransformOrigin lhs, StyleTransformOrigin rhs); // 0x000000018256DAC0-0x000000018256DB40
		public static implicit operator StyleTransformOrigin(StyleKeyword keyword); // 0x0000000182562930-0x0000000182562950
		public static implicit operator StyleTransformOrigin(TransformOrigin v); // 0x0000000182562910-0x0000000182562930
		public bool Equals(StyleTransformOrigin other); // 0x000000018256D7B0-0x000000018256D860
		public override bool Equals(object obj); // 0x000000018256D860-0x000000018256D900
		public override int GetHashCode(); // 0x000000018256D900-0x000000018256D970
		public override string ToString(); // 0x000000018256D970-0x000000018256D9E0
	}
}
