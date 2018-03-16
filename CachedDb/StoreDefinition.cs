using System;

namespace CachedDb
{
    public class StoreDefinition
    {
        public StoreDefinition(string name,  Byte[] content)
        {
            this.Name = name;
            this.Content = content;
        }

        public string Name { get; }
        public byte[] Content { get; }
    }
}