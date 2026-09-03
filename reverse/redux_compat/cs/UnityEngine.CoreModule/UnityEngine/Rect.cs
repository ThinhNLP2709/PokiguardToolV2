/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeClass("Rectf", "template<typename T> class RectT; typedef RectT<float> Rectf;")]
	[NativeHeader("Runtime/Math/Rect.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Rect : IEquatable<UnityEngine.Rect>, IFormattable // TypeDefIndex: 7528
	{
		// Fields
		[NativeName("x")]
		[SerializeField]
		private float m_XMin; // 0x00
		[NativeName("y")]
		[SerializeField]
		private float m_YMin; // 0x04
		[NativeName("width")]
		[SerializeField]
		private float m_Width; // 0x08
		[NativeName("height")]
		[SerializeField]
		private float m_Height; // 0x0C
		private static readonly Rect kZero; // 0x00
	
		// Properties
		public static Rect zero { get; } // 0x00000001821935A0-0x0000000182193600 
		public float x { [IsReadOnly] get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public float y { [IsReadOnly] get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public Vector2 position { [IsReadOnly] get; set; } // 0x0000000181E6F9A0-0x0000000181E6F9C0 0x0000000182193770-0x0000000182193790
		public Vector2 center { [IsReadOnly] get; set; } // 0x0000000182193530-0x0000000182193560 0x0000000182193640-0x0000000182193680
		public Vector2 min { [IsReadOnly] get; set; } // 0x0000000181E6F9A0-0x0000000181E6F9C0 0x00000001821936F0-0x0000000182193770
		public Vector2 max { [IsReadOnly] get; set; } // 0x0000000182193560-0x0000000182193580 0x0000000182193680-0x00000001821936F0
		public float width { [IsReadOnly] get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
		public float height { [IsReadOnly] get; set; } // 0x00000001802DB040-0x00000001802DB050 0x0000000181DD0800-0x0000000181DD0810
		public Vector2 size { [IsReadOnly] get; set; } // 0x0000000181DD08D0-0x0000000181DD08F0 0x0000000182193790-0x00000001821937B0
		public float xMin { [IsReadOnly] get; set; } // 0x000000018035C780-0x000000018035C790 0x00000001821937C0-0x00000001821937E0
		public float yMin { [IsReadOnly] get; set; } // 0x000000018035C790-0x000000018035C7A0 0x00000001821937F0-0x0000000182193810
		public float xMax { [IsReadOnly] get; set; } // 0x0000000182193580-0x0000000182193590 0x00000001821937B0-0x00000001821937C0
		public float yMax { [IsReadOnly] get; set; } // 0x0000000182193590-0x00000001821935A0 0x00000001821937E0-0x00000001821937F0
	
		// Constructors
		public Rect(float x, float y, float width, float height); // 0x0000000182082140-0x0000000182082160
		public Rect(Vector2 position, Vector2 size); // 0x00000001821934F0-0x0000000182193530
		public Rect(Rect source); // 0x00000001820825F0-0x0000000182082610
		static Rect(); // 0x00000001821934B0-0x00000001821934F0
	
		// Methods
		public static Rect MinMaxRect(float xmin, float ymin, float xmax, float ymax); // 0x0000000182192FA0-0x0000000182192FD0
		[IsReadOnly]
		public bool Contains(Vector2 point); // 0x0000000181229300-0x0000000181229340
		[IsReadOnly]
		public bool Contains(Vector3 point); // 0x0000000182192D60-0x0000000182192DA0
		[IsReadOnly]
		public bool Overlaps(Rect other); // 0x0000000182192FD0-0x0000000182193020
		[IsReadOnly]
		public bool Overlaps([IsReadOnly] in Rect other); // 0x0000000182192FD0-0x0000000182193020
		private static bool UnorderedOverlaps([IsReadOnly] in Rect lhs, [IsReadOnly] in Rect rhs); // 0x0000000182193430-0x00000001821934B0
		[IsReadOnly]
		public bool Overlaps(Rect other, bool allowInverse); // 0x0000000182193020-0x0000000182193170
		public static bool operator !=(Rect lhs, Rect rhs); // 0x0000000182193600-0x0000000182193640
		public static bool operator ==(Rect lhs, Rect rhs); // 0x000000018192E0B0-0x000000018192E0F0
		[IsReadOnly]
		public override int GetHashCode(); // 0x0000000182192F30-0x0000000182192FA0
		[IsReadOnly]
		public override bool Equals(object other); // 0x0000000182192E20-0x0000000182192F30
		[IsReadOnly]
		public bool Equals(Rect other); // 0x0000000182192DA0-0x0000000182192E20
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Rect other); // 0x0000000182192DA0-0x0000000182192E20
		[IsReadOnly]
		public override string ToString(); // 0x0000000182193170-0x00000001821931C0
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821931C0-0x0000000182193430
	}
}
