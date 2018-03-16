using file2objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CachedDb
{
    [TestClass]
    public class ReadMiniDbTest
    {

        [TestMethod]
        public void ShouldRegister2Tables()
        {
            MiniStorage db = NewStorage();
            Assert.IsNotNull(db);
        }

        [TestMethod]
        public void ShouldDecompressTwoTables()
        {
            MiniStorage db = NewStorage();
            var repos = db.ReadRepos();
            Assert.IsNotNull(db);

        }

        [TestMethod]
        public void ShouldRestoreIngredients()
        {
            MiniStorage db = NewStorage();
            var ingredients = PlainTextReader.Split(db.ReadRepos()[0].Content, "\n")
                .DelimitBy(ColumnDelimiter.Tab)
                .GetAListOf<Ingredients>();
            Assert.AreEqual(3, ingredients.Count);
        }

        private static MiniStorage NewStorage()
        {
            var db = new MiniStorage();
            db.Register(new List<StoreDefinition> {
                new StoreDefinition("Ingredients", Sampler.NewUpIngredients()),
                new StoreDefinition("Recipies", Sampler.NewUpRecipies())
            });
            return db;
        }


    }

    internal class Ingredients
    {
        public int ID { get; set; }
        public string INGREDIENT { get; set; }
    }
}
