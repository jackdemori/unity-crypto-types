using CryptoTypes;
using UnityEngine;

public class CryptoVariables : MonoBehaviour
{
    public CryptoInt a = 2;
    public CryptoLong b = 2;

    public CryptoFloat height = 1.75f;
    public CryptoDouble pi = 3.1415926;

    //Use this for initialization
    void Start()
    {
        var random = height * pi + (a * b);
        Debug.Log(random); 
    }
}
