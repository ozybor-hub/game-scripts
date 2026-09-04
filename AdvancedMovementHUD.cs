using UnityEngine;
using TMPro;

public class AdvancedMovementHUD : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private AdvancedPlayerController playerController;

    [Header("Optional UI Elements")]
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private TextMeshProUGUI speedText;

    [Header("Simple OnGUI Display")]
    [SerializeField] private bool showOnGUIOverlay = true;
    [SerializeField] private int overlayFontSize = 15;

    private void Start()
    {
        if (playerController == null)
            playerController = FindAnyObjectByType<AdvancedPlayerController>();
    }

    private void Update()
    {
        if (playerController == null) return;

        if (stateText != null)
            stateText.text = "State: " + playerController.CurrentState;

        if (speedText != null)
            speedText.text = "Speed: " + playerController.CurrentSpeed.ToString("F1") + " m/s";
    }

    private void OnGUI()
    {
        if (!showOnGUIOverlay || playerController == null) return;

        GUI.skin.label.fontSize = overlayFontSize;
        GUI.skin.box.fontSize = overlayFontSize;

        GUILayout.BeginArea(new Rect(20, 20, 280, 180), GUI.skin.box);
        GUILayout.Label("<b>--- Movement Info ---</b>");
        GUILayout.Label("State: " + playerController.CurrentState);
        GUILayout.Label("Speed: " + playerController.CurrentSpeed.ToString("F2") + " m/s");
        GUILayout.Label("Grounded: " + (playerController.IsGrounded ? "YES" : "NO (In Air)"));
        GUILayout.Space(5);
        GUILayout.Label("<size=12>Controls:\nWASD: Move | Shift: Sprint\nSpace: Jump | C / Ctrl: Slide\nE / Alt: Dash</size>");
        GUILayout.EndArea();
    }
}
