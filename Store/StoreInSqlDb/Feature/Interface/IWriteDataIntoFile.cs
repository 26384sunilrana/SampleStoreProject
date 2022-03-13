namespace Store.Feature.Interface
{
    public interface IWriteDataIntoFile
    {
        void WriteIntoJsonFile(string data, string outFilePath);
    }
}
