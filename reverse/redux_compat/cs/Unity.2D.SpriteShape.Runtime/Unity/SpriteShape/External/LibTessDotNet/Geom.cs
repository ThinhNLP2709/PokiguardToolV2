/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal static class Geom // TypeDefIndex: 13963
	{
		// Methods
		public static bool IsWindingInside(WindingRule rule, int n); // 0x0000000181C44300-0x0000000181C443B0
		public static bool VertCCW(MeshUtils.Vertex u, MeshUtils.Vertex v, MeshUtils.Vertex w); // 0x0000000181C44520-0x0000000181C44580
		public static bool VertEq(MeshUtils.Vertex lhs, MeshUtils.Vertex rhs); // 0x0000000181C44580-0x0000000181C445C0
		public static bool VertLeq(MeshUtils.Vertex lhs, MeshUtils.Vertex rhs); // 0x0000000181C44660-0x0000000181C446B0
		public static float EdgeEval(MeshUtils.Vertex u, MeshUtils.Vertex v, MeshUtils.Vertex w); // 0x0000000181C437D0-0x0000000181C43880
		public static float EdgeSign(MeshUtils.Vertex u, MeshUtils.Vertex v, MeshUtils.Vertex w); // 0x0000000181C44230-0x0000000181C442A0
		public static bool TransLeq(MeshUtils.Vertex lhs, MeshUtils.Vertex rhs); // 0x0000000181C44460-0x0000000181C444B0
		public static float TransEval(MeshUtils.Vertex u, MeshUtils.Vertex v, MeshUtils.Vertex w); // 0x0000000181C443B0-0x0000000181C44460
		public static float TransSign(MeshUtils.Vertex u, MeshUtils.Vertex v, MeshUtils.Vertex w); // 0x0000000181C444B0-0x0000000181C44520
		public static bool EdgeGoesLeft(MeshUtils.Edge e); // 0x0000000181C43880-0x0000000181C438F0
		public static bool EdgeGoesRight(MeshUtils.Edge e); // 0x0000000181C438F0-0x0000000181C43960
		public static float VertL1dist(MeshUtils.Vertex u, MeshUtils.Vertex v); // 0x0000000181C445C0-0x0000000181C44660
		public static void AddWinding(MeshUtils.Edge eDst, MeshUtils.Edge eSrc); // 0x0000000181C43790-0x0000000181C437D0
		public static float Interpolate(float a, float x, float b, float y); // 0x0000000181C442A0-0x0000000181C44300
		private static void Swap(ref MeshUtils.Vertex a, ref MeshUtils.Vertex b); // 0x000000018080C790-0x000000018080C7D0
		public static void EdgeIntersect(MeshUtils.Vertex o1, MeshUtils.Vertex d1, MeshUtils.Vertex o2, MeshUtils.Vertex d2, MeshUtils.Vertex v); // 0x0000000181C43960-0x0000000181C44230
	}
}
