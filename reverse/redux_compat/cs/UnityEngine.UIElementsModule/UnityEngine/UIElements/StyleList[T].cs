/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
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
	public struct StyleList<T> : IStyleValue<List<T>>, IEquatable<StyleList<T>> // TypeDefIndex: 4671
	{
		// Fields
		[SerializeField]
		private StyleKeyword m_Keyword;
		[SerializeField]
		private List<T> m_Value;
	
		// Properties
		public List<T> value { get; set; }
		public StyleKeyword keyword { get; set; }
	
		// Constructors
		public StyleList(List<T> v);
		public StyleList(StyleKeyword keyword);
		internal StyleList(List<T> v, StyleKeyword keyword);
	
		// Methods
		public static bool operator ==(StyleList<T> lhs, StyleList<T> rhs);
		public static implicit operator StyleList<T>(StyleKeyword keyword);
		public static implicit operator StyleList<T>(List<T> v);
		public bool Equals(StyleList<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
		public override string ToString();
	}
}
