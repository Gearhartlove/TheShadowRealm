using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUIPanel : MonoBehaviour {
    
    [SerializeField]
    private Text debug_text;
    // Start is called before the first frame update
    void Start() {
        debug_text.text = "";
    }

    public void AppendText(string s) {
        debug_text.text = debug_text.text.Insert(0, s + '\n');
    }

}
