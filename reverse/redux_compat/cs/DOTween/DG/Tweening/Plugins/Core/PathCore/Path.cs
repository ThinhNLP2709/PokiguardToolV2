/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Serializable]
	public class Path // TypeDefIndex: 13495
	{
		// Fields
		private static CatmullRomDecoder _catmullRomDecoder; // 0x00
		private static LinearDecoder _linearDecoder; // 0x08
		private static CubicBezierDecoder _cubicBezierDecoder; // 0x10
		public float[] wpLengths; // 0x10
		[SerializeField]
		public Vector3[] wps; // 0x18
		[SerializeField]
		internal PathType type; // 0x20
		[SerializeField]
		internal int subdivisionsXSegment; // 0x24
		[SerializeField]
		internal int subdivisions; // 0x28
		[SerializeField]
		internal ControlPoint[] controlPoints; // 0x30
		[SerializeField]
		internal float length; // 0x38
		[SerializeField]
		internal bool isFinalized; // 0x3C
		[SerializeField]
		internal float[] timesTable; // 0x40
		[SerializeField]
		internal float[] lengthsTable; // 0x48
		internal int linearWPIndex; // 0x50
		internal bool addedExtraStartWp; // 0x54
		internal bool addedExtraEndWp; // 0x55
		internal PathOptions plugOptions; // 0x58
		private Path _incrementalClone; // 0xC8
		private int _incrementalIndex; // 0xD0
		private ABSPathDecoder _decoder; // 0xD8
		private bool _changed; // 0xE0
		internal Vector3[] nonLinearDrawWps; // 0xE8
		internal Vector3 targetPosition; // 0xF0
		internal Vector3? lookAtPosition; // 0xFC
		internal Color gizmoColor; // 0x10C
	
		// Properties
		internal int minInputWaypoints { get; } // 0x0000000180725940-0x0000000180725970 
	
		// Constructors
		public Path(PathType type, Vector3[] waypoints, int subdivisionsXSegment, Color? gizmoColor = default); // 0x0000000180725550-0x0000000180725920
		internal Path(); // 0x0000000180725920-0x0000000180725940
	
		// Methods
		internal void FinalizePath(bool isClosedPath, AxisConstraint lockPositionAxes, Vector3 currTargetVal); // 0x0000000180725040-0x0000000180725180
		internal Vector3 GetPoint(float perc, bool convertToConstantPerc = false /* Metadata: 0x006A7AA0 */); // 0x00000001807252B0-0x0000000180725340
		internal float ConvertToConstantPathPerc(float perc); // 0x00000001807244F0-0x0000000180724640
		internal int GetWaypointIndexFromPerc(float perc, bool isMovingForward); // 0x0000000180725340-0x0000000180725400
		internal static Vector3[] GetDrawPoints(Path p, int drawSubdivisionsXSegment); // 0x0000000180725180-0x00000001807252B0
		internal static void RefreshNonLinearDrawWps(Path p); // 0x0000000180725400-0x0000000180725550
		internal void Destroy(); // 0x0000000180724720-0x0000000180724880
		internal Path CloneIncremental(int loopIncrement); // 0x0000000180723DB0-0x00000001807244F0
		internal void AssignWaypoints(Vector3[] newWps, bool cloneWps = false /* Metadata: 0x006A7AA1 */); // 0x0000000180723CC0-0x0000000180723DB0
		internal void AssignDecoder(PathType pathType); // 0x0000000180723B10-0x0000000180723CC0
		internal void Draw(); // 0x0000000180725030-0x0000000180725040
		private static void Draw(Path p); // 0x0000000180724880-0x0000000180725030
		private static Vector3 ConvertToDrawPoint(Vector3 wp, PathOptions plugOptions); // 0x0000000180724640-0x0000000180724720
	}
}
