using System.Linq;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    public bool showFoldout;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        Player player = (Player)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        if (player.stateMachine == null)
            return;

        if (player.stateMachine.CurrentState != null) {
            EditorGUILayout.LabelField("Current State", player.stateMachine.CurrentState.ToString());
        }

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaible States");

        if (showFoldout) {
            if (player.stateMachine.dictionaryStates != null) {
                var keys = player.stateMachine.dictionaryStates.Keys.ToArray();
                var vals = player.stateMachine.dictionaryStates.Values.ToArray();

                for (int i = 0; i < keys.Length; i++) {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }
            }
        }
    }
}
