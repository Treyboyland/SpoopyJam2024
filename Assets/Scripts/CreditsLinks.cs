using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsLinks : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    Camera cameraToCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenLink()
    {
        //Null for overlay canvases
        var linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
        var wordIndex = TMP_TextUtilities.FindIntersectingWord(text, Input.mousePosition, null);

        if (linkIndex != -1)
        {
            var linkInfo = text.textInfo.linkInfo[linkIndex];
            var url = linkInfo.GetLinkID();
            Application.OpenURL(url);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenLink();
    }
}
