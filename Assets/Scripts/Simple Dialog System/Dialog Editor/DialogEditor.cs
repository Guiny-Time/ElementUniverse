using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogEditor : MonoBehaviour
    {
        private String _fileName = "";
        private String _savePath = "Assets/Resources/Dialogs/";
        private Dialog _dialog;
        private StringBuilder _builder = new StringBuilder();
        private int _tagIdx = 0;

        public TMP_InputField contentView;
        public InputField tagField;
        public InputField tagValue;

        private void Update()
        {
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftControl)) &&
                (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftAlt)))
            {
                Debug.Log("TAG");
                AddTag();
            }
            
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftControl)) &&
                Input.GetKey(KeyCode.E))
            {
                Debug.Log("Save");
                Save();
            }
        }

        public void AddTag()
        {
            if (_dialog == null) _dialog = new Dialog();
            if (tagField.text.Length > 0 && tagValue.text.Length > 0)
            {
                TagPair pair = new TagPair(_tagIdx, tagField.text, tagValue.text);
                _dialog.tagPairs.Add(pair);
                _builder.AppendFormat("\nIndex: {0} Tag: {1}  Value: {2} \n",_tagIdx++, tagField.text, tagValue.text);
                contentView.text = _builder.ToString();
                tagValue.text = "";
            }
        }

        public void SetFileName(String fileName)
        {
            _fileName = fileName;
        }

        public void SetSavePath(String savePath)
        {
            _savePath = savePath;
        }

        public void NewFile()
        {
            _builder.Clear();
            contentView.text = "";
            tagField.text = "";
            tagValue.text = "";
            
            _dialog = new Dialog();
        }

        public void Save()
        {
            if (_fileName.Length == 0) return; 
            String jsonContent = JsonUtility.ToJson(_dialog);
            FileStream file = new FileStream
                (_savePath + _fileName + ".json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(jsonContent);
            writer.Close();
            file.Close();
            AssetDatabase.Refresh();
        }
    }
    
}
