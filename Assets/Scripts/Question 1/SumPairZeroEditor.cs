using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MadeOverGame.Question1
{
    [CustomEditor(typeof(SumPairZero))]
    [CanEditMultipleObjects]
    public class SumPairZeroEditor : Editor
    {
        bool sumTwo = false, sumThree = false, calculated = false;

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            SumPairZero spz = (SumPairZero)target;

            if (GUILayout.Button("Calculate"))
            {
                sumTwo = spz.IsSumTwoZero(spz.sampleArray);
                sumThree = spz.IsSumThreeZero(spz.sampleArray);
                calculated = true;
            }

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("IsSumTwoZero", GUILayout.Width(EditorGUIUtility.labelWidth - 4));
                EditorGUILayout.SelectableLabel(calculated ? (sumTwo ? "true" : "false") : "", EditorStyles.textField, GUILayout.Height(EditorGUIUtility.singleLineHeight));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("IsSumThreeZero", GUILayout.Width(EditorGUIUtility.labelWidth - 4));
                EditorGUILayout.SelectableLabel(calculated ? (sumThree ? "true" : "false") : "", EditorStyles.textField, GUILayout.Height(EditorGUIUtility.singleLineHeight));
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
