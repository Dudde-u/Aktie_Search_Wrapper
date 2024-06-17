

namespace Class_library
{
    public interface ISaveable
    {
        string JsonString { get; set; }
        string FileIdentifier { get; }
        string FolderName { get; }
        int deltaHours { get; }

    }
    public interface ISettable
    {
        string JsonString { get; set; }
        string Address { get; set; }

        bool isSet { get; set; }
        void ensureIsSet();
    }
}
