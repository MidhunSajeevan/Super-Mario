using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerMovement))]
public class NewBehaviourScript : Editor
{

    public override void OnInspectorGUI()
    {
        PlayerMovement _playerMovement= (PlayerMovement)target;

        _playerMovement._speed = EditorGUILayout.FloatField("Player Speed ", _playerMovement._speed);
        _playerMovement._velocity=EditorGUILayout.Vector2Field("Player Velocity",_playerMovement._velocity);
    }
}
