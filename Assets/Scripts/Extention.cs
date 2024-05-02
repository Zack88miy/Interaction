using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extention
{
    //参照渡し回避用(オブジェクトのコピー)
    public static object DeepCopy(this object target)
    {
        object result;
        BinaryFormatter b = new BinaryFormatter();
        MemoryStream mem = new MemoryStream();

        try 
        {
            b.Serialize(mem,target);
            mem.Position = 0;
            result = b.Deserialize(mem);
        }
        finally
        {
            mem.Close();
        }

        return result;
    } 
}
