using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalCount : MonoBehaviour
{
    Text counter;
    public bool AddCrystal;
    FileEditor FileEdit = new FileEditor();
    int tokens = 0;
    // Start is called before the first frame update
    void Start()
    {
        counter = gameObject.GetComponent<Text>();
        try
        {
            tokens = int.Parse(FileEdit.ReadString("Assets/SaveFile"));
        }
        catch (System.Exception)
        {
            tokens = 0;
        }
        counter.text = tokens.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (AddCrystal)
        {
            AddCrystal = false;
            tokens++;
            FileEdit.WriteString("Assets/SaveFile", tokens.ToString());
            counter.text = tokens.ToString();
        }
    }
    /*
    string Encrypt(string textString, int offset, int stride)
    {
        char text[] = new char[];
            text = textString.ToCharArray();
        for (int i = 0; i < text.length; i++)
        {

        }
        return Encryptedtext;
    }*/
}
