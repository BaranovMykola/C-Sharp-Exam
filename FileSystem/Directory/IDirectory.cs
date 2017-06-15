using System.Runtime.Serialization;

namespace FileSystem.Directory
{
    public interface IDirectory : ISerializable
    {
        string Name { get; set; }
    }
}
