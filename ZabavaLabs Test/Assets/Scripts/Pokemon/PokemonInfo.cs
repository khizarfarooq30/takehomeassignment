using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonInfo : MonoBehaviour
{
    [Header("Pokemon Info")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] public TextMeshProUGUI pokemonName;
    [SerializeField] public TextMeshProUGUI pokemonWeight;
    [SerializeField] public Image pokemonImage;

    [Header("Tween Settings")]
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private Ease ease;
    
    public void SetPokemonInfo(string name, string weight, Sprite sprite)
    {
        pokemonName.SetText("Name: " + name);
        pokemonWeight.SetText("Weight: " +  weight);
        pokemonImage.enabled = true;
        pokemonImage.sprite = sprite;

        rectTransform.DOScale(1f, duration).From(0f).SetEase(ease);
        pokemonImage.DOFade(1f, 1f).From(0f);
    }
}
