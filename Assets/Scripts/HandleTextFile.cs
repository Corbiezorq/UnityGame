using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class HandleTextFile
{
//	[MenuItem("Tools/Write file")]
//	static void WriteString()
//	{
//		string path = "Assets/Resources/maps.txt";
//
//		//Write some text to the test.txt file
//		StreamWriter writer = new StreamWriter(path, true);
//		writer.WriteLine("Test");
//		writer.Close();
//
//		//Re-import the file to update the reference in the editor
//		AssetDatabase.ImportAsset(path); 
//		TextAsset asset = Resources.Load("maps");
//
//		//Print the text from the file
//		Debug.Log(asset.text);
//	}

	[MenuItem("Tools/Read file")]
	public static Map[] ReadJson(string fileName)
	{
		string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

		if(File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath); 
			MapsHolder loadedData = JsonUtility.FromJson<MapsHolder>(dataAsJson);
			return loadedData.mapObjects;
		}
		return null;
	}

}