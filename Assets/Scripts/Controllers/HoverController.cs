using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MaskSeeker.Generic;
using UnityEngine.EventSystems;

public class HoverController : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    GameObject _hoverPanel;
    [SerializeField]
    Text _abilityName;
    [SerializeField]
    Text _descriptorName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void CheckAbilityTag()
    {
        MaskAbility a;
        switch (this.tag)
        {
            case "ability1":
                a = (MaskAbility)Player.instance._currentMask.Abilities[0].GetComponent(typeof(MaskAbility));
                break;
            case "ability2":
                a = (MaskAbility)Player.instance._currentMask.Abilities[1].GetComponent(typeof(MaskAbility));
                break;
            case "ability3":
                a = (MaskAbility)Player.instance._currentMask.Abilities[2].GetComponent(typeof(MaskAbility));
                break;
            case "ability4":
                a = (MaskAbility)Player.instance._currentMask.Abilities[3].GetComponent(typeof(MaskAbility));
                break;
            default:
                Debug.Log("ENTRO EN DEFAULT");
                a = null;
                break;
        }
        _abilityName.text = a.MaskAbilityStats._name;
        _descriptorName.text = a.MaskAbilityStats._description;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CheckAbilityTag();
        _hoverPanel.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _hoverPanel.SetActive(false);
    }
}
