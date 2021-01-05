using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConsoleLogController : MonoBehaviour
{

    public Text _ConsoleText;
    public AudioSource _textSoundEnd;

    [SerializeField]
    private float _writeTime;

    //Singleton
    public static ConsoleLogController _instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // New Way BTW!
        TryGetComponent<Text>(out _ConsoleText);
        TryGetComponent<AudioSource>(out _textSoundEnd);




    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Skip()
    {
        _writeTime = 0;
    }


    public void Clear()
    {
        this._ConsoleText.text = "";

    }
    public void Write(string text)
    {
        StartCoroutine(WritePokemonStyle(text));
    }


    private IEnumerator WritePokemonStyle(string text)
    {
        // Skip proccess
        float aux = _writeTime;
        ConsoleLogController._instance.Clear();
        this._ConsoleText.text += ReturnTimeStamp();
        this._ConsoleText.text += " ";
        for (int i = 0; i < text.Length; ++i)
        {
            yield return new WaitForSeconds(_writeTime);
            this._ConsoleText.text += text[i];
        }
        this._ConsoleText.text += "\n";
        _writeTime = aux;
        _textSoundEnd.Play();
        yield return null;
    }

    private string ReturnTimeStamp()
    {
        return string.Format("[{0}:{1}] ", System.DateTime.Now.Hour, System.DateTime.Now.Minute);
    }

}
