using System;

namespace AnimeKakkoi.Core.Media
{
    /// <summary>
    /// Represent an error while getting information through media resources.
    /// </summary>
    public class MediaResourceException : Exception
    {

        private readonly Exception _additionalInnerException;

        private readonly string _message;

        public Exception AdditionalInnerException
        {
            get { return _additionalInnerException; }
        }

        public override string Message
        {
            get
            {
                return base.Message + Environment.NewLine + _message;
            }
        }

        public MediaResourceException(Exception ex)
        {
            _additionalInnerException = ex;
        }

        public MediaResourceException(Exception ex, string msg)
        {
            _additionalInnerException = ex;
            _message = msg;
        }

    }
}
