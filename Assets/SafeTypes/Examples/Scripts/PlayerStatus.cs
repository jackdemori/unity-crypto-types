using UnityEngine;
using SafeTypes;

public class PlayerStatus : MonoBehaviour
{
    public sfloat a = 1.5f;
    public sfloat b = 2.5f;

    public sint c = 5;
    public sint d = 10;

    // Use this for initialization
    void Start()
    {
        //Operators
        Debug.Log("A + B =" + (a + b));
        Debug.Log("A - B =" + (a - b));
        Debug.Log("A * B =" + (a * b));
        Debug.Log("A / B =" + (a / b));
        Debug.Log("A == B ? " + (a == b));
        Debug.Log("A != B ? " + (a != b));

        Debug.Log(a.Debug());
        Debug.Log(b.Debug());

        Debug.Log("C + D * C = " + (c + d * c));
        
        Debug.Log(--c);
    }
}
