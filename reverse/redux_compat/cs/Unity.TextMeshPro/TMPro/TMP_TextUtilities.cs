/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class TMP_TextUtilities // TypeDefIndex: 11920
	{
		// Fields
		private static readonly Vector3[] m_rectWorldCorners; // 0x00
		private const string k_lookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-"; // Metadata: 0x006A2403
		private const string k_lookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"; // Metadata: 0x006A2485
	
		// Nested types
		private struct LineSegment // TypeDefIndex: 11921
		{
			// Fields
			public Vector3 Point1; // 0x00
			public Vector3 Point2; // 0x0C
	
			// Constructors
			public LineSegment(Vector3 p1, Vector3 p2); // 0x000000018071D330-0x000000018071D350
		}
	
		// Constructors
		static TMP_TextUtilities(); // 0x00000001820F1100-0x00000001820F1170
	
		// Methods
		public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera); // 0x00000001820EFC50-0x00000001820EFE30
		public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera, out CaretPosition cursor); // 0x00000001820EFE30-0x00000001820F00A0
		public static int FindNearestLine(TMP_Text text, Vector3 position, Camera camera); // 0x00000001820EE2E0-0x00000001820EE5C0
		public static int FindNearestCharacterOnLine(TMP_Text text, Vector3 position, int line, Camera camera, bool visibleOnly); // 0x00000001820ED940-0x00000001820EDE50
		public static bool IsIntersectingRectTransform(RectTransform rectTransform, Vector3 position, Camera camera); // 0x00000001820F0640-0x00000001820F0810
		public static int FindIntersectingCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly); // 0x00000001820EC630-0x00000001820EC930
		public static int FindNearestCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly); // 0x00000001820EDE50-0x00000001820EE2E0
		public static int FindIntersectingWord(TMP_Text text, Vector3 position, Camera camera); // 0x00000001820ED180-0x00000001820ED940
		public static int FindNearestWord(TMP_Text text, Vector3 position, Camera camera); // 0x00000001820EF0C0-0x00000001820EFC50
		public static int FindIntersectingLine(TMP_Text text, Vector3 position, Camera camera); // 0x00000001820EC930-0x00000001820ECB30
		public static int FindIntersectingLink(TMP_Text text, Vector3 position, Camera camera); // 0x00000001820ECB30-0x00000001820ED180
		public static int FindNearestLink(TMP_Text text, Vector3 position, Camera camera); // 0x00000001820EE5C0-0x00000001820EF0C0
		private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d); // 0x00000001820F0810-0x00000001820F0A70
		public static bool ScreenPointToWorldPointInRectangle(Transform transform, Vector2 screenPoint, Camera cam, out Vector3 worldPoint); // 0x00000001820F0A70-0x00000001820F0DE0
		private static bool IntersectLinePlane(LineSegment line, Vector3 point, Vector3 normal, out Vector3 intersectingPoint); // 0x00000001820F04B0-0x00000001820F0640
		public static float DistanceToLine(Vector3 a, Vector3 b, Vector3 point); // 0x00000001820EC3C0-0x00000001820EC630
		public static char ToLowerFast(char c); // 0x00000001820F0FE0-0x00000001820F1040
		public static char ToUpperFast(char c); // 0x00000001820F10A0-0x00000001820F1100
		internal static uint ToUpperASCIIFast(uint c); // 0x00000001820F1040-0x00000001820F10A0
		public static int GetHashCode(string s); // 0x00000001820F0190-0x00000001820F02A0
		public static int GetSimpleHashCode(string s); // 0x00000001820D0750-0x00000001820D07B0
		public static uint GetSimpleHashCodeLowercase(string s); // 0x00000001820F02A0-0x00000001820F0390
		public static uint GetHashCodeCaseInSensitive(string s); // 0x00000001820F00A0-0x00000001820F0190
		public static int HexToInt(char hex); // 0x00000001820F0390-0x00000001820F04B0
		public static int StringHexToInt(string s); // 0x00000001820F0DE0-0x00000001820F0FE0
	}
}
