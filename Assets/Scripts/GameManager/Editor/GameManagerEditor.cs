using System.Linq;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public bool showFoldout;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GameManager gm = (GameManager)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        if (gm.stateMachine == null)
            return;

        if (gm.stateMachine.CurrentState != null) {
            EditorGUILayout.LabelField("Current State", gm.stateMachine.CurrentState.ToString());
        }

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaible States");

        if (showFoldout) {
            if (gm.stateMachine.dictionaryStates != null) {
                var keys = gm.stateMachine.dictionaryStates.Keys.ToArray();
                var vals = gm.stateMachine.dictionaryStates.Values.ToArray();

                for (int i = 0; i < keys.Length; i++) {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }
            }
        }
    }
}
