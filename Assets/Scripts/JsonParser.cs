using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonParser : MonoBehaviour
{

    [SerializeField]
    private TableView _table = null;
    
    private const string _jsonPathSuffix = "/StreamingAssets/JsonChallenge.json";
    
    private void Awake()
    {
        ParseJson();
    }

    private void ParseJson()
    {
        string jsonData = File.ReadAllText(string.Concat(Application.dataPath, _jsonPathSuffix));
        JsonDataModel parsedJsonData = JsonConvert.DeserializeObject<JsonDataModel>(jsonData);
        _table.SetData(parsedJsonData);
    }
}
