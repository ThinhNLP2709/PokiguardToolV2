/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal static class MeshUtils // TypeDefIndex: 13966
	{
		// Fields
		public const int Undef = -1; // Metadata: 0x006A914B
	
		// Nested types
		public abstract class Pooled<T> // TypeDefIndex: 13967
			where T : Pooled<T>, new()
		{
			// Fields
			internal static Stack<T> _stack;
	
			// Constructors
			protected Pooled();
	
			// Methods
			public abstract void Reset();
			public virtual void OnFree();
			public static T Create();
			public void Free();
		}
	
		public class Vertex : Pooled<Vertex> // TypeDefIndex: 13968
		{
			// Fields
			internal Vertex _prev; // 0x10
			internal Vertex _next; // 0x18
			internal Edge _anEdge; // 0x20
			internal Vec3 _coords; // 0x28
			internal float _s; // 0x34
			internal float _t; // 0x38
			internal PQHandle _pqHandle; // 0x3C
			internal int _n; // 0x40
			internal object _data; // 0x48
	
			// Constructors
			public Vertex(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			[RuntimeInitializeOnLoadMethod]
			private static void InitializeStack(); // 0x0000000181C60B10-0x0000000181C60BA0
			public override void Reset(); // 0x0000000181C60BA0-0x0000000181C60C50
		}
	
		public class Face : Pooled<Face> // TypeDefIndex: 13969
		{
			// Fields
			internal Face _prev; // 0x10
			internal Face _next; // 0x18
			internal Edge _anEdge; // 0x20
			internal Face _trail; // 0x28
			internal int _n; // 0x30
			internal bool _marked; // 0x34
			internal bool _inside; // 0x35
	
			// Properties
			internal int VertsCount { get; } // 0x0000000181C43760-0x0000000181C43790 
	
			// Constructors
			public Face(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			[RuntimeInitializeOnLoadMethod]
			private static void InitializeStack(); // 0x0000000181C43670-0x0000000181C43700
			public override void Reset(); // 0x0000000181C43700-0x0000000181C43760
		}
	
		public struct EdgePair // TypeDefIndex: 13970
		{
			// Fields
			internal Edge _e; // 0x00
			internal Edge _eSym; // 0x08
	
			// Methods
			public static EdgePair Create(); // 0x0000000181C431A0-0x0000000181C43250
			public void Reset(); // 0x0000000181C43250-0x0000000181C43290
		}
	
		public class Edge : Pooled<Edge> // TypeDefIndex: 13971
		{
			// Fields
			internal EdgePair _pair; // 0x10
			internal Edge _next; // 0x20
			internal Edge _Sym; // 0x28
			internal Edge _Onext; // 0x30
			internal Edge _Lnext; // 0x38
			internal Vertex _Org; // 0x40
			internal Face _Lface; // 0x48
			internal Tess.ActiveRegion _activeRegion; // 0x50
			internal int _winding; // 0x58
	
			// Properties
			internal Face _Rface { get; set; } // 0x0000000181C434A0-0x0000000181C434C0 0x0000000181C435E0-0x0000000181C43610
			internal Vertex _Dst { get; set; } // 0x0000000181C43460-0x0000000181C43480 0x0000000181C43550-0x0000000181C43580
			internal Edge _Oprev { get; set; } // 0x000000018177A020-0x000000018177A040 0x0000000181C435B0-0x0000000181C435E0
			internal Edge _Lprev { get; set; } // 0x0000000181C43480-0x0000000181C434A0 0x0000000181C43580-0x0000000181C435B0
			internal Edge _Dprev { get; set; } // 0x0000000181C43440-0x0000000181C43460 0x0000000181C43520-0x0000000181C43550
			internal Edge _Rprev { get; set; } // 0x0000000181779FA0-0x0000000181779FC0 0x0000000181C43640-0x0000000181C43670
			internal Edge _Dnext { get; set; } // 0x0000000181C43410-0x0000000181C43440 0x0000000181C434F0-0x0000000181C43520
			internal Edge _Rnext { get; set; } // 0x0000000181C434C0-0x0000000181C434F0 0x0000000181C43610-0x0000000181C43640
	
			// Constructors
			public Edge(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			[RuntimeInitializeOnLoadMethod]
			private static void InitializeStack(); // 0x0000000181C432D0-0x0000000181C43360
			internal static void EnsureFirst(ref Edge e); // 0x0000000181C43290-0x0000000181C432D0
			public override void Reset(); // 0x0000000181C43360-0x0000000181C43410
		}
	
		// Methods
		public static Edge MakeEdge(Edge eNext); // 0x0000000181C44980-0x0000000181C44C00
		public static void Splice(Edge a, Edge b); // 0x0000000181C44E00-0x0000000181C44EA0
		public static void MakeVertex(Edge eOrig, Vertex vNext); // 0x0000000181C44D10-0x0000000181C44E00
		public static void MakeFace(Edge eOrig, Face fNext); // 0x0000000181C44C00-0x0000000181C44D10
		public static void KillEdge(Edge eDel); // 0x0000000181C44720-0x0000000181C44800
		public static void KillVertex(Vertex vDel, Vertex newOrg); // 0x0000000181C448C0-0x0000000181C44980
		public static void KillFace(Face fDel, Face newLFace); // 0x0000000181C44800-0x0000000181C448C0
		public static float FaceArea(Face f); // 0x0000000181C446B0-0x0000000181C44720
	}
}
