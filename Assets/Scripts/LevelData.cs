using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    List<Element> elementList = new List<Element>(); // List of all the elements from every levels
     
    public void Parse(string csvFile)
    {
        TextAsset csvData = Resources.Load<TextAsset>(csvFile); // Load csvFile
        string[] line = csvData.text.Split('\n');   // Divide lines
        for (int i = 1; i < line.Length; i++)
        {
            string[] row = line[i].Split(',');  // Divide commas

            Element element = new Element();    // Assign values to the element
            element.level = int.Parse(row[0]);
            element.type = int.Parse(row[1]);
            element.pos = new Vector3(float.Parse(row[2]), float.Parse(row[3]), float.Parse(row[4]));
            if (element.type != 2)  // If not slot give gene values
            {
                element.y[0] = int.Parse(row[5]);
                element.y[1] = int.Parse(row[6]);
                element.r[0] = int.Parse(row[7]);
                element.r[1] = int.Parse(row[8]);
            }

            elementList.Add(element);
        }
    }

    // Return array of list that corresponds to the level of the parameter
    public Element[] GetElements(int level)
    {
        List<Element> levelList = new List<Element>();

        for (int i = 0; i < elementList.Count; i++)
        {
            if (elementList[i].level == level)
            {
                levelList.Add(elementList[i]);
            }
        }

        return levelList.ToArray();
    }
}
