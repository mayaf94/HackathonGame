using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapsEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    Button mainButton;
    SettingsMenuItem[] menuItems;
    bool isExpanded = false;

    Vector2 mainButtonPos;
    int itemCount;

    void Start()
    {
        itemCount = transform.childCount - 1;
        menuItems = new SettingsMenuItem[itemCount];

        for(int i = 0; i < itemCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();
        mainButtonPos = mainButton.transform.position;

        ResetPos();
    }

    void ResetPos()
    {
        for(int i = 0; i < itemCount; i++)
        {
            menuItems[i].transForm.position = mainButtonPos;
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            for (int i = 0; i < itemCount; i++)
            {
                //menuItems[i].transForm.position = mainButtonPos + spacing * (i + 1);
                menuItems[i].transForm.DOMove(mainButtonPos + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }
        else
        {
            for (int i = 0; i < itemCount; i++)
            {
                //menuItems[i].transForm.position = mainButtonPos;
                menuItems[i].transForm.DOMove(mainButtonPos, collapseDuration).SetEase(collapsEase);
                menuItems[i].img.DOFade(0f, collapseFadeDuration);
            }
        }

        mainButton.transform.DORotate(Vector3.forward * 180f, rotationDuration)
            .From(Vector3.zero)
            .SetEase(rotationEase);
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
