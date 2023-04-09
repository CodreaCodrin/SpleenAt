using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text myText;
    public string ButtonText;


    void Start()
    {
        myText = GetComponentInChildren<TMP_Text>();
        myText.text = ButtonText;  
     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.text = "";
     
    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.text = ButtonText;
   
    }

}