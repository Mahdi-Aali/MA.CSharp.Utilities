using MA.CSharp.Utilities.Text;
using System.Reflection;
using System.Text.Json;
using System.Xml.Serialization;

namespace MA.CSharp.Utilities.Object;

public static class ObjectUtilities
{
    public static bool IsNull(this object obj) => obj == null;
    public static bool IsNotNull(this object obj) => obj != null;
    public static string SerializeAsJson(this object obj) => JsonSerializer.Serialize(obj);
    public static T DeserializeFromJson<T>(this string jsonDocument) => JsonSerializer.Deserialize<T>(jsonDocument)!;
    public static string SerializeAsXML(this object obj)
    {
        XmlSerializer xs = new(obj.GetType());
        using (MemoryStream ms = new())
        {
            xs.Serialize(ms, obj);
            return ms.ToArray().GetUtf8StringFromBytes();
        }
    }
    public static T DeserializeFromXml<T>(this string xmlDocument)
    {
        XmlSerializer xs = new(typeof(T));
        using (MemoryStream ms = new(xmlDocument.GetUtf8Bytes()))
        {
            return (T)xs.Deserialize(ms)!;
        }
    }
    public static PropertyInfo[] GetProperties(this object obj) => obj.GetType().GetProperties();
    public static PropertyInfo[] GetProperties(this object obj, BindingFlags bindingFlags) =>
        obj.GetType().GetProperties(bindingFlags);

    public static PropertyInfo GetProperty(this object obj, string propertyName) => obj.GetType().GetProperty(propertyName)!;
    public static bool Is<T>(this object obj) => obj is T;
    public static T GetPropertyValue<T>(this object obj, string propertyName)
    {
        try
        {
            return (T)obj.GetType().GetProperty(propertyName)?.GetValue(obj)!;
        }
        catch
        {
            return default(T)!;
        }
    }

    public static void SetPropertyValue<T>(this object obj, string propertyName, T value)
    {
        try
        {
            obj.GetProperty(propertyName)?.SetValue(obj, value);
        }
        catch
        {
            // do nothing;
        }
    }
    public static bool HasBaseType<T>(this object obj)
    {
        return obj.GetType().BaseType == typeof(T);
    }
}
