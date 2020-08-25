using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    List<Element> elementList = new List<Element>(); // List of all the elements from every levels
     
    // Parse csv to data
    public void Parse(string csvFile)
    {
        TextAsset csvData = Resources.Load<TextAsset>(csvFile); // Load csvFile
        string[] line = csvData.text.Split('\n');   // Divide lines
        for (int i = 1; i < line.Length; i++)
        {
            string[] row = line[i].Split(',');  // Divide commas

            Element element = new Element();    // Assign values to the element
            element.level = int.Parse(row[0]);  // Assign level
            element.type = int.Parse(row[1]);   // Assign type
            element.pos = new Vector3(float.Parse(row[2]), float.Parse(row[3]), float.Parse(row[4]));   // Assign position
            if (element.type != 2)  // If not slot give gene values
            {
                int num;    // Assign gene
                if (int.TryParse(row[5], out num))
                    element.y[0] = num;
                if (int.TryParse(row[6], out num))
                    element.y[1] = num;
                if (int.TryParse(row[7], out num))
                    element.r[0] = num;
                if (int.TryParse(row[8], out num))
                    element.r[1] = num;
                if (int.TryParse(row[9], out num))
                    element.rw[0] = num;
                else
                    element.rw[0] = 8;  // If empty assign 8
                if (int.TryParse(row[10], out num))
                    element.rw[1] = num;
                else
                    element.rw[0] = 8;  // If empty assign 8
            }
            else     // If slot
            {
                element.y[0] = int.Parse(row[5]);   // Assign parent
                element.y[1] = int.Parse(row[6]);
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
