using UnityEngine;
using UnityEditor;
using CryptoTypes;

[CustomPropertyDrawer(typeof(CryptoFloat))]
public class CryptoFloatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Create a new variable to be used in the inspector, every time it gets changed,
        // a new random offset will be generated and then replaced in our target variable.
        CryptoFloat cryptoFloat = property.FindPropertyRelative("value").floatValue - property.FindPropertyRelative("offset").intValue;

        EditorGUI.BeginChangeCheck();
        cryptoFloat = EditorGUI.FloatField(position, label, cryptoFloat);

        if (EditorGUI.EndChangeCheck())
        {
            // Since this drawer is inside the Editor's folder it will not be included in the final release,
            // so we can directly change the values stored by this type. 
            // Remember that we are just changing theses values using other encrypted variable.
            property.FindPropertyRelative("value").floatValue = cryptoFloat + cryptoFloat.GetOffset();
            property.FindPropertyRelative("offset").intValue = cryptoFloat.GetOffset();
        }
    }
}
