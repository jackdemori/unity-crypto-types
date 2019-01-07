using UnityEngine;
using UnityEditor;

namespace CryptoTypes
{
    [CustomPropertyDrawer(typeof(CryptoInt))]
    public class CryptoIntDrawer : PropertyDrawer
    {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
        {
            // Create a new variable to be used in the inspector, every time it gets changed,
            // a new random offset will be generated and then replaced in our target variable.
            CryptoInt cryptoInt = property.FindPropertyRelative("value").intValue - property.FindPropertyRelative("offset").intValue;

            EditorGUI.BeginChangeCheck();
            cryptoInt = EditorGUI.IntField(position, label, cryptoInt);

            if (EditorGUI.EndChangeCheck())
            {
                // Since this drawer is inside the Editor's folder it will not be included in the final release,
                // so we can directly change the values stored by this type. 
                // Remember that we are just changing theses values using other encrypted variable.
                property.FindPropertyRelative("value").intValue = cryptoInt + cryptoInt.GetOffset();
                property.FindPropertyRelative("offset").intValue = cryptoInt.GetOffset();
            }
        }
    }
}
