using MongoDB.Driver.GridFS;
using MongoDB.Driver;

namespace BlazorControlwork.Data
{
    public class FileSystemService
    {
        public void UploadImageToDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("UserBase");
            var collection = database.GetCollection<string>("Images");
            var gridFS = new GridFSBucket(database);

            using (FileStream fs = new FileStream(@"C:\Users\iu709\OneDrive\Рабочий стол\1.png", FileMode.Open))
            {
                gridFS.UploadFromStream("sss.png", fs);
            }
        }

        public void DownloadToLocal()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Images321");
            var gridFS = new GridFSBucket(database);
            using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Images/")}DeserializedBall.png", FileMode.CreateNew))
            {
                gridFS.DownloadToStreamByName("sss.jpg", fs);
            }
        }
    }
}
