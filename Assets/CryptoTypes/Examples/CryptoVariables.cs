using CryptoTypes;
using UnityEngine;

public class CryptoVariables : MonoBehaviour
{
    public CryptoInt vitality = 100;

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            vitality--;
    }

    private void OnGUI ()
    {
        GUI.Label(new Rect(30, 30, 100, 24), vitality.ToString());
    }

}
