using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sets the "edges" of the playfield.
 * Mostly for player movement, but may also have bearing on the shots
 */
public class Boundaries : ScriptableObject
{
    public static float LeftWall { get; set; } = -9;
    public static float TopWall { get; set; } = 7;
    public static float RightWall { get; set; } = 9;
    public static float BottomWall { get; set; } = -7;
}
