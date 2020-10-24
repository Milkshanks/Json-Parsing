using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonParser : MonoBehaviour
{
    [SerializeField]
    private TableView _table = null;
    
    private const string _jsonFileName = "JsonChallenge.json";

    private bool _needToParse;
    private string _jsonDataPath;
    private FileSystemWatcher _jsonWatcher;

    private void Awake()
    {
        _jsonDataPath = string.Concat(Application.streamingAssetsPath,"/", _jsonFileName);
        ParseJson(_jsonDataPath);
        _jsonWatcher = new FileSystemWatcher(Application.streamingAssetsPath);
        _jsonWatcher.Filter = _jsonFileName;
        _jsonWatcher.NotifyFilter = NotifyFilters.LastWrite;
        _jsonWatcher.Changed += JsonWatcherOnChanged;
        _jsonWatcher.EnableRaisingEvents = true;
    }

    private void JsonWatcherOnChanged(object sender, FileSystemEventArgs e)
    {
        _needToParse = true;
    }

    //This is needed due to FileSystemWatcher being executed in another thread.
    //Ideally, in a bigger, more complex solution, we'd develop a thread-safe way
    //of invoking methods in the main thread.
    private void Update()
    {
        if (_needToParse)
        {
            ParseJson(_jsonDataPath);
            _needToParse = false;
        }
    }

    private void ParseJson(string path)
    {
        string jsonData = File.ReadAllText(path);
        JsonDataModel parsedJsonData = JsonConvert.DeserializeObject<JsonDataModel>(jsonData);
        _table.SetData(parsedJsonData);
    }
}
