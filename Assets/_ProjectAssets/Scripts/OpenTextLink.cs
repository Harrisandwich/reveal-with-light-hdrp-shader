using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class OpenTextLink : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text _linkText;
    [SerializeField] private string _linkId;
    [SerializeField] private string _url;

    public void OnPointerClick(PointerEventData eventData)
    {
        var linkIndex = TMP_TextUtilities.FindIntersectingLink(_linkText, Input.mousePosition, null);
        var linkId = _linkText.textInfo.linkInfo[linkIndex].GetLinkID();

        if (linkId == _linkId)
        {
            Debug.Log($"Opening Link: {_url}");
            Application.OpenURL(_url);
        }
    }
}
