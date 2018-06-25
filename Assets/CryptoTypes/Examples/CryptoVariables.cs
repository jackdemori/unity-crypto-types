using CryptoTypes;
using UnityEngine;

public class CryptoVariables : MonoBehaviour
{
    public CryptoDouble a = 1.5f;
    public CryptoLong b = 2;

    public CryptoInt c = 5;
    public CryptoInt d = 10;

    // Use this for initialization
    void Start()
    {
        Debug.Log("A + B =" + (a + b));
        Debug.Log("A - B =" + (a - b));
        Debug.Log("A * B =" + (a * b));
        Debug.Log("A / B =" + (a / b));
        Debug.Log("A == B ? " + (a == b));
        Debug.Log("A != B ? " + (a != b));

        Debug.Log("A = " + a.Debug());
        Debug.Log("B = " + b.Debug());

        Debug.Log("C + D * C = " + (c + d * c));

        Debug.Log(--c);
    }
}
