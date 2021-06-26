using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public static class CustomEditorUtility
{
    public static void DrawList(SerializedProperty self)
    {
        if (!self.isArray || self.propertyType == SerializedPropertyType.String)
        {
            EditorGUILayout.PropertyField(self, new GUIContent(self.displayName), true);
            return;
        }
        
        using (new GUILayout.HorizontalScope())
        {
            EditorGUILayout.PropertyField(self, new GUIContent(string.Format("{0} [{1}]", self.displayName, self.arraySize)), false);
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(EditorGUIUtility.TrIconContent("d_winbtn_graph_max_h"), "RL FooterButton", GUILayout.Width(16)))
            {
                self.isExpanded = true;
                for (var i = 0; i < self.arraySize; i++)
                    self.GetArrayElementAtIndex(i).isExpanded = true;
                return;
            }
            if (GUILayout.Button(EditorGUIUtility.TrIconContent("d_winbtn_graph_min_h"), "RL FooterButton", GUILayout.Width(16)))
            {
                self.isExpanded = false;
                for (var i = 0; i < self.arraySize; i++)
                    self.GetArrayElementAtIndex(i).isExpanded = false;
                return;
            }
            if (GUILayout.Button(EditorGUIUtility.TrIconContent("Toolbar Plus"), "RL FooterButton", GUILayout.Width(16)))
                self.InsertArrayElementAtIndex(self.arraySize);
        }
        if (!self.isExpanded)
            return;
    
        using (new EditorGUI.IndentLevelScope(1))
        {
            if (self.arraySize <= 0)
                EditorGUILayout.LabelField("Array is Empty");
        
            for (var i = 0; i < self.arraySize; i++)
            {
                var prop = self.GetArrayElementAtIndex(i);
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.PropertyField(prop, new GUIContent(i.ToString()), prop.propertyType != SerializedPropertyType.Generic);
                    if (GUILayout.Button(EditorGUIUtility.TrIconContent("Toolbar Minus"), "RL FooterButton", GUILayout.Width(16)))
                    {
                        self.DeleteArrayElementAtIndex(i);
                        return;
                    }
                }
                
                if (prop.propertyType != SerializedPropertyType.Generic || !prop.isExpanded)
                    continue;
                using (new EditorGUI.IndentLevelScope(1))
                {
                    using (new GUILayout.VerticalScope("box"))
                    {
                        var skipCount = 0;
                        while (prop.NextVisible(true))
                        {
                            if (skipCount > 0)
                            {
                                skipCount--;
                                continue;
                            }
                            if (prop.depth != self.depth + 2)
                                break;
                            if (prop.isArray && prop.propertyType != SerializedPropertyType.String)
                            {
                                DrawList(prop);
                                skipCount = prop.arraySize + 1; 
                                continue;
                            }
                            
                            EditorGUILayout.PropertyField(prop, false);
                        }
                    }
                }
            }
        }
    }
}