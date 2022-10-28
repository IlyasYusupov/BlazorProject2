using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.GridFS;

namespace BlazorControlwork.Data
{
    public static class Mongo
    {
        public static void AddToDB(User user)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBase");
            var collection = database.GetCollection<User>("User");
            collection.InsertOne(user);
        }

        public static User Find(string name)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBase");
            var collection = database.GetCollection<User>("User");
            var one = collection.Find(x => x.Login == name).FirstOrDefault();
            return one;
        }

        public static List<User> FindAll()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBase");
            var collection = database.GetCollection<User>("User");
            var list = collection.Find(x => true).ToList();
            var users = new List<User>();
            foreach (var user in list)
            {
                users.Add(user);
            }
            return users;
        }

        //public static void UploadImageToDb()
        //{
        //    var client = new MongoClient("UserBase");
        //    var database = client.GetDatabase("User");
        //    var gridFS = new GridFSBucket(database);

        //    using (FileStream fs = new FileStream("C:/Users/Vadim.Nacharov/Desktop/images321/ball.jpg", FileMode.Open))
        //    {
        //        gridFS.UploadFromStream("sss.jpg", fs);
        //    }
        //}

        //public static void DownloadToLocal()
        //{
        //    var client = new MongoClient("mongodb://localhost");
        //    var database = client.GetDatabase("Images321");
        //    var gridFS = new GridFSBucket(database);
        //    using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Images/")}DeserializedBall.jpg", FileMode.CreateNew))
        //    {
        //        gridFS.DownloadToStreamByName("sss.jpg", fs);
        //    }
        //}
    }
}