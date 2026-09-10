/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class LTRect // TypeDefIndex: 331
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
	public bool hasInitiliazed { get; } // 0x0000000180342DC0-0x0000000180342DD0 
	public int id { get; } // 0x0000000180342E20-0x0000000180342E30 
	public float x { get; set; } // 0x0000000180343100-0x0000000180343150 0x0000000180343690-0x00000001803436F0
	public float y { get; set; } // 0x0000000180343150-0x00000001803431A0 0x00000001803436F0-0x0000000180343750
	public float width { get; set; } // 0x00000001803430B0-0x0000000180343100 0x0000000180343630-0x0000000180343690
	public float height { get; set; } // 0x0000000180342DD0-0x0000000180342E20 0x00000001803435C0-0x0000000180343620
	public Rect rect { get; set; } // 0x0000000180342E30-0x00000001803430B0 0x0000000180343620-0x0000000180343630

	// Constructors
	public LTRect(); // 0x0000000180342BE0-0x0000000180342C70
	public LTRect(Rect rect); // 0x0000000180342C70-0x0000000180342D00
	public LTRect(float x, float y, float width, float height); // 0x0000000180342B30-0x0000000180342BE0
	public LTRect(float x, float y, float width, float height, float alpha); // 0x0000000180342D00-0x0000000180342DC0
	public LTRect(float x, float y, float width, float height, float alpha, float rotation); // 0x0000000180342A50-0x0000000180342B30

	// Methods
	public void setId(int id, int counter); // 0x00000001803434E0-0x00000001803434F0
	public void reset(); // 0x0000000180343470-0x00000001803434B0
	public void resetForRotation(); // 0x00000001803431A0-0x0000000180343470
	public LTRect setStyle(GUIStyle style); // 0x0000000180343520-0x0000000180343540
	public LTRect setFontScaleToFit(bool fontScaleToFit); // 0x00000001803434D0-0x00000001803434E0
	public LTRect setColor(Color color); // 0x00000001803434C0-0x00000001803434D0
	public LTRect setAlpha(float alpha); // 0x00000001803434B0-0x00000001803434C0
	public LTRect setLabel(string str); // 0x00000001803434F0-0x0000000180343510
	public LTRect setUseSimpleScale(bool useSimpleScale, Rect relativeRect); // 0x00000001803435B0-0x00000001803435C0
	public LTRect setUseSimpleScale(bool useSimpleScale); // 0x0000000180343540-0x00000001803435B0
	public LTRect setSizeByHeight(bool sizeByHeight); // 0x0000000180343510-0x0000000180343520
	public override string ToString(); // 0x0000000180342860-0x0000000180342A50
}

