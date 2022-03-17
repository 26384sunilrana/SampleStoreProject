namespace UsingEntityFramework.Feature.Interface
{
    public interface IWriteDataIntoFile
    {
        void WriteIntoJsonFile(string data, string outFilePath);
    }
}
