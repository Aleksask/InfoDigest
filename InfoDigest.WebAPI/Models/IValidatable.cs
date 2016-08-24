namespace InfoDigest.WebAPI.Models
{
    public interface IValidatable
    {
        bool IsValidForPost();
        bool IsValidForDelete();
        bool IsValidForPut();
        bool IsValidForPatch();
    }
}