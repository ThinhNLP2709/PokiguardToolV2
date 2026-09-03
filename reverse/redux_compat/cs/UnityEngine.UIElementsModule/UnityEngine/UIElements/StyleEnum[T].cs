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
	public struct StyleEnum<T> : IStyleValue<T>, IEquatable<StyleEnum<T>> // TypeDefIndex: 4665
		where T : struct, IConvertible
	{
		// Fields
		[SerializeField]
		private T m_Value;
		[SerializeField]
		private StyleKeyword m_Keyword;
	
		// Properties
		public T value { get; set; }
		public StyleKeyword keyword { get; set; }
	
		// Constructors
		public StyleEnum(T v);
		public StyleEnum(StyleKeyword keyword);
		internal StyleEnum(T v, StyleKeyword keyword);
	
		// Methods
		public static bool operator ==(StyleEnum<T> lhs, StyleEnum<T> rhs);
		public static bool operator !=(StyleEnum<T> lhs, StyleEnum<T> rhs);
		public static implicit operator StyleEnum<T>(StyleKeyword keyword);
		public static implicit operator StyleEnum<T>(T v);
		public bool Equals(StyleEnum<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
		public override string ToString();
	}
}
