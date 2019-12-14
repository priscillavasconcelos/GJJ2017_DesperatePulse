using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class SetTexts : MonoBehaviour
{
    private static Hashtable Strings;
    public static string currentLang = "BR";

    public Text[] textsToBeTranslated;

	void Awake ()
    {
        if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            currentLang = "BR";
        }
        else
        {
            currentLang = "EN";
        }

        Text[] texts = Object.FindObjectsOfType<Text>();
        int temp = 0;
        textsToBeTranslated = new Text[texts.Length];

        for (int i = 0; i < texts.Length; i++)
        {
            if (GameObject.Find(texts[i].name))
            {
                if (texts[i].name.Contains("_TXT") || texts[i].name.Contains("txt"))
                {
                    textsToBeTranslated[temp] = texts[i];
                    temp++;
                }
            }
        }

        setLanguage(currentLang);

        SetTranslatedTexts(textsToBeTranslated);
    }

	public void SetTranslatedTexts(Text[] texts)
    {
		for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i])
            {
                texts[i].text = getString(texts[i].name.ToString());
            }
			
		}
	}

    public static void setLanguage(string language)
    {

        //var xml = new XmlDocument();
        //xml.Load(Path.Combine(Application.dataPath, "lang.xml"));

        TextAsset textAsset = (TextAsset)Resources.Load("lang", typeof(TextAsset));
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(textAsset.text);

        Strings = new Hashtable();
        var element = xml.DocumentElement[language];
        if (element != null)
        {
            var elemEnum = element.GetEnumerator();
            while (elemEnum.MoveNext())
            {
                XmlElement xmlItem = elemEnum.Current as XmlElement;
                if (xmlItem != null)
                {
                    Strings.Add(xmlItem.GetAttribute("name"), xmlItem.InnerText);
                }
            }
        }
        else
        {
            Debug.LogError("The specified language does not exist: " + language);
        }

    }

    public static string getString(string name)
    {
        if (!Strings.ContainsKey(name))
        {
            Debug.LogError("The specified string does not exist: " + name);

            return "";
        }

        return (string)Strings[name];
    }

}
