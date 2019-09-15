using Animals.Server.Strings;
using Animals.Share;
namespace Animals.Server
{
    public class BodyResponseFormat<T>: BodyResponseFormatBase<T>
    {
        public BodyResponseFormat()
        {
            Successful = true;
        }
        public BodyResponseFormat(T result)
        {
            Successful = true;
            Result = result;
        }
        public BodyResponseFormat(ErrorCode errorCode)
        {
            Successful = false;
            ErrorMessage = ErrorResources.ResourceManager.GetString(errorCode.ToString());
        }
    }
}
