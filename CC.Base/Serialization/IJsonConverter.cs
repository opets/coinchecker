namespace CC.Base.Serialization
{
    public interface IJsonConverter
    {
        T DeserializeObject<T>(string json);
    }
}
