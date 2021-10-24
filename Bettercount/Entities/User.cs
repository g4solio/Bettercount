namespace Bettercount.Entities
{
    public class User : IComparable
    {
        public string UId;

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            User otherUser = obj as User;
            if (otherUser != null)
                return this.UId.CompareTo(otherUser.UId);
            else
            throw new ArgumentException("Object is not a User");
        }

        public override bool Equals(object? obj)
        {
            if(obj is User)
                return (obj as User)?.UId.Equals(this.UId) ?? false;

            return base.Equals(obj);
        }
    }
}