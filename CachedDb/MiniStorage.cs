using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace CachedDb
{
    public class MiniStorage
    {
        private List<StoreDefinition> definitions;

        public void Register(List<StoreDefinition> definitions)
        {
            this.definitions = definitions;
        }

        internal List<StoreInfo> ReadRepos()
        {
            var infos = definitions.Select(ToInfo).ToList();
            return infos;
        }

        private StoreInfo ToInfo(StoreDefinition def)
        {
            return new StoreInfo
            {
                RepoName = def.Name,
                Content = Decompress(def.Content)
            };
        }

        private string Decompress(byte[] content)
        {
            var result = string.Empty;
            using (var from = new MemoryStream(content))
            {
                using (var dec = new GZipStream(from, CompressionMode.Decompress))
                {
                    using (var to = new MemoryStream())
                    {
                        dec.CopyTo(to);
                        result = Encoding.UTF8.GetString(to.ToArray());
                    }
                }
            }
            return result;
        }
    }
}