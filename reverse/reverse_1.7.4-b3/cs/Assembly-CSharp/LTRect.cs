/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class LTRect // TypeDefIndex: 328
{
	// Fields
	public Rect _rect; // 0x10
	public float alpha; // 0x20
	public float rotation; // 0x24
	public Vector2 pivot; // 0x28
	public Vector2 margin; // 0x30
	public Rect relativeRect; // 0x38
	public bool rotateEnabled; // 0x48
	[HideInInspector]
	public bool rotateFinished; // 0x49
	public bool alphaEnabled; // 0x4A
	public string labelStr; // 0x50
	public LTGUI.Element_Type type; // 0x58
	public GUIStyle style; // 0x60
	public bool useColor; // 0x68
	public Color color; // 0x6C
	public bool fontScaleToFit; // 0x7C
	public bool useSimpleScale; // 0x7D
	public bool sizeByHeight; // 0x7E
	public Texture texture; // 0x80
	private int _id; // 0x88
	[HideInInspector]
	public int counter; // 0x8C
	public static bool colorTouched; // 0x00

	// Properties
	public bool hasInitiliazed { get; } // 0x00000001802F9EE0-0x00000001802F9EF0 
	public int id { get; } // 0x00000001802F9EF0-0x00000001802F9F00 
	public Rect rect { get; set; } // 0x00000001802FA260-0x00000001802FA8D0 0x00000001802FA8D0-0x00000001802FA8E0

	// Constructors
	public LTRect(); // 0x00000001802F9D00-0x00000001802F9D70
	public LTRect(float x, float y, float width, float height); // 0x00000001802F9D70-0x00000001802F9DE0
	public LTRect(float x, float y, float width, float height, float alpha); // 0x00000001802F9DE0-0x00000001802F9E50
	public LTRect(float x, float y, float width, float height, float alpha, float rotation); // 0x00000001802F9E50-0x00000001802F9EE0

	// Methods
	public void reset(); // 0x00000001802F9F00-0x00000001802F9F40
	public void resetForRotation(); // 0x00000001802F9F40-0x00000001802FA260
	public override string ToString(); // 0x00000001802FA8E0-0x00000001802FABC0
}

