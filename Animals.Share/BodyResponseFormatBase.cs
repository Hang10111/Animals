using System;


namespace Animals.Share
{
    public class BodyResponseFormatBase<T>
    {
        public bool Successful { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
