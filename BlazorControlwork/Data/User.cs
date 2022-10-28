using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorControlwork.Data
{
    public class User
    {
        public User(string login, string firstName, string lastName, string email, string password)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;

        [BsonIgnoreIfNull]
        public string Login { get; set; }

        [BsonIgnoreIfNull]
        public string FirstName { get; set; }

        [BsonIgnoreIfNull]
        public string LastName { get; set; }

        [BsonIgnoreIfNull]
        public string Email { get; set; }

        [BsonIgnoreIfNull]
        public string Password { get; set; }

        [BsonIgnoreIfNull]
        public string Photo { get; set; }


    }
}