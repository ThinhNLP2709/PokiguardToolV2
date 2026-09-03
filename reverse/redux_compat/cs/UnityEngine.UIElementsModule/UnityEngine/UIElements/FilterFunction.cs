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
using UnityEngine.UIElements.Layout;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct FilterFunction : IEquatable<FilterFunction> // TypeDefIndex: 4381
	{
		// Fields
		[SerializeField]
		private FilterFunctionType m_Type; // 0x00
		[SerializeField]
		private FixedBuffer4<FilterParameter> m_Parameters; // 0x04
		[SerializeField]
		private int m_ParameterCount; // 0x64
		[SerializeField]
		private FilterFunctionDefinition m_CustomDefinition; // 0x68
	
		// Properties
		public FilterFunctionType type { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		internal FixedBuffer4<FilterParameter> parameters { get; } // 0x00000001825252D0-0x0000000182525310 
		public int parameterCount { get; } // 0x00000001802F2020-0x00000001802F2030 
		public FilterFunctionDefinition customDefinition { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
	
		// Constructors
		internal FilterFunction(FilterFunctionType type, FixedBuffer4<FilterParameter> parameters, int paramCount); // 0x0000000182525110-0x00000001825252D0
		internal FilterFunction(FilterFunctionDefinition customDefinition, FixedBuffer4<FilterParameter> parameters, int paramCount); // 0x0000000182524AB0-0x00000001825250C0
		internal FilterFunction(FilterFunctionType type, FixedBuffer4<FilterParameter> parameters, int paramCount, FilterFunctionDefinition customDefinition); // 0x00000001825250C0-0x0000000182525110
	
		// Methods
		public void AddParameter(FilterParameter p); // 0x00000001825242F0-0x00000001825243D0
		public void SetParameter(int index, FilterParameter p); // 0x00000001825247B0-0x0000000182524870
		public FilterParameter GetParameter(int index); // 0x00000001825246F0-0x00000001825247B0
		public void ClearParameters(); // 0x00000001825243D0-0x00000001825243E0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal FilterFunctionDefinition GetDefinition(); // 0x00000001825245C0-0x00000001825245E0
		public static bool operator ==(FilterFunction lhs, FilterFunction rhs); // 0x0000000182525310-0x0000000182525480
		public static bool operator !=(FilterFunction lhs, FilterFunction rhs); // 0x0000000182525480-0x0000000182525520
		public bool Equals(FilterFunction other); // 0x0000000182524520-0x00000001825245C0
		public override bool Equals(object obj); // 0x00000001825243E0-0x0000000182524520
		public override int GetHashCode(); // 0x00000001825245E0-0x00000001825246F0
		public override string ToString(); // 0x0000000182524870-0x0000000182524AB0
	}
}
