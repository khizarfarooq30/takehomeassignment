using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonInfo : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI pokemonName;
    [SerializeField] public TextMeshProUGUI pokemonWeight;
    [SerializeField] public Image pokemonImage;


    public void SetPokemonInfo(string name, string weight, Sprite sprite)
    {
        pokemonName.SetText("Name: " + name);
        pokemonWeight.SetText("Weight: " +  weight);
        pokemonImage.enabled = true;
        pokemonImage.sprite = sprite;
        
    }
}
