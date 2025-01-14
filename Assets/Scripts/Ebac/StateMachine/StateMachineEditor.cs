using UnityEngine;
using System.Linq;
using UnityEditor;

[CustomEditor(typeof(FSMExample))]
public class StateMachineEditor : Editor
{
    public bool showFoldout;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        FSMExample fsmExample = (FSMExample)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        if (fsmExample.stateMachine == null) return;

        if (fsmExample.stateMachine.CurrentState != null) {
            EditorGUILayout.LabelField("Current State", fsmExample.stateMachine.CurrentState.ToString());
        }

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaible States");

        if (showFoldout) {
            if (fsmExample.stateMachine.dictionaryStates != null) {
                var keys = fsmExample.stateMachine.dictionaryStates.Keys.ToArray();
                var vals = fsmExample.stateMachine.dictionaryStates.Values.ToArray();

                for (int i = 0; i < keys.Length; i++) {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }
            }
        }
    }
}
