using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tween : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI letterText;
    [SerializeField] private float colorChangeDuration = 2f;
    [SerializeField] private float delayBeforeDisappear = 1f;
    
    private Letter _letter;

    void Start()
    {
        LeanTween.value(_letter.gameObject, _letter.ChangeLetterColor, Color.white, Color.red, colorChangeDuration)
            .setOnComplete(() => StartCoroutine(DelayBeforeDisappear()));
    }

    // void UpdateTextColor(Color color)
    // {
    //     // Update the text color during the tween
    //     _letter.ChangeLetterColor(color);
    // }

    IEnumerator DelayBeforeDisappear()
    {
        // Wait for the specified delay before making the text disappear
        yield return new WaitForSeconds(delayBeforeDisappear);

        // Tween the alpha to 0 to make the text disappear
        LeanTween.value(gameObject, UpdateTextAlpha, _letter.GetLetterColor().a, 0f, colorChangeDuration)
            .setOnUpdate(UpdateTextAlpha)
            .setOnComplete(() => Destroy(gameObject));
    }

    void UpdateTextAlpha(float alpha)
    {
        // Update the text alpha during the alpha tween
        Color currentColor = _letter.GetLetterColor();
        _letter.ChangeLetterColor(new Color(currentColor.r, currentColor.g, currentColor.b, alpha));
    }

    public void SetCurrLetter(Letter newLetter)
    {
        this._letter = newLetter;
    }
}
