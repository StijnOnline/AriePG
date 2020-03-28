using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace AriePG {

    [CustomEditor(typeof(Bindings))]
    public class BindingsEditor : Editor {

        private SerializedProperty m_bindings;
        private ReorderableList m_reorderableList;
        private void OnEnable() {
            m_bindings = serializedObject.FindProperty("bindings");
            m_reorderableList = new ReorderableList(serializedObject, m_bindings, true, true, true, true);
            m_reorderableList.drawElementCallback = DrawElementCallback;
            m_reorderableList.elementHeightCallback = ElementHeightCallback;
            m_reorderableList.drawHeaderCallback = DrawHeaderCallback;
        }

        private void DrawHeaderCallback(Rect rect) {
            EditorGUI.LabelField(rect, "Bindings");
        }

        private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused) {
            SerializedProperty element = m_reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            Object action = ((Action)element.FindPropertyRelative("m_Action").objectReferenceValue);
            string elementTitle = (action == null ? "New Action" : action.name);

            EditorGUI.PropertyField(position:
                new Rect(rect.x += 10, rect.y, Screen.width * .8f, height: EditorGUIUtility.singleLineHeight), property:
                element, label: new GUIContent(elementTitle), includeChildren: true);
        }

        private float ElementHeightCallback(int index) {
            //Gets the height of the element. This also accounts for properties that can be expanded, like structs.
            float propertyHeight = EditorGUI.GetPropertyHeight(m_reorderableList.serializedProperty.GetArrayElementAtIndex(index), true);

            float spacing = EditorGUIUtility.singleLineHeight / 2;

            return propertyHeight + spacing;
        }


        public override void OnInspectorGUI() {
            serializedObject.Update();
            m_reorderableList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}