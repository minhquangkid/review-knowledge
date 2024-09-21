using System.Collections.Generic;
using System.Collections.ObjectModel;

//  https://exercism.org/tracks/csharp/exercises/authentication-system/edit
public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    private readonly Identity admin;

    private IDictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };

    public Identity Admin
    {
        get { return admin; }
        // set { admin = value; }
    }

    public IDictionary<string, Identity> GetDevelopers()
    {
        ReadOnlyDictionary<string, Identity> readOnlyDev = new ReadOnlyDictionary<string, Identity>(developers);
        return readOnlyDev;
    }
}

    public struct Identity
    {
        public string Email { get; set; }

        public string EyeColor { get; set; }
    }
