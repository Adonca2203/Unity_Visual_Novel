using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    public string characterName;
    [HideInInspector] public RectTransform root;

    public bool enabled { get { return root.gameObject.activeInHierarchy; } set { root.gameObject.SetActive(value); } }

    DialogueSystem dialogue;

    public void Say(string speech, bool add = false)
    {

        if(!enabled)
        {

            enabled = true;

        }

        if (!add)
            dialogue.Say(speech, characterName);
        else
            dialogue.SayAdd(speech, characterName);

    }

    public Character(string _name, bool enableOnStart = true)
    {

        CharacterManager cm = CharacterManager.instance;
        GameObject prefab = Resources.Load("Character/Prefab/Char[" + _name + "]") as GameObject;
        GameObject ob = GameObject.Instantiate(prefab, cm.characterPanel);

        root = ob.GetComponent<RectTransform>();
        characterName = _name;

        // Get the renderer(s)
        renderers.bodyRenderer = ob.transform.Find("bodyLayer").GetComponent<Image>();
        renderers.expressionRenderer = ob.transform.Find("expressionLayer").GetComponent<Image>();

        dialogue = DialogueSystem.instance;

        enabled = enableOnStart;

    }

    [System.Serializable]
    public class Renderers
    {

        /// <summary>
        /// Use only for single layer charaters
        /// </summary>
        //public RawImage singleLayerImage;

        /// <summary>
        /// The body image for a multi layer character
        /// </summary>
        public Image bodyRenderer;

        /// <summary>
        /// The face/expression image for a multi layer character
        /// </summary>
        public Image expressionRenderer;

    }

    public Renderers renderers = new Renderers();

}
