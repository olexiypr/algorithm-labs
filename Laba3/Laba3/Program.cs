using System.Threading.Tasks;

namespace Laba3
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var @record = CRUD.Add("first");
            var record1 = CRUD.Add("second");
            var record2 = CRUD.Add("3");
            var re = CRUD.GetByKey(3);
            re.Value = "213333333333";
            CRUD.WriteBlocks();
        }
    }
}