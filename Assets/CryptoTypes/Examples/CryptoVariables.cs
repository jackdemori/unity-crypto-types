using CryptoTypes;
using UnityEngine;

public class CryptoVariables : MonoBehaviour
{
    public CryptoInt a = 1;
    public CryptoLong b = 2;

    public CryptoFloat height = 1.75f;
    private CryptoDouble pi = 3.141592;

    // Use this for initialization
    void Start()
    {
        double random = height * pi + (a * b);
        Debug.Log(random);
    }
}
