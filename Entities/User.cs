namespace Bettercount.Entities
{
    public class User
    {
        public string UId;

        public override bool Equals(object? obj)
        {
            if(obj is User)
                return (obj as User)?.UId.Equals(this.UId) ?? false;

            return base.Equals(obj);
        }
    }
}