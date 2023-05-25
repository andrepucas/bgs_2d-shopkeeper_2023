using UnityEngine;

public class UIPanelRoam : UIPanelAbstract
{
    // --- METHODS -------------------------------------------------------------

    // Shows panel.
    public new void Open(float p_fade = 0) => base.Open(p_fade);

    // Hides panel.
    public new void Close(float p_fade = 0) => base.Close(p_fade);

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();
        #endif
    }
}
