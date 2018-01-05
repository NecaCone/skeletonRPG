using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 

public class PPSerialization {



	//Stream is a representation of bytes. Both these classes derive from the Stream class which is abstract by definition.
	//As the name suggests, a FileStream reads and writes to a file whereas a MemoryStream reads and writes to the memory. So it relates to where the stream is stored.
	//Now it depends how you plan to use both of these. For eg: Let us assume you want to read binary data from the database, you would go in for a MemoryStream. However if you want to read a file on your system, you would go in for a FileStream.
	//One quick advantage of a MemoryStream is that there is not need to create temporary buffers and files in an application.

	public static BinaryFormatter binaryFormatter = new BinaryFormatter();
	public static void Save(string saveTag, object obj)
	{
		MemoryStream memoryStream = new MemoryStream ();
		//memori stream 
		binaryFormatter.Serialize (memoryStream, obj);
		//temp lokalna promenljiva koja ce sadrzati binarni format 
		string temp = System.Convert.ToBase64String (memoryStream.ToArray ());
		PlayerPrefs.SetString (saveTag, temp);	 
	}


	public static object Load(string saveTag)
	{
		string temp = PlayerPrefs.GetString (saveTag);
		if (temp == string.Empty) {						
			return null;		
		}
		MemoryStream memoryStream = new MemoryStream (System.Convert.FromBase64String (temp));
		//desirralizuje serializovane objekte koji su sacuvani u binarnom foramtu i vraca ih u objekat
		return binaryFormatter.Deserialize(memoryStream);
	}

}
