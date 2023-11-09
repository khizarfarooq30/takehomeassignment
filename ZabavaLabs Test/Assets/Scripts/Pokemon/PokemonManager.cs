using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PokemonManager : MonoBehaviour
{
    private const string POKEMON_URL = "https://pokeapi.co/api/v2/pokemon/";

    [SerializeField] private PokemonInfo pokemonInfoTemplate;
    [SerializeField] private RectTransform holder;
    
    [SerializeField] private int minPokemonID = 1;
    [SerializeField] private int maxPokemonID = 10;

    private void Start()
    {
        StartCoroutine(FetchPokemonsInRange(minPokemonID, maxPokemonID));
    }

    private IEnumerator FetchPokemonsInRange(int startID, int endID)
    {
        for (int id = startID; id <= endID; id++)
        {
            PokemonInfo pokemonInfo = Instantiate(pokemonInfoTemplate, holder);
            pokemonInfo.gameObject.SetActive(true);
            
            string pokemonNameOrId = id.ToString(); 
            yield return StartCoroutine(GetPokemonData(POKEMON_URL + pokemonNameOrId + "/", pokemonInfo));
        }
    }

    private IEnumerator GetPokemonData(string url, PokemonInfo pokeInfo)
    {
        var getRequest = Request(url);
        yield return getRequest.SendWebRequest();

        if (getRequest.result == UnityWebRequest.Result.ConnectionError ||
            getRequest.result == UnityWebRequest.Result.ProtocolError ||
            getRequest.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.LogError(getRequest.error);
            yield break;
        }

        var deserealizedPokemonData = JsonUtility.FromJson<PokemonData>(getRequest.downloadHandler.text);

        var pokemonSpriteUrl = deserealizedPokemonData.sprites.front_default;
        var pokemonTextureRequest = UnityWebRequestTexture.GetTexture(pokemonSpriteUrl);
        yield return pokemonTextureRequest.SendWebRequest();

        var pokemonSpriteTexture = DownloadHandlerTexture.GetContent(pokemonTextureRequest);
        var pokemonSpriteRect = new Rect(0, 0, pokemonSpriteTexture.width, pokemonSpriteTexture.height);
        var pokemonSprite = Sprite.Create(pokemonSpriteTexture, pokemonSpriteRect, Vector2.zero);

        pokeInfo.SetPokemonInfo(deserealizedPokemonData.name, deserealizedPokemonData.weight, pokemonSprite);
    }

    private UnityWebRequest Request(string path)
    {
        var request = new UnityWebRequest(path, "GET");

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }
}

[System.Serializable]
public class PokemonData
{
    public string name;
    public string weight;
    public Sprites sprites;
}

[System.Serializable]
public class Sprites
{
    public string front_default;
}