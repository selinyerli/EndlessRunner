using UnityEngine;
using UnityEngine.Rendering;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -7f;
    public static float rightSide = 4f;
    public float internalLeft;
    public float internalRight;

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
