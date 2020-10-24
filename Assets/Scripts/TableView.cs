using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _titleField = null;
    [SerializeField]
    private ColumnView _columnTemplate = null;
    
    private JsonDataModel _jsonData;
    private string _title;
    private string[] _columnKeys;
    private List<Dictionary<string, string>> _rowDataMap;
    
    private List<ColumnView> _columnViewList = new List<ColumnView>();
    
    public void SetData(JsonDataModel jsonData)
    {
        _title = jsonData.Title;
        _titleField.text = _title;
        _columnKeys = jsonData.ColumnHeaders;
        _rowDataMap = jsonData.Data;

        int lastColumnIndex = _columnViewList.Count - 1;
        
        for (int i = 0; i < _columnKeys.Length; i++)
        {
            string key = _columnKeys[i];
            
            ColumnView column;
            
            if (lastColumnIndex < i)
            {
                column = Instantiate(_columnTemplate, _columnTemplate.transform.parent);
                _columnViewList.Add(column);
            }
            else
            {
                column = _columnViewList[i];
            }

            column.Initialize(key);
            
            for (int j = 0; j < _rowDataMap.Count; j++)
            {
                column.SetItemData(_rowDataMap[j][key]);
            }
            
            column.SetColumn();
            column.gameObject.SetActive(true);
        }

        for (int i = _columnKeys.Length; i < _columnViewList.Count; i++)
        {
            _columnViewList[i].gameObject.SetActive(false);
        }
    }
}
