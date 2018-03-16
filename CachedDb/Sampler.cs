using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace CachedDb
{
    internal class Sampler
    {
        internal static Byte[] NewUpIngredients()
        {
            var ingredients = "ID\tINGREDIENT\n1\tMilk\n2\tSugar\n3\tFlour";

            return Compress(ingredients);
        }

        internal static Byte[] NewUpRecipies()
        {
            var recipies = "ID\tDESCRIPTION\n1\tCake\n2\tBread";
            return Compress(recipies);
        }

        private static byte[] Compress(string coded)
        {
            Byte[] result;
            using (MemoryStream target = new MemoryStream())
            {
                using (GZipStream from = new GZipStream(target, CompressionMode.Compress))
                {
                    using (var outcome = new MemoryStream(Encoding.UTF8.GetBytes(coded)))
                    {
                        outcome.CopyTo(from);
                    }
                }
                result = target.ToArray();
            }
            return result;
        }


    }
}