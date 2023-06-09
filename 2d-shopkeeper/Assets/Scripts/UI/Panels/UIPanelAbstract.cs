using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract class that handles opening and closing panel behaviours.
/// </summary>
public abstract class UIPanelAbstract : MonoBehaviour
{
    // --- VARIABLES -----------------------------------------------------------

    [Tooltip("Canvas group of this panel.")]
    [SerializeField] private CanvasGroup _canvasGroup;

    // --- METHODS -------------------------------------------------------------

    // Enables and reveals panel.
    protected void Open(float p_transition)
    {
        // Stops all coroutines.
        StopAllCoroutines();

        // If transition time is 0.
        if (p_transition == 0)
        {
            // Directly reveals and enables everything in canvas group.
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        // Otherwise, reveal it over time.
        else StartCoroutine(RevealOverTime(p_transition));
    }

    // Hides and disables panel.
    protected void Close(float p_transition)
    {
        // Stops all coroutines.
        StopAllCoroutines();
        
        // Stops blocking raycasts right away.
        _canvasGroup.blocksRaycasts = false;

        // If transition time is 0.
        if (p_transition == 0)
        {
            // Directly hides and disables everything in canvas group, 
            // including the game object.
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
        }

        // Otherwise, hides and disables over time.
        else StartCoroutine(HideOverTime(p_transition));
    }

    // Reveals panel over specified time.
    private IEnumerator RevealOverTime(float p_transition)
    {
        // Sets elapsed time to 0.
        float m_elapsedTime = 0;

        // Sets as interactable right away, to display correct child UI colors.
        _canvasGroup.interactable = true;

        // While the canvas isn't fully revealed.
        while (_canvasGroup.alpha < 1)
        {
            // Lerps the canvas alpha value from 0 to 1.
            _canvasGroup.alpha = Mathf.Lerp(0, 1, (m_elapsedTime/p_transition));

            // Updates elapsed time based on unscaled delta time.
            m_elapsedTime += Time.unscaledDeltaTime;

            yield return null;
        }

        // Fully reveals and enables canvas group elements.
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    // Hides panel over specified time, and disables it.
    private IEnumerator HideOverTime(float p_transition)
    {
        // Sets elapsed time to 0.
        float m_elapsedTime = 0;

        // While the canvas isn't fully hidden.
        while (_canvasGroup.alpha > 0)
        {
            // Lerps the canvas alpha value from 1 to 0.
            _canvasGroup.alpha = Mathf.Lerp(1, 0, (m_elapsedTime/p_transition));

            // Updates elapsed time based on unscaled delta time.
            m_elapsedTime += Time.unscaledDeltaTime;

            yield return null;
        }

        // Fully hides and disables canvas group elements.
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }
}
