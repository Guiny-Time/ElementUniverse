using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogText
    {
        private List<Dialog> _dialogs;
        private int _index = -1;
        private int _size = -1;

        public int DialogCount
        {
            get { return _size; }
        }

        public DialogText(List<Dialog> dialogs)
        {
            if(dialogs == null) Debug.LogError("INVALID DIALOG FILE");
            _dialogs = dialogs;
            _size = dialogs.Count;
        }
        
        /// <summary>
        /// return the next dialog content
        /// return null if the pointer is at end of the dialog
        /// </summary>
        /// <returns></returns>
        public Dialog Next()
        {
            if (_index < _size) return _dialogs[_index++];
            else return null;
        }
        
        /// <summary>
        /// set the pointer to the specific index, and returns the specific content
        /// </summary>
        /// <param name="index"> the specific index of the dialog content </param>
        /// <returns></returns>
        public Dialog Jump(int index)
        {
            _index = index;
            return _dialogs[_index];
        }

        /// <summary>
        /// return the specific dialog, but will not change the pointer of the text
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Dialog GetDialogByIndex(int index)
        {
            return _dialogs[_index];
        }

    }

    /// <summary>
    /// Tag means attribute.
    /// User can costume the tag and value so that users can define actions based on the pair. 
    /// </summary>
    [Serializable]
    public class TagPair
    {
        public int idx;
        public String tag;
        public String value;

        public TagPair(int idx, String tag, String value)
        {
            this.idx = idx;
            this.tag = tag;
            this.value = value;
        }
    }
    
    /// <summary>
    /// A single dialog sentence or just sentences of a plot.
    /// </summary>
    [Serializable]
    public class Dialog
    {
        public List<TagPair> tagPairs = new List<TagPair>();
    }
}
