using BWolf.UserInteraction.Utility;
using UnityEditor;
using UnityEngine;

namespace BWolf.Meshes.Generation.Utility.Editor
{
    [CustomPropertyDrawer(typeof(ClampZeroOne))]
    public class ClampZeroOnePropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            => EditorGUI.GetPropertyHeight(property, label, true);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ClampPropertyValue(property);     
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndProperty();
        }

        private void ClampPropertyValue(SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:
                    property.floatValue = Mathf.Clamp01(property.floatValue);
                    break;
                
                case SerializedPropertyType.Vector2:
                    property.vector2Value = property.vector2Value.Clamp01();
                    break;
                    
                case SerializedPropertyType.Vector3:
                    property.vector3Value = property.vector3Value.Clamp01();
                    break;    
            }
        }
    }
}
