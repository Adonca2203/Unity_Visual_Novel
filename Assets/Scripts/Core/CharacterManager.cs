using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for adding and maintaining characters in a scene
/// </summary>
public class CharacterManager : MonoBehaviour
{

    public static CharacterManager instance;

    /// <summary>
    /// All characters must be attached to a character panel
    /// </summary>

    public RectTransform characterPanel;

    /// <summary>
    /// All characters currently in the scene
    /// </summary>
    public List<Character> characters = new List<Character>();

    /// <summary>
    /// Easy lookup for characters
    /// </summary>
    public Dictionary<string, int> characterDict = new Dictionary<string, int>();

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Try to get a character by name from the character list
    /// </summary>
    /// <param name="name">Character Name</param>
    public Character GetCharacter(string characterName, bool createCharacterIfNotExist = true, bool enableCharacterOnStart = true)
    {

        int index = -1;

        if(characterDict.TryGetValue(characterName, out index))
        {

            return characters[index];

        }
        else if(createCharacterIfNotExist)
        {

            return CreateCharacter(characterName, enableCharacterOnStart);

        }

        return null;

    }

    /// <summary>
    /// Creates the character
    /// </summary>
    /// <param name="characterName">Character Name</param>
    /// <returns></returns>
    public Character CreateCharacter(string characterName, bool enableCharacterOnStart = true)
    {

        Character newCharacter = new Character(characterName, enableCharacterOnStart);

        characterDict.Add(characterName, characters.Count);
        characters.Add(newCharacter);

        return newCharacter;

    }

}
